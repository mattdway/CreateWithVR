
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ All rights reserved./  (_(__(S)   |___*/

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using WanzyeeStudio.Editrix.Extension;
using WanzyeeStudio.Extension;

using Object = UnityEngine.Object;

namespace WanzyeeStudio.Editrix.Toolkit{
	
	public partial class Clipboard{

		/// <summary>
		/// Handle all Drag'n'Drop operations for <c>Clipboard</c>.
		/// </summary>
		private static class Dragger{

			#region Fields

			/// <summary>
			/// Type of Inspector window.
			/// </summary>
			private static readonly Type _inspectorType = Type.GetType("UnityEditor.InspectorWindow, UnityEditor");

			/// <summary>
			/// Method to get the Inspector window tracker to find the inspected targets to paste.
			/// </summary>
			private static readonly MethodInfo _trackerMethod = (
				_inspectorType.GetMethod("GetTracker", false, typeof(ActiveEditorTracker)) ??
				_inspectorType.GetMethod("get_tracker", false, typeof(ActiveEditorTracker))
			);

			/// <summary>
			/// The targets of existing Inspector windows to paste.
			/// </summary>
			private static Dictionary<Object, IEnumerable<Object>> _pasteTargets;

			/// <summary>
			/// The paste source from a copied item.
			/// Also as the flag to check if drop to paste.
			/// </summary>
			private static Object _pasteSource;

			/// <summary>
			/// The position where the mouse pressed, used to ensure to start drag from the same area.
			/// </summary>
			private static Vector2 _dragPosition;

			#endregion


			#region Copy Methods

			/// <summary>
			/// Check if Drag'n'Drop performed in a <c>Clipboard</c> window to copy dragged objects.
			/// </summary>
			/// 
			/// <remarks>
			/// Copy all attached <c>UnityEngine.Component</c> if drop any <c>UnityEngine.GameObject</c>.
			/// Show the type menu to filter if "Ctrl" key pressed when dropping.
			/// </remarks>
			/// 
			public static void CheckDragCopy(){

				var _sources = EditrixGUI.CheckDragObjects(FilterAllCopyable);
				if(null == _sources) return;

				if(!Event.current.control) Copy(_sources.ToArray());
				else ShowTypeCopyMenu(_sources);

			}

			/// <summary>
			/// Filter all copyable sources, include components of any source <c>UnityEngine.GameObject</c>.
			/// </summary>
			/// <returns>The filtered sources.</returns>
			/// <param name="sources">Sources.</param>
			private static IEnumerable<Object> FilterAllCopyable(IEnumerable<Object> sources){

				var _components = sources.OfType<GameObject>().SelectMany((obj) => obj.GetComponents<Component>());
				var _result = sources.Union(_components.Cast<Object>()).Where((source) => IsCopyable(source));

				#if WZ_LITE
				return Limiter.PrepareSources(_result);
				#else
				return _result;
				#endif

			}

			/// <summary>
			/// Show the types menu to copy the filtered sources.
			/// </summary>
			/// <param name="sources">Sources.</param>
			private static void ShowTypeCopyMenu(IEnumerable<Object> sources){

				var _group = sources.GroupBy((source) => source.GetType()).OrderBy((grp) => grp.Key.FullName);
				var _menu = new GenericMenu();

				_menu.AddItem("Copy All", Copy, sources.ToArray());

				if(1 < _group.Count() && _group.Any((grp) => typeof(Transform).IsAssignableFrom(grp.Key))){
					var _others = sources.Where((source) => !(source is Transform));
					_menu.AddItem("Exclude Transform", Copy, _others.ToArray());
				}

				_menu.AddSeparator("");
				foreach(var _sources in _group) _menu.AddItem(_sources.Key.Name, Copy, _sources.ToArray());

				_menu.ShowAsContext();

			}

			#endregion


			#region Drag Methods

			/// <summary>
			/// Check if to start drag the paste source from specified area.
			/// </summary>
			/// 
			/// <remarks>
			/// Only starts if all the situations below are valid:
			/// 	1. The positions to press and drag are both in the area when dragging.
			/// 	2. The reflection works and valid targets found.
			/// 	3. It's not dragging currently.
			/// </remarks>
			/// 
			/// <param name="area">Area.</param>
			/// <param name="source">Source.</param>
			/*
			 * Check clickCount to ensure receiving MouseUp when CheckDropPaste() to close the AuxCursor.
			 */
			public static void CheckDragPaste(Rect area, Object source){

				#if WZ_LITE
				if(!Limiter.IsWildcard(source)) return;
				#endif

				if(null == source) return;
				var _event = Event.current;

				var _type = _event.type;
				var _mouse = _event.mousePosition;

				if(EventType.MouseDown == _type) _dragPosition = (2 > _event.clickCount) ? _mouse : Vector2.zero;
				if(EventType.MouseDrag != _type) return;

				if(!area.Contains(_mouse) || !area.Contains(_dragPosition)) return;
				if(null == _trackerMethod || null != _pasteSource) return;

				_pasteTargets = GetPasteTargets(source);
				if(!_pasteTargets.Any()) return;

				_pasteSource = source;
				_event.Use();

			}

			/// <summary>
			/// Get the paste targets from the existing Inspector windows by the specified source type.
			/// </summary>
			/// <returns>The paste targets.</returns>
			/// <param name="source">Source.</param>
			private static Dictionary<Object, IEnumerable<Object>> GetPasteTargets(Object source){
				
				var _result = new Dictionary<Object, IEnumerable<Object>>();

				foreach(var _inspector in Resources.FindObjectsOfTypeAll(_inspectorType)){

					var _editors = (_trackerMethod.Invoke(_inspector, null) as ActiveEditorTracker).activeEditors;
					var _targets = _editors.SelectMany((editor) => editor.targets);

					if(source is Component) _targets = _targets.OfType<GameObject>().Cast<Object>();
					else _targets = _targets.Where((target) => source.GetType().IsInstanceOfType(target));

					if(_targets.Any()) _result.Add(_inspector, _targets);

				}

				return _result;

			}

			#endregion


			#region Paste Methods

			/// <summary>
			/// Check if dropped in an Inspector window with valid paste targets while dragging.
			/// </summary>
			/// 
			/// <remarks>
			/// Change the cursor as a hint while the mouse over the window.
			/// Paste the source to the targets when dropped in the window.
			/// </remarks>
			/*
			 * Check the Event.current.rawType to detect dropping anywhere.
			 * Store the mouseOverWindow to repaint, when the mouse may over nothing when click a generic menu.
			 */
			public static void CheckDropPaste(){
				
				if(null == _pasteSource) return;

				var _window = mouseOverWindow;
				var _drop = (EventType.MouseUp == Event.current.rawType);

				var _in = (null != _window && _pasteTargets.ContainsKey(_window));
				AuxCursor.mode = _in ? DragAndDropVisualMode.Copy : DragAndDropVisualMode.Rejected;

				if(_drop && _in){
					Event.current.Use();
					PasteTargets(_pasteTargets[_window]);
					_window.Repaint();
				}

				if(_drop || KeyCode.Escape == Event.current.keyCode){
					_pasteSource = null;
					AuxCursor.mode = DragAndDropVisualMode.None;
				}

			}

			/// <summary>
			/// Determine the paste source type to paste it to the specified targets.
			/// Show a sub menu to operate if "Ctrl" key pressed when dropping.
			/// </summary>
			/// <param name="targets">Targets.</param>
			private static void PasteTargets(IEnumerable<Object> targets){

				if(_pasteSource is Component){

					var _objects = targets.Cast<GameObject>();
					var _targets = _objects.ToDictionary((obj) => obj, (obj) => GetPastableComponents(obj));

					if(!Event.current.control) PasteComponents(0, _targets);
					else ShowComponentPasteMenu(_targets);

				}else{

					MaterialPropertyCopier.Copy(_pasteSource as Material);
					foreach(var _target in targets) MaterialPropertyCopier.Paste(_target as Material);

				}

			}

			/// <summary>
			/// Get the pastable components from specified <c>UnityEngine.GameObject</c>.
			/// </summary>
			/// <returns>The pastable components.</returns>
			/// <param name="target">Target.</param>
			/*
			 * Check title in case some classes is type of Component or Behaviour, e.g., Halo.
			 */
			private static Component[] GetPastableComponents(GameObject target){

				var _type = _pasteSource.GetType();

				var _components = target.GetComponents<Component>().Where((component) => null != component);
				_components = _components.Where((component) => component.GetType() == _type);

				if(typeof(Component) != _type && typeof(Behaviour) != _type) return _components.ToArray();

				var _title = ObjectNames.GetInspectorTitle(_pasteSource);
				return _components.Where((component) => ObjectNames.GetInspectorTitle(component) == _title).ToArray();

			}

			/// <summary>
			/// Paste the source <c>UnityEngine.Component</c> to specified <c>UnityEngine.GameObject</c> targets.
			/// Not allow to paste <c>UnityEngine.Transform</c> if the types are different.
			/// The default paste operations below:
			/// 	1. Paste as new if there's no component of the same type.
			/// 	2. Paste values to the indexed existing component if the index valid.
			/// 	3. Paste values to all the existing components if the index negative.
			/// 	4. Paste as new if the index is out of range.
			/// </summary>
			/// <param name="index">Index.</param>
			/// <param name="targets">Targets.</param>
			/*
			 * It crashes when pasting a RectTransform to a Transform sometimes.
			 * Simply disallow it to avoid, since it's an irregular operation originally.
			 * Unfortunately, I haven't reproduced the crash in a new empty project.
			 */
			private static void PasteComponents(int index, Dictionary<GameObject, Component[]> targets){
				
				ComponentUtility.CopyComponent(_pasteSource as Component);

				foreach(var _target in targets){

					if(_pasteSource is Transform && _pasteSource.GetType() != _target.Key.transform.GetType()){
						var _format = "It's not allowed to paste a {0} to {1}.";
						Debug.LogWarningFormat(_target.Key, _format, _pasteSource.GetType(), _target.Key.transform);
						continue;
					}

					if(_target.Value.Length <= index) ComponentUtility.PasteComponentAsNew(_target.Key);

					else if(0 <= index) ComponentUtility.PasteComponentValues(_target.Value[index]);

					else foreach(var _component in _target.Value) ComponentUtility.PasteComponentValues(_component);

				}

			}

			/// <summary>
			/// Show the menu to paste a <c>UnityEngine.Component</c> as new or paste the values to a specified one.
			/// </summary>
			/// <param name="targets">Targets.</param>
			/*
			 * Send an event to show the menu immediately, and block the current stack trace until the menu closed.
			 */
			private static void ShowComponentPasteMenu(Dictionary<GameObject, Component[]> targets){
				
				var _count = targets.Max((pair) => pair.Value.Count());
				var _menu = new GenericMenu();

				_menu.AddItem("Paste As New", () => PasteComponents(int.MaxValue, targets));
				if(1 < _count) _menu.AddItem("Paste Values to All", () => PasteComponents(-1, targets));
				if(0 < _count) _menu.AddSeparator("");

				for(int i = 0; i < _count; i++){
					var _number = (3 > i) ? new []{"1st", "2nd", "3rd"}[i] : ((i + 1) + "th");
					var _index = i;
					_menu.AddItem("Paste Values to " + _number, () => PasteComponents(_index, targets));
				}

				_menu.ShowAsContext();
				mouseOverWindow.SendEvent(Event.KeyboardEvent("~"));

			}

			#endregion

		}

	}

}

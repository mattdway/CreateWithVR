
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ All rights reserved./  (_(__(S)   |___*/

using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using WanzyeeStudio.Editrix.Extension;

using Object = UnityEngine.Object;

namespace WanzyeeStudio.Editrix.Toolkit{
	
	/// <summary>
	/// Utility to copy <c>UnityEngine.Component</c> or <c>UnityEngine.Material</c> and paste it back.
	/// </summary>
	/// 
	/// <remarks>
	/// Useful for tweaking lots of objects in the editor, even in play mode.
	/// Click the menu "Window/Clipboard" to open the window.
	/// Just play and tweak, drag and drop, copy and paste whenever.
	/// It acts as sort of preset system, edit lots of copies as presets, and paste to apply values quickly.
	/// Easy to find and manage copies with a search filter, custom item label, and foldable inspector.
	/// </remarks>
	/// 
	/// <remarks>
	/// Copy:
	/// 	1. Drag'n'Drop from "Inspector" to copy the inspected sources.
	/// 	2. Drag'n'Drop a <c>UnityEngine.GameObject</c> to copy the components on it.
	/// 	3. Show menu to specify the component type if "Ctrl" pressed when dropping gameObjects.
	/// 	4. Or click the context menu "Copy to Clipboard".
	/// </remarks>
	/// 
	/// <remarks>
	/// Paste:
	/// 	1. Drag'n'Drop to "Inspector" to paste back to the inspected targets.
	/// 	2. When dragging a component, it pastes values to the first one on the gameObject, or pastes as new if none.
	/// 	3. Show menu to specify a target of multiple components if "Ctrl" pressed when dropping.
	/// 	4. Or click the "Copy" button above any item, and paste by the target's context menu.
	/// </remarks>
	/// 
	/// <remarks>
	/// Filter items with the search bar:
	/// 	1. Click the "Magnifier" icon to show a context menu made from the current items to select filters easily.
	/// 	2. Or input any text to filter the item's name, just like the Project window's search bar.
	/// 	3. Prefix "t:" filters by the type, the search will include all specified types.
	/// 	4. Prefix "l:" filters by the tooltip as labels, an item has to match all specified labels.
	/// 	5. Toggle the "Link" icon at the top-right of window to filter automatically by tracking selection.
	/// </remarks>
	/// 
	/// <remarks>
	/// Edit the item label:
	/// 	1. Click the "Pen" button beside the label to show or hide the edit field.
	/// 	2. To save the change, just press "Ctrl-Enter" keys or unfocus the field after editing.
	/// 	3. The first line shows as the label title, and the full text is the tooltip.
	/// 	4. Leave the field empty to show the default text, i.e., the copy source path.
	/// </remarks>
	/// 
	/// <remarks>
	/// Find the copy source object:
	/// 	1. Click the "Aim" button to ping it or double-click to select it.
	/// 	2. The saved trace path is also shown as the default label tooltip.
	/// 	3. It'll beep if not found, e.g., the trace may be lost if the source is moved or renamed.
	/// </remarks>
	/// 
	/// <remarks>
	/// The reasons not to save the trace by references below:
	/// 	1. A scene object reference will change when load a scene.
	/// 	2. We can't save the scene reference in the project assets.
	/// 	3. We shouldn't save the edit data in user's game scene.
	/// </remarks>
	/// 
	/// <remarks>
	/// For component references to scene object.
	/// This creates copies and store in editor scene temporarily to ensure content correct.
	/// It means the copy will be destroyed when quitting the editor.
	/// And also, the scene references will become missing when opening another scene.
	/// The situation above is applicable to a material with scene texture, too.
	/// </remarks>
	/// 
	/// <remarks>
	/// For material or component without reference to any scene object.
	/// The copies will be saved with a label "Ignore" in an asset folder to make them still until manually "Clear".
	/// This tracks all copies by specific name or folder to ensure valid after script reloaded.
	/// </remarks>
	/// 
	/// <remarks>
	/// SVN users may clear all manually to avoid committing, or ignore the storing folder below:
	/// 	1. The default is "Temp/Clipboard" under the root folder "Assets/WanzyeeStudio".
	/// 	2. If the root is moved, it becomes "Temp/Clipboard" under the first found "WanzyeeStudio".
	/// 	3. If there's no "WanzyeeStudio" folder, it'll be "Assets/Temp/Clipboard".
	/// </remarks>
	/// 
	/// <remarks>
	/// Instructions, to copy and paste generic component is dangerous, even if reflect all the fields.
	/// Since we'll never know what the developer do when the component awake.
	/// As the <a href="http://answers.unity3d.com/answers/1013926/view.html" target="_blank">thread</a>
	/// I commented, we'd be very careful with which aren't made by ourselves.
	/// Finally, this was created, works in the editor with Unity built-in classes and API.
	/// </remarks>
	/// 
	public partial class Clipboard : EditorWindow, IHasCustomMenu{
		
		#region Menu
		
		/// <summary>
		/// Copy the <c>UnityEngine.Component</c> or <c>UnityEngine.Material</c> into clipboard.
		/// </summary>
		/// <param name="command">Command.</param>
		[MenuItem("CONTEXT/Component/Copy to Clipboard", false, 700)]
		[MenuItem("CONTEXT/Material/Copy to Clipboard", false, 700)]
		private static void CopyToClipboard(MenuCommand command){
			
			if(!IsCopyable(command.context)) return;

			Copy(command.context);
			OpenWindow();

		}
		
		/// <summary>
		/// Check if <c>ComponentCopyToClipboard()</c> or <c>MaterialCopyToClipboard()</c> valid.
		/// The context is copyable.
		/// </summary>
		/// <returns><c>true</c>, if valid.</returns>
		/// <param name="command">Command.</param>
		[MenuItem("CONTEXT/Component/Copy to Clipboard", true)]
		[MenuItem("CONTEXT/Material/Copy to Clipboard", true)]
		private static bool CopyToClipboardValid(MenuCommand command){
			return IsCopyable(command.context);
		}
		
		/// <summary>
		/// Show the clipboard window.
		/// </summary>
		[MenuItem("Window/Clipboard", false, 2100)]
		public static void OpenWindow(){
			GetWindow<Clipboard>();
		}
		
		#endregion

		
		#region Static Methods
		
		/// <summary>
		/// Determine if the specified source is able to copy to clipboard.
		/// </summary>
		/// <returns><c>true</c> if is copyable; otherwise, <c>false</c>.</returns>
		/// <param name="source">Source object.</param>
		public static bool IsCopyable(Object source){

			try{ Manager.CheckCreatable(source); }
			catch{ return false; }
			return true;

		}

		/// <summary>
		/// Copy the specified sources to clipboard.
		/// </summary>
		/// <param name="sources">Source objects.</param>
		public static void Copy(params Object[] sources){

			if(null == sources) return;

			foreach(var _source in sources) Manager.CheckCreatable(_source);
			foreach(var _source in sources) Manager.Create(_source);

		}
		
		/// <summary>
		/// Clear clipboard by specified type, or pass <c>null</c> to clear all.
		/// </summary>
		public static void Clear(Type type = null){
			Manager.RemoveAll(type, false);
		}

		/// <summary>
		/// Show a dialog with tooltip and the button to open online manual.
		/// </summary>
		private static void OpenAbout(){

			var _message = (

				"Clipboard for Component and Material." +

				"\n\nCopy:" +
				"\n- Click their context menu 'Copy to Clipboard'." +
				"\n- Or Drag'n'Drop into Clipboard to grab a snapshot." +
				"\n- Note, a scene or runtime reference may be lost when opening a scene or when stopping." +

				"\n\nPaste:" +
				"\n- Click an item 'Copy' button, then context menu 'Paste Component Values' or 'Paste Properties'." +
				"\n- Or Drag'n'Drop into Inspector to paste back." +

				"\n\nPlease read the manual for detail."
				#if WZ_LITE
				+ "\nLite version limits are listed in the Asset Store."
				#endif

			);

			var _open = EditorUtility.DisplayDialog("About Clipboard", _message, "Online Manual", "Close");
			if(_open) Help.BrowseURL("https://git.io/vS63e");

		}

		#endregion


		#region Static Fields and Properties
		
		/// <summary>
		/// The expand button on toolbars.
		/// </summary>
		private static GUIContent _expandBtn;
		
		/// <summary>
		/// The clear button on main toolbar.
		/// </summary>
		private static GUIContent _clearBtn;

		/// <summary>
		/// The label of setting title field.
		/// </summary>
		private static GUIContent _settingLabel = new GUIContent("Settings", "Click label to hide settings.");

		/// <summary>
		/// The label of persist setting field.
		/// </summary>
		private static GUIContent _persistLabel = new GUIContent("Prefer Persist", "Persist new copies if possible.");

		#endregion


		#region Public Fields

		/// <summary>
		/// Flag to track selection to change search filter automatically.
		/// </summary>
		[Tooltip("If to track selection to change search filter automatically.")]
		public bool track;

		/// <summary>
		/// The search filter pattern in the search bar.
		/// </summary>
		[Tooltip("Search filter pattern.")]
		public string search = "";

		/// <summary>
		/// Flag to show settings.
		/// </summary>
		[Tooltip("If to show settings.")]
		public bool setting;

		#endregion


		#region Private Fields

		/// <summary>
		/// The stored search pattern to check changed to update <c>_items</c>.
		/// </summary>
		private string _search = "";

		/// <summary>
		/// The items filtered from <c>_group</c> to draw GUI.
		/// </summary>
		private IEnumerable<KeyValuePair<Group, Item[]>> _items;
		
		/// <summary>
		/// The groups of all loaded copy items.
		/// </summary>
		/*
		 * Serialize to keep expand states after exiting editor.
		 */
		[Obfuscation(Exclude = true)]
		[SerializeField]
		[Tooltip("Groups of all loaded copy items.")]
		private Group[] _groups = {};

		/// <summary>
		/// Flag to refresh, set when initialize or copies possible changed.
		/// Checked to trigger refresh when <c>OnGUI()</c>.
		/// </summary>
		private bool _refresh;

		/// <summary>
		/// The repaint time, used to reduce invoking by <c>Update</c>.
		/// </summary>
		private double _repaint;
		
		/// <summary>
		/// The GUI scroll position.
		/// </summary>
		private Vector2 _scroll;

		#endregion


		#region Message Methods
		
		/// <summary>
		/// OnEnable, initialize styles, set window title and the min size, then register callbacks.
		/// </summary>
		private void OnEnable(){

			if(null == _expandBtn) _expandBtn = new GUIContent(EditrixStyle.hierarchyIcon, "Expand / Fold all");
			if(null == _clearBtn) _clearBtn = new GUIContent(EditrixStyle.deleteIcon, "Clear all");

			titleContent = new GUIContent(" Clipboard", EditrixStyle.clipboardIcon);
			minSize = new Vector2(275f, 150f);
			wantsMouseMove = true;

			_refresh = true;
			Manager.refresh += MarkRefresh;
			
			#if !WZ_LITE
			Selection.selectionChanged += SearchSelection;
			#else
			Limiter.CheckInitialize(this);
			#endif

		}

		/// <summary>
		/// OnDisable, deregister callbacks.
		/// </summary>
		private void OnDisable(){
			
			Manager.refresh -= MarkRefresh;

			#if !WZ_LITE
			Selection.selectionChanged -= SearchSelection;
			#endif

		}

		/// <summary>
		/// Update, repaint displayed values and check if all the copies are still in a lower frequency.
		/// Also trigger to reload ASAP when the refresh event occurs.
		/// </summary>
		private void Update(){
			if(_refresh || 1f < EditorApplication.timeSinceStartup - _repaint) Repaint();
		}

		/// <summary>
		/// ShowButton, show a button at the top-right corner to switch track state.
		/// </summary>
		/// <param name="r">Rect.</param>
		/*
		 * https://leahayes.wordpress.com/2013/04/30/adding-the-little-padlock-button-to-your-editorwindow/
		 * The parameter naming is really bad, but leave it copycat as the Unity's source code.
		 */
		private void ShowButton(Rect r){

			var _enabled = GUI.enabled;

			#if WZ_LITE
			GUI.enabled = false;
			var _content = new GUIContent(EditrixStyle.linkIcon, "Track Selection [Full only]");
			#else
			var _content = new GUIContent(track ? EditrixStyle.linkIcon : EditrixStyle.unlinkIcon, "Track Selection");
			#endif

			track = GUI.Toggle(new Rect(r.x, r.y + 2f, r.width, r.height - 5f), track, _content, GUIStyle.none);
			GUI.enabled = _enabled;

		}

		/// <summary>
		/// OnGUI, mainly control process like update.
		/// Check refresh, draw contents, check Drag'n'Drop operations in ordered.
		/// </summary>
		private void OnGUI(){

			_repaint = EditorApplication.timeSinceStartup;
			if(EventType.MouseMove == Event.current.type) Repaint();

			Dragger.CheckDropPaste();
			CheckRefresh();

			DrawToolbar();
			if(setting) DrawSettings();

			_scroll = GUILayout.BeginScrollView(_scroll);
			DrawContent();
			
			GUILayout.EndScrollView();
			Dragger.CheckDragCopy();

		}

		#endregion


		#region Methods

		/// <summary>
		/// Add the window context menu items.
		/// </summary>
		/// 
		/// <remarks>
		/// Menu "About" to open the online manual, and "Settings" for common preferences.
		/// Menu "New window" to open another <c>Clipboard</c> window.
		/// </remarks>
		/// 
		/// <param name="menu">Menu.</param>
		/// 
		public void AddItemsToMenu(GenericMenu menu){
			
			menu.AddItem("About", OpenAbout);
			menu.AddItem("Settings", () => setting = !setting, setting);

			#if WZ_LITE
			menu.AddItem("New window [Full only]");
			#else
			menu.AddItem("New window", () => CreateInstance<Clipboard>().Show());
			#endif

		}

		/// <summary>
		/// Callback method for <c>Manager.refresh</c> to mark the <c>_refresh</c> flag to reload later.
		/// </summary>
		/*
		 * Repaint twice, Update() and delayCall, for Item to update and show buttons.
		 */
		private void MarkRefresh(){
			_refresh = true;
			EditorApplication.delayCall += Repaint;
		}

		/// <summary>
		/// Check if refresh the groups and keep the expand state.
		/// </summary>
		private void CheckRefresh(){

			if(EventType.Layout != Event.current.type) return;

			var _force = !_refresh && _groups.SelectMany((grp) => grp.items).Any((item) => null == item.copy);
			if(!_force && !_refresh) return;

			var _folds = GetFoldTypes();
			var _expands = GetExpandCopies();

			_groups = Manager.Load(_force);
			_items = null;
			_refresh = false;

			var _exists = _groups.SelectMany((grp) => grp.items);
			foreach(var _item in _exists) if(_expands.ContainsKey(_item.copy)) _item.expand = _expands[_item.copy];
			foreach(var _group in _groups) if(_folds.Contains(_group.type)) _group.expand = false;

			GUI.FocusControl(null);

		}

		/// <summary>
		/// Get the types of the folded groups.
		/// </summary>
		/// <returns>The types.</returns>
		/*
		 * Get the type of existing copy instead of the group since this's for refreshing, 
		 */
		private List<Type> GetFoldTypes(){

			var _folds = _groups.Where((grp) => !grp.expand);

			var _exists = _folds.Select((grp) => grp.items.FirstOrDefault((item) => null != item.copy));

			return _exists.Where((item) => null != item).Select((item) => item.copy.GetType()).ToList();

		}

		/// <summary>
		/// Get the copies paired with the item expand state.
		/// </summary>
		/// <returns>The copies.</returns>
		private Dictionary<Object, int> GetExpandCopies(){
			
			var _exists = _groups.SelectMany((grp) => grp.items).Where((item) => null != item.copy);

			return _exists.ToDictionary((item) => item.copy, (item) => item.expand);

		}

		#endregion


		#region Draw Methods

		/// <summary>
		/// Draw the main toolbar, include the field to edit or select the search pattern, and all functional buttons.
		/// </summary>
		private void DrawToolbar(){

			GUILayout.BeginHorizontal(EditorStyles.toolbar);

			search = EditrixGUI.SearchField(
				search,
				() => Filer.ShowFilterMenu(_groups, search, (filter) => search = filter)
			);

			GUILayout.FlexibleSpace();
			EditorGUI.BeginChangeCheck();

			DrawButtons();
			if(EditorGUI.EndChangeCheck()) GUI.FocusControl(null);

			GUILayout.Space(19f - EditorGUIUtility.currentViewWidth + position.width);
			GUILayout.EndHorizontal();

		}

		/// <summary>
		/// Draw the fold and clear buttons on the toolbar.
		/// </summary>
		private void DrawButtons(){
			
			if(GUILayout.Button(_expandBtn, EditorStyles.toolbarButton, GUILayout.Width(22f))){
				
				if(!_groups.Any((grp) => grp.expand)){
					foreach(var _group in _groups) _group.expand = true;
					foreach(var _item in _groups.SelectMany((grp) => grp.items)) _item.expand = 3;
				}else{
					var _all = _groups.Where((grp) => grp.expand).SelectMany((grp) => grp.items);
					if(_all.Any((item) => 0 != item.expand)) foreach(var _item in _all) _item.expand = 0;
					else foreach(var _group in _groups) _group.expand = false;
				}

			}

			if(GUILayout.Button(_clearBtn, EditorStyles.toolbarButton, GUILayout.Width(22f)) && _groups.Any()){
				EditorApplication.Beep();
				var _message = "\nClearing is irreversible!\n\nAre you sure to delete all copies?";
				if(EditorUtility.DisplayDialog("Clear Clipboard", _message, "OK")) Manager.RemoveAll(null, true);
			}

		}

		/// <summary>
		/// Draw the settings.
		/// </summary>
		private void DrawSettings(){

			GUILayout.Space(-2f);
			if(GUILayout.Button(_settingLabel, EditorStyles.boldLabel)) setting = false;

			#if WZ_LITE
			Limiter.DrawSetting(_persistLabel);
			#else
			DrawPersistSetting();
			#endif

			GUILayout.Space(2f);
			GUI.DrawTexture(GUILayoutUtility.GetRect(1f, 1f), EditrixStyle.splitterPixel);
			
		}

		/// <summary>
		/// Draw the content of copies if existing, otherwise show a help box.
		/// </summary>
		private void DrawContent(){

			if((_search != search || null == _items) && _groups.Any()) _items = Filer.FilterItems(_groups, search);
			_search = search;

			if(null == _items) EditorGUILayout.HelpBox("Clipboard for Component and Material.", MessageType.Info);
			else if(!_items.Any()) EditorGUILayout.HelpBox("No item matches the search pattern.", MessageType.Warning);
			else DrawItems();

			GUILayout.Space(20f);

		}

		/// <summary>
		/// Draw the items belong paired group, and an end line if need.
		/// </summary>
		private void DrawItems(){

			foreach(var _group in _items){
				_group.Key.Draw();
				if(_group.Key.expand) foreach(var _item in _group.Value) _item.Draw();
			}

			var _last = _items.Last().Key.expand ? _items.Last().Value.LastOrDefault() : null;
			if(null == _last || 0 == _last.expand || 2 == (_last.expand & 2)) return;

			GUI.DrawTexture(GUILayoutUtility.GetRect(1f, 1f), EditrixStyle.splitterPixel);

		}

		#endregion


		#if !WZ_LITE

		/// <summary>
		/// The stored track state to check changed to update <c>search</c>.
		/// </summary>
		private bool _track;

		/// <summary>
		/// The pref key to store the flag to persist.
		/// </summary>
		private static readonly string _persistPref = typeof(Clipboard).FullName + "._persistPref";

		/// <summary>
		/// Flag to persist new copies as asset if possible.
		/// </summary>
		/// 
		/// <remarks>
		/// Enable to save the copies for next time opening the project.
		/// Disable to make copying faster without creating asset if you don't need.
		/// It only applies to copy operations after changing this setting.
		/// </remarks>
		/// 
		/// <value>If to persist.</value>
		/// 
		public static bool preferPersist{
			get{ return 0 != PlayerPrefs.GetInt(_persistPref, 1); }
			set{ PlayerPrefs.SetInt(_persistPref, value ? 1 : 0); }
		}

		/// <summary>
		/// OnLostFocus, trigger all items to check save note if changed.
		/// </summary>
		private void OnLostFocus(){
			foreach(var _item in _groups.SelectMany((grp) => grp.items)) _item.SaveNote();
			GUI.FocusControl(null);
		}

		/// <summary>
		/// OnInspectorUpdate, check if the track state changed to apply.
		/// </summary>
		private void OnInspectorUpdate(){
			if(!_track && track) SearchSelection();
			_track = track;
		}

		/// <summary>
		/// Update search filter by selection if enabled.
		/// </summary>
		private void SearchSelection(){
			if(!track) return;
			search = Filer.GetSelectionFilter(search ?? "");
			Repaint();
		}

		/// <summary>
		/// Draw the setting of <c>preferPersist</c>.
		/// </summary>
		private void DrawPersistSetting(){
			
			var _persist = preferPersist;
			if(EditorGUILayout.Toggle(_persistLabel, _persist) == _persist) return;

			preferPersist = !_persist;
			Manager.refresh.Invoke();

		}

		#endif

	}

}

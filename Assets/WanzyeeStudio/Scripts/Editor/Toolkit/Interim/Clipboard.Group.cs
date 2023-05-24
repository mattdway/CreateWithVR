
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ All rights reserved./  (_(__(S)   |___*/

using UnityEditor;
using UnityEngine;
using System;
using System.Linq;

namespace WanzyeeStudio.Editrix.Toolkit{
	
	public partial class Clipboard{
		
		/// <summary>
		/// Group includes copied items of specified type.
		/// To draw GUI with expandable label and all items within.
		/// </summary>
		[Serializable]
		private class Group{

			#region Fields
			
			/// <summary>
			/// The toolbar button to clear whole group.
			/// </summary>
			private static readonly GUIContent _editBtn = new GUIContent("X", "Clear group");

			/// <summary>
			/// The expand state.
			/// </summary>
			/*
			 * Public as Serializable for Clipboard restoring expand state, also as items.
			 */
			public bool expand = true;

			/// <summary>
			/// The copied items to draw.
			/// </summary>
			public Item[] items;

			/// <summary>
			/// The label to show on expandable toolbar.
			/// </summary>
			public readonly GUIContent label;

			/// <summary>
			/// The type of copied items.
			/// </summary>
			public readonly Type type;

			#endregion


			#region Methods

			/// <summary>
			/// Initialize each value specified.
			/// </summary>
			/// <returns>The instance.</returns>
			/// <param name="type">Type.</param>
			/// <param name="items">Items.</param>
			public Group(Type type, Item[] items){
				
				this.type = type;
				this.items = items;

				label = new GUIContent(type.Name, type.FullName);
				if(typeof(Component) == type || typeof(Behaviour) == type){
					
					var _titles = items.Select((item) => ObjectNames.GetInspectorTitle(item.copy).Replace(" ", ""));
					label.text = label.tooltip = string.Join("/", _titles.Distinct().ToArray());

				}

			}

			/// <summary>
			/// Draw GUI includes label bar with buttons, and items if expand.
			/// </summary>
			public void Draw(){

				EditorGUILayout.Space();
				EditorGUI.BeginChangeCheck();

				var _color = GUI.backgroundColor;
				var _alpha = _color * new Color(1f, 1f, 1f, 0.7f);
				
				GUI.backgroundColor = _alpha;
				GUILayout.BeginHorizontal(EditorStyles.toolbar);

				GUI.backgroundColor = _color;
				DrawLabel();

				GUI.backgroundColor = _alpha;
				DrawButtons();
				
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();

				GUI.backgroundColor = _color;
				if(EditorGUI.EndChangeCheck()) GUI.FocusControl(null);

			}

			/// <summary>
			/// Draw the label, clicked to switch expand.
			/// </summary>
			private void DrawLabel(){
				
				var _width = GUILayout.Width(EditorGUIUtility.currentViewWidth - 86f);
				var _style = new GUIStyle(EditorStyles.foldout);

				_style.clipping = TextClipping.Clip;
				_style.fontStyle = FontStyle.Bold;

				expand = GUILayout.Toggle(expand, label, _style, _width);
				GUILayout.Space(8f);

			}

			/// <summary>
			/// Draws the expand items and remove group buttons.
			/// </summary>
			private void DrawButtons(){

				if(GUILayout.Button(_expandBtn, EditorStyles.toolbarButton, GUILayout.Width(22f))){
					if(expand){
						var _expand = items.Any((item) => 0 != item.expand) ? 0 : 3;
						foreach(var _item in items) _item.expand = _expand;
					}else{
						expand = true;
					}
				}

				if(GUILayout.Button(_editBtn, EditorStyles.toolbarButton, GUILayout.Width(22f))){
					Manager.RemoveAll(type, true);
				}
				
			}

			#endregion

		}

	}

}

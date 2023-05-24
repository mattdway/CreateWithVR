
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ All rights reserved./  (_(__(S)   |___*/

using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using WanzyeeStudio.Editrix.Extension;
using WanzyeeStudio.Extension;

using Object = UnityEngine.Object;

namespace WanzyeeStudio.Editrix.Toolkit{
	
	public partial class Clipboard{

		/// <summary>
		/// Handle data and search operations for <c>Clipboard</c>.
		/// </summary>
		private static class Filer{

			#region Fields

			/// <summary>
			/// The temp directory to store scene copies' data, e.g., display name, note, source, etc.
			/// </summary>
			private const string _DATA_ROOT = "Temp/WanzyeeStudio/Clipboard/Data";

			#endregion


			#region Data Methods

			/// <summary>
			/// Set the source info data of specified copy, include asset guid and hierarchy or name.
			/// </summary>
			/// <param name="copy">Copied object.</param>
			/// <param name="source">Source object.</param>
			public static void SetSource(Object copy, Object source){

				var _source = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetOrScenePath(source)) + ":";

				if(source is Component) _source += (source as Component).transform.GetPath();

				else _source += (string.IsNullOrEmpty(source.name) ? source.GetType().Name : source.name);

				WriteData(copy, (_source + "\n" + GetNote(copy)).Trim());

			}

			/// <summary>
			/// Get the source of specified copy.
			/// Return <c>UnityEngine.GameObject</c> if the copy is an <c>UnityEngine.Component</c>.
			/// </summary>
			/// <returns>The source object.</returns>
			/// <param name="copy">Copied object.</param>
			public static Object GetSource(Object copy){

				var _source = new Regex(":").Split(ReadData(copy).Split('\n')[0], 2);
				if(2 > _source.Length) return null;

				var _path = AssetDatabase.GUIDToAssetPath(_source[0]) ?? "";
				var _asset = AssetDatabase.LoadAssetAtPath<Object>(_path);

				if((null == _asset && "" != _path) || (!(copy is Component))) return _asset;

				var _objects = Resources.FindObjectsOfTypeAll<GameObject>().AsEnumerable();
				if("" != _path) _objects = _objects.Where((obj) => AssetDatabase.GetAssetOrScenePath(obj) == _path);

				_objects = _objects.Where((obj) => _source[1] == obj.transform.GetPath());
				return _objects.OrderBy((obj) => null == obj.GetComponent(copy.GetType())).FirstOrDefault() ?? _asset;

			}

			/// <summary>
			/// Get the note of specified copy, optional to get source info as default if not existing.
			/// </summary>
			/// <returns>The note.</returns>
			/// <param name="copy">Copied object.</param>
			/// <param name="must">If set to <c>true</c> must.</param>
			public static string GetNote(Object copy, bool must = false){

				var _data = new Regex("\n").Split(ReadData(copy).Trim(), 2);

				#if !WZ_LITE
				if(1 < _data.Length) return _data[1].Trim();
				#endif

				if(!must) return "";

				var _source = new Regex(":").Split(_data[0], 2);
				var _note = (1 < _source.Length) ? _source[1] : copy.GetType().Name;

				return (_note + "\n" + AssetDatabase.GUIDToAssetPath(_source[0].Trim())).Trim();

			}

			/// <summary>
			/// Set the data of specified copy from another.
			/// </summary>
			/// <param name="copy">Copied object.</param>
			/// <param name="source">Source object.</param>
			public static void SetData(Object copy, Object source){
				WriteData(copy, ReadData(source));
			}

			/// <summary>
			/// Write the data of specified copy, 1st line as the source info, and note from the 2nd line.
			/// Use <c>AssetImporter.userData</c> for an asset, or temp file for a scene object.
			/// </summary>
			/// <param name="copy">Copied object.</param>
			/// <param name="data">Data.</param>
			private static void WriteData(Object copy, string data){
				
				var _importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(copy));

				if(null != _importer){
					_importer.userData = data;
					_importer.SaveAndReimport();
				}else{
					Directory.CreateDirectory(_DATA_ROOT);
					File.WriteAllText(Path.Combine(_DATA_ROOT, copy.GetInstanceID().ToString()), data);
				}

				Manager.refresh.Invoke();

			}

			/// <summary>
			/// Read the data of specified copy.
			/// </summary>
			/// <returns>The data.</returns>
			/// <param name="copy">Copied object.</param>
			private static string ReadData(Object copy){

				var _importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(copy));
				if(null != _importer) return _importer.userData;

				var _path = Path.Combine(_DATA_ROOT, copy.GetInstanceID().ToString());
				return File.Exists(_path) ? File.ReadAllText(_path) : "";

			}

			#endregion


			#region Filter Methods

			/// <summary>
			/// Get the <c>groups</c> items filtered by specified pattern.
			/// </summary>
			/// <returns>The items.</returns>
			/// <param name="groups">Groups.</param>
			/// <param name="filter">Filter.</param>
			public static IEnumerable<KeyValuePair<Group, Item[]>> FilterItems(Group[] groups, string filter){

				var _type = CombineFilter(filter, @"(?<=(^|\s)t:)\S+(?=(\s|$))", false);

				var _groups = groups.Where((grp) => _type.IsMatch(grp.label.tooltip));

				var _result = _groups.ToDictionary((grp) => grp, (grp) => FilterItems(grp.items, filter));

				return _result.Where((pair) => pair.Value.Any());

			}

			/// <summary>
			/// Filter the items label and name by specified pattern.
			/// </summary>
			/// <returns>The items.</returns>
			/// <param name="items">Items.</param>
			/// <param name="filter">Filter.</param>
			private static Item[] FilterItems(Item[] items, string filter){

				var _result = items.AsEnumerable();

				var _label = CombineFilter(filter, @"(?<=(^|\s)l:)\S+(?=(\s|$))", true);
				_result = _result.Where((item) => _label.IsMatch(item.label.tooltip.Substring(item.label.text.Length)));

				var _name = CombineFilter(filter, @"(?<=(^|\s)(?!(t:|l:)))\S+(?=(\s|$))", true);
				_result = _result.Where((item) => _name.IsMatch(item.label.text));

				return _result.ToArray();

			}

			/// <summary>
			/// Get a combo filter to match each word found in the input <c>string</c>.
			/// Optional to return a filter for matching all the words, otherwise for matching any of them.
			/// </summary>
			/// <returns>The combo filter.</returns>
			/// <param name="input">Input string.</param>
			/// <param name="pattern">Pattern to match words.</param>
			/// <param name="all">If set to <c>true</c> match all.</param>
			private static Regex CombineFilter(string input, string pattern, bool all){

				var _matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
				var _words = _matches.Cast<Match>().Select((match) => Regex.Escape(match.Value));

				if(!_words.Any()) return new Regex("");
				if(!all) return new Regex("(" + string.Join("|", _words.ToArray()) + ")", RegexOptions.IgnoreCase);

				var _pattern = string.Join("", _words.Select((word) => "(?=(.|\n)*" + word + ")").ToArray());
				return new Regex(_pattern, RegexOptions.IgnoreCase);

			}

			#endregion


			#region Menu Methods

			/// <summary>
			/// Show the menu to switch search filter by selecting type, name, or label, and send the new back.
			/// </summary>
			/// <param name="groups">Groups.</param>
			/// <param name="filter">Original filter.</param>
			/// <param name="callback">Callback to receive new search filter.</param>
			/*
			 * Use callback to delay return new filter, since lambda doesn't allow "ref".
			 * And passing the Clipboard instance might be inappropriate.
			 */
			public static void ShowFilterMenu(Group[] groups, string filter, Action<string> callback){

				var _menu = new GenericMenu();
				var _types = groups.Select((grp) => new []{grp.label.text, "t:" + grp.label.tooltip});

				AddFilterMenus(_menu, "Type/", @"(^|\s)t:\S+(?=(\s|$))", _types, filter, callback);

				var _items = FilterItems(groups, filter).SelectMany((pair) => pair.Value).Select((item) => item.label);
				var _names = SplitWords(_items.Select((item) => item.text)).Select((item) => new []{item, item});

				AddFilterMenus(_menu, "Name/", @"(^|\s)(?!(t:|l:))\S+(?=(\s|$))", _names, filter, callback);

				var _words = SplitWords(_items.Select((item) => item.tooltip.Substring(item.text.Length)));
				var _labels = _words.Select((word) => new []{word, "l:" + word});

				AddFilterMenus(_menu, "Label/", @"(^|\s)l:\S+(?=(\s|$))", _labels, filter, callback);

				_menu.ShowAsContext();

			}

			/// <summary>
			/// Add the menu items to switch specified <c>string</c> value in the <c>filter</c> and send the new back.
			/// </summary>
			/// <param name="menu">Menu.</param>
			/// <param name="root">Root name.</param>
			/// <param name="cleaner">Cleaner pattern.</param>
			/// <param name="items">Menu name and value pairs.</param>
			/// <param name="filter">Original filter.</param>
			/// <param name="callback">Callback to receive new search filter.</param>
			private static void AddFilterMenus(
				GenericMenu menu,
				string root,
				string cleaner,
				IEnumerable<string[]> items,
				string filter,
				Action<string> callback
			){

				#if WZ_LITE

				menu.AddItem(root + "[Full only]");
				if(items.Any()) menu.AddSeparator(root);
				foreach(var _item in items) menu.AddItem(root + _item[0]);

				#else

				menu.AddItem(root + "All", callback, Regex.Replace(filter, cleaner, "").Trim());
				if(items.Any()) menu.AddSeparator(root);
				foreach(var _item in items) AddFilterMenu(menu, root + _item[0], _item[1], filter, callback);

				#endif

			}

			/// <summary>
			/// Split all words from the given texts.
			/// </summary>
			/// <returns>The words.</returns>
			/// <param name="texts">Texts.</param>
			private static IEnumerable<string> SplitWords(IEnumerable<string> texts){

				var _info = CultureInfo.InvariantCulture.TextInfo;

				var _words = texts.SelectMany((text) => Regex.Split(text, @"\W+")).Where((word) => "" != word);

				return _words.Select((word) => _info.ToTitleCase(word.ToLower())).Distinct().OrderBy((word) => word);

			}

			#endregion


			#if !WZ_LITE

			/// <summary>
			/// Add a menu <c>item</c> to switch specified <c>word</c> in the <c>filter</c> and send the new back.
			/// </summary>
			/// <param name="menu">Menu.</param>
			/// <param name="item">Menu item name.</param>
			/// <param name="word">Filter word.</param>
			/// <param name="filter">Original filter.</param>
			/// <param name="callback">Callback to receive new search filter.</param>
			private static void AddFilterMenu(
				GenericMenu menu,
				string item,
				string word,
				string filter,
				Action<string> callback
			){

				var _regex = new Regex(@"(^|\s)" + Regex.Escape(word) + @"(?=(\s|$))", RegexOptions.IgnoreCase);
				var _match = _regex.IsMatch(filter);

				var _filter = (_match ? _regex.Replace(filter, "") : (word + " " + filter)).Trim();
				menu.AddItem(item, callback, _filter, _match);

			}

			/// <summary>
			/// Set the note of specified copy.
			/// </summary>
			/// <param name="copy">Copied object.</param>
			/// <param name="note">Note.</param>
			public static void SetNote(Object copy, string note){
				WriteData(copy, ReadData(copy).Split('\n')[0] + "\n" + note.Trim());
			}

			/// <summary>
			/// Get the filter includes all types of selected objects and the original labels.
			/// </summary>
			/// <returns>The selection filter.</returns>
			/// <param name="filter">Filter.</param>
			public static string GetSelectionFilter(string filter){

				var _filter = Regex.Replace(filter, @"(^|\s)t:\S+(?=(\s|$))", "").Trim();

				var _components = Selection.gameObjects.SelectMany((obj) => obj.GetComponents<Component>());

				var _objects = Selection.objects.Union(_components.Cast<Object>()).Where(IsCopyable);

				var _types = _objects.Select((obj) => obj.GetType().FullName).Distinct();

				return (_filter + "    " + string.Join(" ", _types.Select((type) => "t:" + type).ToArray())).Trim();

			}

			#endif

		}

	}

}

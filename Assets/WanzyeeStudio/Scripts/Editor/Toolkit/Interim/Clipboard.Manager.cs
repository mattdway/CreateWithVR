
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ All rights reserved./  (_(__(S)   |___*/

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using WanzyeeStudio.Extension;

using Object = UnityEngine.Object;

namespace WanzyeeStudio.Editrix.Toolkit{
	
	public partial class Clipboard{
		
		/// <summary>
		/// Manager to create and maintain all the copies.
		/// </summary>
		private static class Manager{

			#region Fields

			/// <summary>
			/// Occur to refresh when copied items changed.
			/// </summary>
			public static Action refresh = () => _groups = null;

			/// <summary>
			/// The stored groups for each <c>Clipboard</c> window to copy.
			/// Set <c>null</c> as the flag to update when the next loading.
			/// </summary>
			private static Group[] _groups;

			/// <summary>
			/// The scene root container to store copies, or as scene copy's name prefix.
			/// </summary>
			private const string _SCENE_ROOT = "WanzyeeStudio/Clipboard";

			/// <summary>
			/// The required <c>UnityEngine.Component</c> type pairs.
			/// </summary>
			/*
			 * For some reasons, Unity didn't declare RequireComponent attribute on types below, but they do need.
			 * NetworkTransformChild checks requirement in OnValidate(), and also check its hierarchy.
			 * Audio filters require AudioSource or AudioListener, but don't need both, so it can't declare.
			 */
			private static Dictionary<Type, Type> _requires = new Dictionary<Type, Type>(){
				// {typeof(NetworkTransformChild), typeof(NetworkTransform)},
				{typeof(AudioChorusFilter), typeof(AudioSource)},
				{typeof(AudioDistortionFilter), typeof(AudioSource)},
				{typeof(AudioEchoFilter), typeof(AudioSource)},
				{typeof(AudioHighPassFilter), typeof(AudioSource)},
				{typeof(AudioLowPassFilter), typeof(AudioSource)},
				{typeof(AudioReverbFilter), typeof(AudioSource)}
			};

			#endregion

			
			#if !WZ_LITE

			/// <summary>
			/// The asset root folder reference for lazy initializing, use <c>_assetRoot</c> instead.
			/// </summary>
			private static string _assetRootRef;

			/// <summary>
			/// The asset root folder to store copies, find default if existing, otherwise use project root.
			/// </summary>
			/// <value>The path of the asset root folder.</value>
			private static string _assetRoot{
				
				get{

					if(null != _assetRootRef && Directory.Exists(_assetRootRef)) return _assetRootRef;

					var _root = "Assets";
					var _name = "WanzyeeStudio";

					var _folders = Directory.GetDirectories(_root, _name, SearchOption.AllDirectories);
					var _folder = _folders.FirstOrDefault((path) => Path.GetFileName(path) == _name);

					_assetRootRef = ((_folder ?? "Assets") + "/Temp/Clipboard").Replace('\\', '/');
					return _assetRootRef;
					
				}
				
			}

			#endif


			#region Common Methods

			/// <summary>
			/// Check if the specified source object is able to copy.
			/// </summary>
			/// 
			/// <remarks>
			/// I.e., the type's supported and the source is from out of clipboard.
			/// Otherwise throw exception.
			/// </remarks>
			/// 
			/// <param name="source">Source object.</param>
			/// <param name="upskirt">If set to <c>true</c> allow to copy upskirt.</param>
			/// 
			public static void CheckCreatable(Object source, bool upskirt = false){

				if(null == source) throw new ArgumentNullException("source");

				if(!(source is Component) && !(source is Material))
					throw new NotSupportedException("Clipboard only supports Component and Material.");

				#if WZ_LITE
				Limiter.CheckOperable();
				#endif

				var _path = upskirt ? "" : GetObjectPath(source);
				var _self = _path.StartsWith(_SCENE_ROOT);

				#if !WZ_LITE
				if(!_self) _self = _path.StartsWith(_assetRoot);
				#endif

				if(_self) throw new InvalidOperationException("Clipboard won't copy upskirt self, please don't do it.");

			}

			/// <summary>
			/// Find or create the host <c>UnityEngine.GameObject</c> at specified hierarchy path.
			/// Like <c>GameObject.Find()</c>, but optional to create if none.
			/// Any created host is editable but hide in hierarchy and inactive.
			/// </summary>
			/// <returns>The scene host.</returns>
			/// <param name="path">Path.</param>
			/// <param name="create">If set to <c>true</c> create.</param>
			private static GameObject GetSceneHost(string path, bool create){

				var _all = Resources.FindObjectsOfTypeAll<Transform>().Where((obj) => !AssetDatabase.Contains(obj));
				var _roots = _all.Where((transform) => (null == transform.parent));

				var _flag = HideFlags.DontSave | HideFlags.HideInHierarchy;
				Transform _host = null;

				foreach(var _name in path.Split('/')){

					var _this = (null == _host) ? _roots.FirstOrDefault((obj) => _name == obj.name) : _host.Find(_name);
					if(null == _this && !create) return null;
					
					if(null == _this){
						_this = new GameObject(_name){ hideFlags = _flag }.transform;
						_this.SetParent(_host, false);
					}

					_host = _this;

				}

				return _host.gameObject;

			}
			
			/// <summary>
			/// Get the object path, i.e., asset path of asset object, or hierarchy path of scene object.
			/// </summary>
			/// <returns>The object path.</returns>
			/// <param name="obj">Object.</param>
			private static string GetObjectPath(Object obj){
				
				if(AssetDatabase.Contains(obj)) return AssetDatabase.GetAssetPath(obj);

				return (obj is Component) ? (obj as Component).transform.GetPath() : obj.name;
				
			}

			/// <summary>
			/// Get the type name combined with assembly name for identifying.
			/// </summary>
			/// <returns>The type name.</returns>
			/// <param name="type">Type.</param>
			private static string GetTypeName(Type type){
				return type.FullName + "@" + type.Assembly.GetName().Name;
			}

			#endregion
			
			
			#region Create Methods
			
			/// <summary>
			/// Create a copy from specified source object.
			/// </summary>
			/// <param name="source">Source object.</param>
			public static void Create(Object source){
				
				CheckCreatable(source);
				Object _object = null;
				
				#if !WZ_LITE
				if(preferPersist && !IsReferScene(source)){
					if(source is Material) _object = CreateAssetMaterial(source as Material);
					else _object = CreateAssetComponent(source as Component);
				}
				#endif

				if(null == _object){
					if(source is Material) _object = CreateSceneMaterial(source as Material);
					else _object = CreateSceneComponent(source as Component);
				}

				Filer.SetSource(_object, source);

			}

			/// <summary>
			/// Duplicate the specified copy.
			/// </summary>
			/// <param name="copy">Copied object.</param>
			public static void Duplicate(Object copy){

				CheckCreatable(copy, true);

				var _path = GetObjectPath(copy);
				Object _object = null;

				#if !WZ_LITE
				if(_path.StartsWith(_assetRoot)){
					if(copy is Material) _object = CreateAssetMaterial(copy as Material);
					else _object = CreateAssetComponent(copy as Component);
				}
				#endif
				
				if(_path.StartsWith(_SCENE_ROOT)){
					if(copy is Material) _object = CreateSceneMaterial(copy as Material);
					else _object = CreateSceneComponent(copy as Component);
				}

				if(null == _object) throw new InvalidOperationException("Clipboard can only duplicate copied item.");
				Filer.SetData(_object, copy);

			}

			/// <summary>
			/// Create a copied <c>UnityEngine.Material</c> stored in scene.
			/// </summary>
			/// <returns>The scene material.</returns>
			/// <param name="source">Source material.</param>
			private static Material CreateSceneMaterial(Material source){
				
				var _result = Object.Instantiate(source);

				_result.hideFlags = HideFlags.DontSave;
				_result.name = _SCENE_ROOT + "/" + GetTypeName(source.GetType()) + "/" + _result.GetInstanceID();

				return _result;

			}

			/// <summary>
			/// Create a copied <c>UnityEngine.Component</c> stored in scene.
			/// Create the hierarchy host with unique path at the meantime.
			/// </summary>
			/// <returns>The scene component.</returns>
			/// <param name="source">Source component.</param>
			/*
			 * The redundancy instantiating is only used to make operations not undoable.
			 */
			private static Component CreateSceneComponent(Component source){

				var _parent = GetSceneHost(_SCENE_ROOT + "/" + GetTypeName(source.GetType()), true).transform;
				var _name = GameObjectUtility.GetUniqueNameForSibling(_parent, source.GetInstanceID().ToString());

				var _component = CreateComponent(source);
				var _result = Instantiate(_component);
				DestroyImmediate(_component.gameObject);

				_result.transform.SetParent(_parent);
				_result.gameObject.hideFlags = _parent.gameObject.hideFlags;
				_result.gameObject.name = _name;

				return _result;

			}

			/// <summary>
			/// Create a component copied from the source, and attached on a hidden empty <c>UnityEngine.GameObject</c>.
			/// </summary>
			/// <returns>The component.</returns>
			/// <param name="source">Source component.</param>
			/*
			 * http://answers.unity3d.com/questions/530178/
			 * Not to instantiate directly to avoid potential Awake() and redundancy components.
			 * Check type for some components are not specific type, e.g., Halo.
			 */
			private static Component CreateComponent(Component source){

				var _object = new GameObject(){ hideFlags = HideFlags.DontSave | HideFlags.HideInHierarchy };
				_object.SetActive(false);

				var _type = source.GetType();
				if(_requires.ContainsKey(_type)) _object.AddComponent(_requires[_type]);

				ComponentUtility.CopyComponent(source);

				if(typeof(Component) == _type) ComponentUtility.PasteComponentAsNew(_object);
				else if(typeof(Behaviour) == _type) ComponentUtility.PasteComponentAsNew(_object);
				else if(typeof(Transform) == _type) ComponentUtility.PasteComponentValues(_object.transform);
				else ComponentUtility.PasteComponentValues(_object.AddComponent(_type));

				var _result = _object.GetComponents<Component>().Last((component) => component.GetType() == _type);
				RedirectReferences(_result, source);
				return _result;

			}

			/// <summary>
			/// Redirect the references to specified object instead of itself, a copied instance.
			/// </summary>
			/// <param name="obj">Object.</param>
			/// <param name="replace">Replace.</param>
			private static void RedirectReferences(Object obj, Object replace){
				
				var _property = new SerializedObject(obj).GetIterator();
				while(_property.NextVisible(true)){

					if(SerializedPropertyType.ObjectReference != _property.propertyType) continue;
					if(obj != _property.objectReferenceValue) continue;

					_property.objectReferenceValue = replace;
					_property.serializedObject.ApplyModifiedProperties();

				}

			}

			#endregion


			#region Load Methods

			/// <summary>
			/// Get a deep copy from the stored groups with all loaded copied items sorted by labels.
			/// </summary>
			/// 
			/// <remarks>
			/// This invokes the <c>refresh</c> event if the stored groups are updated or force reloaded.
			/// </remarks>
			/// 
			/// <returns>The groups.</returns>
			/// <param name="force">If set to <c>true</c> force reload.</param>
			/// 
			public static Group[] Load(bool force = false){

				if(null == _groups || force || _groups.SelectMany((grp) => grp.items).Any((item) => null == item.copy)){
					refresh.Invoke();
					_groups = LoadGroups();
				}

				return _groups.Select((grp) => new Group(
					grp.type,
					grp.items.Select((item) => new Item(item.copy, item.note)).ToArray()
				)).ToArray();

			}

			/// <summary>
			/// Load the groups with all copies sorted by labels.
			/// </summary>
			/// <returns>The groups.</returns>
			private static Group[] LoadGroups(){

				#if WZ_LITE
				var _copies = Limiter.PrepareCopies(LoadSceneCopies());
				#else
				var _copies = LoadAssetCopies().Union(LoadSceneCopies());
				#endif

				var _items = _copies.Select((copy) => new Item(copy, Filer.GetNote(copy, true)));
				_items = _items.OrderBy((item) => item.label.text);

				var _group = _items.GroupBy((item) => item.copy.GetType());
				_group = _group.OrderBy((grp) => GetTypeOrder(grp.Key));

				return _group.Select((grp) => new Group(grp.Key, grp.ToArray())).ToArray();

			}
			
			/// <summary>
			/// Load all the copies in scene root container.
			/// </summary>
			/// <returns>The scene copies.</returns>
			private static Object[] LoadSceneCopies(){

				var _materials = Resources.FindObjectsOfTypeAll(typeof(Material));
				var _copies = _materials.Where((obj) => obj.name.StartsWith(_SCENE_ROOT));

				var _host = GetSceneHost(_SCENE_ROOT, false);
				if(null == _host) return _copies.ToArray();

				var _hosts = _host.transform.Cast<Transform>().SelectMany((parent) => parent.Cast<Transform>());
				var _components = _hosts.Select((host) => LoadSceneComponent(host, host.parent.name));

				return _components.Where((component) => null != component).Union(_copies).ToArray();

			}

			/// <summary>
			/// Load the copy of specified type at the scene host.
			/// </summary>
			/// <returns>The scene component copy.</returns>
			/// <param name="host">Host.</param>
			/// <param name="type">Type.</param>
			private static Object LoadSceneComponent(Transform host, string type){
				
				var _components = host.GetComponents<Component>().Where((component) => null != component);

				return _components.LastOrDefault((component) => GetTypeName(component.GetType()) == type);

			}

			/// <summary>
			/// Get an order <c>string</c> of given type for sorting.
			/// </summary>
			/// 
			/// <remarks>
			/// The types is order by categories below, then order by name:
			/// 	1. Transform, then sub classes of Transform.
			/// 	2. UnityEngine types.
			/// 	3. UnityEditor types.
			/// 	4. Other types.
			/// 	5. Material, then sub classes of Material.
			/// </remarks>
			/// 
			/// <returns>The order.</returns>
			/// <param name="type">Type.</param>
			/// 
			private static string GetTypeOrder(Type type){

				if(typeof(Transform) == type) return "1";
				if(typeof(Transform).IsAssignableFrom(type)) return "1." + type.Name;

				if(typeof(Material) == type) return "5";
				if(typeof(Material).IsAssignableFrom(type)) return "5." + type.Name;

				if(type.FullName.StartsWith("UnityEngine.")) return "2." + type.Name;
				if(type.FullName.StartsWith("UnityEditor.")) return "3." + type.Name;
				
				return "4." + type.Name;
				
			}

			#endregion


			#region Remove Methods

			/// <summary>
			/// Remove all copies of specified type, or all types if assign <c>null</c>.
			/// </summary>
			/// 
			/// <remarks>
			/// Optional to delay invoke, e.g., while using the copies to draw GUI.
			/// </remarks>
			/// 
			/// <param name="type">Copy type.</param>
			/// <param name="delay">If set to <c>true</c> delay.</param>
			/// 
			public static void RemoveAll(Type type, bool delay){
				
				Delete((null == type) ? _SCENE_ROOT : (_SCENE_ROOT + "/" + GetTypeName(type)), delay);

				#if !WZ_LITE
				Delete((null == type) ? _assetRoot : (_assetRoot + "/" + GetTypeName(type)), delay);
				#endif

			}

			/// <summary>
			/// Remove the specified copied object.
			/// </summary>
			/// 
			/// <remarks>
			/// Optional to delay invoke, e.g., while using the copy to draw GUI.
			/// </remarks>
			/// 
			/// <param name="copy">Copied object.</param>
			/// <param name="delay">If set to <c>true</c> delay.</param>
			/// 
			public static void Remove(Object copy, bool delay){
				Delete(GetObjectPath(copy), delay);
			}

			/// <summary>
			/// Delete the asset, folder, or scene host at specified path.
			/// Optional to delay invoke, e.g., while using the object in caller method.
			/// </summary>
			/// <param name="path">Asset or hierarchy path.</param>
			/// <param name="delay">If set to <c>true</c> delay.</param>
			private static void Delete(string path, bool delay){

				if(delay){
					EditorApplication.delayCall += () => Delete(path, false);
					return;
				}

				if(path.StartsWith(_SCENE_ROOT)) DeleteSceneCopies(path);
				#if !WZ_LITE
				else if(path.StartsWith(_assetRoot)) AssetDatabase.DeleteAsset(path);
				#endif
				else throw new InvalidOperationException("Clipboard can't remove external.");
				
				refresh.Invoke();

			}

			/// <summary>
			/// Delete the scene copies with the specified path or name.
			/// </summary>
			/// <param name="path">Path.</param>
			private static void DeleteSceneCopies(string path){

				var _materials = Resources.FindObjectsOfTypeAll<Material>().Where((obj) => obj.name.StartsWith(path));

				foreach(var _material in _materials.ToArray()) DestroyImmediate(_material);

				DestroyImmediate(GetSceneHost(path, false));

			}

			#endregion
			
			
			#if !WZ_LITE

			/// <summary>
			/// Deposit a scene copy to asset for next edit time, but any scene reference will be lost.
			/// </summary>
			/// 
			/// <remarks>
			/// Optional to delay remove origin copy while still using.
			/// </remarks>
			/// 
			/// <param name="copy">Copied object in scene.</param>
			/// <param name="delay">If set to <c>true</c> delay.</param>
			/// 
			public static void Deposit(Object copy, bool delay){
				
				if(!GetObjectPath(copy).StartsWith(_SCENE_ROOT))
					throw new InvalidOperationException("Clipboard can only move scene copy.");
				
				Object _asset;
				if(copy is Material) _asset = CreateAssetMaterial(copy as Material);
				else _asset = CreateAssetComponent(copy as Component);

				Filer.SetData(_asset, copy);
				Remove(copy, delay);
				
			}
			
			/// <summary>
			/// Create a copied <c>UnityEngine.Material</c> stored in asset.
			/// </summary>
			/// <returns>The asset material.</returns>
			/// <param name="source">Source material.</param>
			private static Material CreateAssetMaterial(Material source){
				
				var _result = Object.Instantiate(source);

				AssetDatabase.CreateAsset(_result, GenerateAssetPath(source, "mat"));
				AssetDatabase.SetLabels(_result, new []{"Ignore"});

				return _result;
				
			}
			
			/// <summary>
			/// Create a copied <c>UnityEngine.Component</c> prefab stored in asset.
			/// </summary>
			/// <returns>The asset component.</returns>
			/// <param name="source">Source component.</param>
			/*
			 * Disable the VerifySavingAssets flag while creating to avoid the Save Assets dialog.
			 */
			private static Component CreateAssetComponent(Component source){
				
				var _save = EditorPrefs.GetBool("VerifySavingAssets", false);
				EditorPrefs.SetBool("VerifySavingAssets", false);

				var _object = CreateComponent(source).gameObject;
				_object.hideFlags &= ~HideFlags.DontSaveInEditor;

				var _prefab = PrefabUtility.CreatePrefab(GenerateAssetPath(source, "prefab"), _object);
				AssetDatabase.SetLabels(_prefab, new []{"Ignore"});

				DestroyImmediate(_object);
				EditorPrefs.SetBool("VerifySavingAssets", _save);

				return _prefab.GetComponent(source.GetType());
				
			}
			
			/// <summary>
			/// Generate unique asset path in folder of source type with extension.
			/// Create the folder at the meantime.
			/// </summary>
			/// <returns>The path to save new asset copy from source.</returns>
			/// <param name="source">Source object.</param>
			/// <param name="extension">File extension.</param>
			/*
			 * It's must to create folder before using AssetDatabase.GenerateUniqueAssetPath().
			 */
			private static string GenerateAssetPath(Object source, string extension){
				
				var _folder = _assetRoot + "/" + GetTypeName(source.GetType());
				Directory.CreateDirectory(_folder);
				
				var _path = string.Format("{0}/{1}.{2}", _folder, source.GetInstanceID(), extension);
				return AssetDatabase.GenerateUniqueAssetPath(_path);
				
			}
			
			/// <summary>
			/// Load all the copies in asset root folder.
			/// </summary>
			/// <returns>The asset copies.</returns>
			/*
			 * Directory.GetDirectories and Directory.GetFiles return path relative to original.
			 * But it's not if from DirectoryInfo or FileInfo.
			 * Used to make sure to load asset with path relative to project folder.
			 */
			private static Object[] LoadAssetCopies(){

				if(!Directory.Exists(_assetRoot)) return new Object[0];

				var _paths = Directory.GetDirectories(_assetRoot);

				var _files = _paths.ToDictionary((path) => Path.GetFileName(path), (path) => Directory.GetFiles(path));

				var _copies = _files.SelectMany((pair) => pair.Value.Select((path) => LoadAssetCopy(path, pair.Key)));

				return _copies.Where((copy) => null != copy).ToArray();

			}

			/// <summary>
			/// Load the copy of specified type at the asset path.
			/// </summary>
			/// <returns>The asset copy.</returns>
			/// <param name="path">Path.</param>
			/// <param name="type">Type.</param>
			private static Object LoadAssetCopy(string path, string type){

				var _asset = AssetDatabase.LoadAssetAtPath<Object>(path);
				if(_asset is Material) return (GetTypeName(_asset.GetType()) == type) ? _asset : null;

				var _object = _asset as GameObject;
				if(null == _object) return null;

				var _components = _object.GetComponents<Component>().Where((component) => null != component);
				return _components.LastOrDefault((component) => GetTypeName(component.GetType()) == type);

			}

			/// <summary>
			/// Check if specified object has any reference to scene object.
			/// </summary>
			/// <returns><c>true</c>, if refer scene, <c>false</c> otherwise.</returns>
			/// <param name="obj">Object.</param>
			private static bool IsReferScene(Object obj){

				var _property = new SerializedObject(obj).GetIterator();
				while(_property.NextVisible(true)){

					if(SerializedPropertyType.ObjectReference != _property.propertyType) continue;

					var _object = _property.objectReferenceValue;
					if(null != _object && !AssetDatabase.Contains(_object)) return true;

				}

				return false;

			}

			#endif

		}
		
	}
	
}

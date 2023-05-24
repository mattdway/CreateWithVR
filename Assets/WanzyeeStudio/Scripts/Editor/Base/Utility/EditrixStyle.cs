
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace WanzyeeStudio.Editrix{
	
	/// <summary>
	/// Extend editor GUI style, and include some premade icons or styles.
	/// </summary>
	public static class EditrixStyle{

		#region Styles

		/// <summary>
		/// The splitter pixel texture, middle gray, 1 x 1.
		/// </summary>
		public static readonly Texture2D splitterPixel = (
			LoadIcon(new []{"0"}, 89, 116)
		);

		/// <summary>
		/// The background pixel texture, dark gray, 1 x 1.
		/// </summary>
		public static readonly Texture2D backgroundPixel = (
			LoadIcon(new []{"0"}, 40, 49)
		);

		/// <summary>
		/// The status bar style.
		/// </summary>
		/// 
		/// <remarks>
		/// Light color text for pro skin, otherwise dark, with darken background.
		/// </remarks>
		/// 
		public static readonly GUIStyle statusBar = new GUIStyle(){
			
			fixedHeight = 18,
			border = new RectOffset(0, 0, 2, 1),

			normal = new GUIStyleState(){
				background = LoadTexture(1, new byte[]{13, 13, 140}.Select((a) => new Color32(0, 0, 0, a)).ToArray()),
				textColor = EditorGUIUtility.isProSkin ? new Color(0.7f, 0.7f, 0.7f) : new Color(0.3f, 0.3f, 0.3f)
			}
			
		};

		#endregion


		#region Icons

		/// <summary>
		/// The icon represents to edit, a pencil, 12 x 12.
		/// </summary>
		public static readonly Texture2D editIcon = LoadIcon(new []{
			"        00  ",
			"       0 00 ",
			"      000 0 ",
			"     0 000  ",
			"    0   0   ",
			"   0   0    ",
			"  0   0     ",
			" 0   0      ",
			" 00 0       ",
			" 000        ",
			"            ",
			" 00 00 00 0 "
		});

		/// <summary>
		/// The icon represents to copy, overlapping notes, 12 x 12.
		/// </summary>
		public static readonly Texture2D copyIcon = LoadIcon(new []{
			"    00000   ",
			"    0   00  ",
			"        000 ",
			" 00000    0 ",
			" 0   00   0 ",
			" 0   000  0 ",
			" 0     0  0 ",
			" 0 000 0  0 ",
			" 0     0 00 ",
			" 0 000 0    ",
			" 0     0    ",
			" 0000000    "
		});

		/// <summary>
		/// The icon represents to remove, a moving out arrow, 12 x 12.
		/// </summary>
		public static readonly Texture2D removeIcon = LoadIcon(new []{
			"  00000000  ",
			" 0        0 ",
			" 0 0000   0 ",
			" 0      0   ",
			" 0 0000 00  ",
			" 0      000 ",
			" 0   0000000",
			" 0      000 ",
			" 0 0000 00  ",
			" 0      0   ",
			" 0        0 ",
			"  00000000  "
		});

		/// <summary>
		/// The icon represents to delete, a trash can, 12 x 12.
		/// </summary>
		public static readonly Texture2D deleteIcon = LoadIcon(new []{
			"   00       ",
			"   0 0 00   ",
			"    0 00 0  ",
			"     0 000  ",
			" 000000 0   ",
			" 00 0 00 0  ",
			"  0 0 0 0 0 ",
			"  0 0 0 000 ",
			"  0 0 0 0   ",
			"  0 0 0 0   ",
			"  0 0 0 0   ",
			"  0000000   "
		});
		
		/// <summary>
		/// The icon represents to aim, a front sight, 12 x 12.
		/// </summary>
		public static readonly Texture2D aimIcon = LoadIcon(new []{
			"     00     ",
			"   000000   ",
			"  0      0  ",
			" 0        0 ",
			" 0   00   0 ",
			"00  0  0  00",
			"00  0  0  00",
			" 0   00   0 ",
			" 0        0 ",
			"  0      0  ",
			"   000000   ",
			"     00     "
		});

		/// <summary>
		/// The icon represents a hierarchy, indent level lines, 12 x 12.
		/// </summary>
		public static readonly Texture2D hierarchyIcon = LoadIcon(new []{
			"            ",
			"            ",
			"00          ",
			"00  00000000",
			" 0          ",
			" 0          ",
			" 00  0000000",
			" 0          ",
			" 0          ",
			" 00  0000000",
			"            ",
			"            "
		});

		/// <summary>
		/// The icon represents a clipboard, 12 x 12.
		/// </summary>
		public static readonly Texture2D clipboardIcon = LoadIcon(new []{
			"     00     ",
			"    0  0    ",
			" 00 0  0 00 ",
			" 0   00   0 ",
			" 0 000000 0 ",
			" 0        0 ",
			" 0        0 ",
			" 0 000    0 ",
			" 0        0 ",
			" 0 00000  0 ",
			" 0        0 ",
			" 0000000000 "
		});

		/// <summary>
		/// The icon represents a bookmark, 12 x 12.
		/// </summary>
		public static readonly Texture2D bookmarkIcon = LoadIcon(new []{
			"    0000000 ",
			"   0     0 0",
			"  000    0 0",
			" 0   0   0 0",
			"0  0  0  000",
			"0 000 0  0 0",
			"0  0  0  0  ",
			" 0   0   0  ",
			"  000 0  0  ",
			"   0 0 0 0  ",
			"   00   00  ",
			"   0     0  "
		});

		/// <summary>
		/// The icon represents the Super Mario question mark, 12 x 12.
		/// </summary>
		public static readonly Texture2D questionIcon = LoadIcon(new []{
			"0          0",
			"   00000    ",
			"  00   00   ",
			"  00   00   ",
			"  00   00   ",
			"      000   ",
			"     00     ",
			"     00     ",
			"            ",
			"     00     ",
			"     00     ",
			"0          0"
		});

		#endregion


		#region Toggles

		/// <summary>
		/// The icon represents to link, a connected chain, 9 x 9.
		/// </summary>
		public static readonly Texture2D linkIcon = LoadIcon(new []{
			"     000 ",
			"    00 00",
			"        0",
			"  0000 00",
			" 00   00 ",
			"00 0000  ",
			"0        ",
			"00 00    ",
			" 000     "
		}, 116, 75);

		/// <summary>
		/// The icon represents to unlink, a broken chain, 9 x 9.
		/// </summary>
		public static readonly Texture2D unlinkIcon = LoadIcon(new []{
			"0    000 ",
			" 0  00 00",
			"  0 0   0",
			"       00",
			" 00   00 ",
			"00       ",
			"0   0 0  ",
			"00 00  0 ",
			" 000    0"
		}, 116, 75);

		#endregion


		#region Cursors

		/// <summary>
		/// The aux cursor represents a stop mark, 20 x 20.
		/// </summary>
		public static readonly Texture2D stopCursor = LoadCursor(new []{
			"       111111       ",
			"     1100000011     ",
			"    100000000001    ",
			"   10000111100001   ",
			"  100011    110001  ",
			" 1000001      10001 ",
			" 10010001      1001 ",
			"1000110001     10001",
			"1001  10001     1001",
			"1001   10001    1001",
			"1001    10001   1001",
			"1001     10001  1001",
			"10001     1000110001",
			" 1001      10001001 ",
			" 10001      1000001 ",
			"  100011     10001  ",
			"   10000111110001   ",
			"    100000000001    ",
			"     1100000011     ",
			"       111111       "
		});

		/// <summary>
		/// The aux cursor with a plus symbol, 19 x 15.
		/// </summary>
		public static readonly Texture2D copyCursor = LoadCursor(new []{
			"0101010101010      ",
			"1010101010101      ",
			"01         10      ",
			"10         01      ",
			"01      00000000000",
			"10      01111111110",
			"01      01111111110",
			"1010101001111011110",
			"0101010101111011110",
			"        01100000110",
			"        01111011110",
			"        01111011110",
			"        01111111110",
			"        01111111110",
			"        00000000000"
		});

		/// <summary>
		/// The aux cursor with an arrow, 19 x 15.
		/// </summary>
		public static readonly Texture2D linkCursor = LoadCursor(new []{
			"0101010101010      ",
			"1010101010101      ",
			"01         10      ",
			"10         01      ",
			"01      00000000000",
			"10      01111111110",
			"01      01110000110",
			"1010101001111000110",
			"0101010101110000110",
			"        01100010110",
			"        01100111110",
			"        01101111110",
			"        01110111110",
			"        01111111110",
			"        00000000000"
		});

		/// <summary>
		/// The aux cursor represents a dotted frame, 13 x 9.
		/// </summary>
		public static readonly Texture2D moveCursor = LoadCursor(new []{
			"0101010101010",
			"1010101010101",
			"01         10",
			"10         01",
			"01         10",
			"10         01",
			"01         10",
			"1010101010101",
			"0101010101010"
		});

		#endregion


		#region Methods

		/// <summary>
		/// Load a <c>UnityEngine.Texture2D</c> with color <c>pixels</c> for editor usage.
		/// </summary>
		/// 
		/// <remarks>
		/// Return the texture with the same pixels created by this if exists, otherwise create new one.
		/// </remarks>
		/// 
		/// <returns>The texture.</returns>
		/// <param name="width">Width.</param>
		/// <param name="pixels">Pixels.</param>
		/*
		 * Set as HideFlags.HideAndDontSave to avoid being destroyed by Unity after reload.
		 * Name the created texture by pixels hash for reusing.
		 */
		public static Texture2D LoadTexture(int width, Color32[] pixels){
			
			if(null == pixels || 0 == pixels.Length) throw new ArgumentException("The pixels can't be null or none.");
			if(0 == width || 0 != pixels.Length % width) throw new ArgumentException("The width doesn't match pixels.");

			var _hash = BitConverter.GetBytes(width);
			_hash = _hash.Concat(pixels.SelectMany((pixel) => new []{pixel.r, pixel.g, pixel.b, pixel.a})).ToArray();

			using(var _md5 = MD5.Create()) _hash = _md5.ComputeHash(_hash);
			var _name = typeof(EditrixStyle).FullName + Convert.ToBase64String(_hash);

			var _result = Resources.FindObjectsOfTypeAll<Texture2D>().FirstOrDefault((obj) => _name == obj.name);
			if(null != _result) return _result;

			_result = new Texture2D(width, pixels.Length / width, TextureFormat.ARGB32, false){ name = _name };
			_result.hideFlags = HideFlags.HideAndDontSave;

			_result.SetPixels32(pixels);
			_result.Apply();

			return _result;

		}

		/// <summary>
		/// Trick to load a <c>UnityEngine.Texture2D</c> by parsing pixel <c>string</c> array.
		/// </summary>
		/// 
		/// <remarks>
		/// Array length as texture height, element <c>string</c> length as width.
		/// Set each <c>char</c> pixel by <c>colors</c> map if existing, otherwise the <c>other</c> color.
		/// Return the texture with the same pixels created by this if exists, otherwise create new one.
		/// </remarks>
		/// 
		/// <returns>The texture.</returns>
		/// <param name="pixels">Pixel bits.</param>
		/// <param name="colors">Colors map.</param>
		/// <param name="other">Other.</param>
		/// 
		public static Texture2D LoadTexture(string[] pixels, Dictionary<char, Color32> colors, Color32 other){

			if(null == pixels || 0 == pixels.Length) throw new ArgumentException("The pixels can't be null or none.");
			if(pixels.Any((line) => null == line)) throw new ArgumentException("Each line of pixels must be set.");

			var _width = pixels[0].Length;
			if(pixels.Any((line) => line.Length != _width)) throw new ArgumentException("Line lengths must be same.");

			var _pixels = pixels.Reverse().SelectMany((line) => line);
			var _colors = _pixels.Select((pixel) => colors.ContainsKey(pixel) ? colors[pixel] : other).ToArray();

			return LoadTexture(_width, _colors);

		}

		/// <summary>
		/// Trick to load icon <c>UnityEngine.Texture2D</c> by parsing pixel <c>string</c> array.
		/// </summary>
		/// 
		/// <remarks>
		/// Array length as icon height, element <c>string</c> length as width.
		/// Any space char as transparent, others color light if pro skin, otherwise dark.
		/// Return the texture with the same pixels created by this if exists, otherwise create new one.
		/// </remarks>
		/// 
		/// <returns>The icon <c>UnityEngine.Texture2D</c>.</returns>
		/// <param name="pixels">Pixel bits.</param>
		/// <param name="pro">Grayscale for pro skin.</param>
		/// <param name="free">Grayscale for free skin.</param>
		/// 
		public static Texture2D LoadIcon(string[] pixels, byte pro = 196, byte free = 60){

			var _rgb = EditorGUIUtility.isProSkin ? pro : free;
			var _other = new Color32(_rgb, _rgb, _rgb, 255);

			return LoadTexture(pixels, new Dictionary<char, Color32>(){{' ', new Color32()}}, _other);
			
		}

		/// <summary>
		/// Trick to load cursor <c>UnityEngine.Texture2D</c> by parsing pixel <c>string</c> array.
		/// </summary>
		/// 
		/// <remarks>
		/// Array length as cursor height, element <c>string</c> length as width.
		/// Any '1' char as white, '0' as black, otherwise transparent.
		/// Return the texture with the same pixels created by this if exists, otherwise create new one.
		/// </remarks>
		/// 
		/// <returns>The cursor <c>UnityEngine.Texture2D</c>.</returns>
		/// <param name="pixels">Pixel bits.</param>
		/// 
		public static Texture2D LoadCursor(string[] pixels){

			var _colors = new Dictionary<char, Color32>(){{'1', (Color32)Color.white}, {'0', (Color32)Color.black}};

			return LoadTexture(pixels, _colors, new Color32());

		}

		#endregion

	}

}

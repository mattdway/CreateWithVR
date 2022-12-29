using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
    //The transform component of the marker's tip
    [SerializeField] private Transform _tip;
    //The size of the pen, in pixels
    [SerializeField] private int _penSize = 5;

    //The renderer component of the marker's tip
    private Renderer _renderer;
    //An array of the marker's color, repeated _penSize * _penSize times
    private Color[] _colors;
    //The height of the marker's tip
    private float _tipHeight;

    //The result of the raycast from the marker's tip
    private RaycastHit _touch;
    //The Whiteboard component of the object that the marker's tip is touching
    private Whiteboard _whiteboard;
    //The texture coordinates of the point where the marker's tip is touching the whiteboard
    //The texture coordinates of the point where the marker's tip was touching the whiteboard on the previous frame
    private Vector2 _touchPos, _lastTouchPos;
    //Whether the marker's tip was touching the whiteboard on the previous frame
    private bool _touchedLastFrame;
    //The rotation of the marker on the previous frame when the marker's tip was touching the whiteboard
    private Quaternion _lastTouchRot;

    //Start is called before the first frame update
    void Start()
    {
        //Get the renderer component of the marker's tip
        _renderer = _tip.GetComponent<Renderer>();
        //Set _colors to an array of the marker's color, repeated _penSize * _penSize times
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        //Set _tipHeight to the height of the marker's tip
        _tipHeight = _tip.localScale.y;
    }

    //Update is called once per frame
    void Update()
    {
        //Execute the Draw method
        Draw();
    }

    private void Draw()
    {
        //Cast a ray from the marker's tip in the direction the marker is facing
        if (Physics.Raycast(_tip.position, transform.forward, out _touch, _tipHeight))
        {
            //Debug.Log("Marker is Touching Something");
            //If the ray hits an object with the "Whiteboard" tag
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                //Debug.Log("Marker is Touching the Whiteboard");
                //Get the Whiteboard component of the object that the marker's tip is touching
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }

                //Get the texture coordinates of the point where the ray hit the whiteboard
                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                //Convert the texture coordinates to pixel coordinates on the whiteboard's texture
                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));

                //Checks if the x and y pixel coordinates are within the bounds of the whiteboard's texture. If either x or y is less than 0 or greater than the width or height of the whiteboard's texture, exits method
                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x) return;

                //Checks if the marker's tip was touching the whiteboard on the previous frame
                if (_touchedLastFrame)
                {
                    //Set a square of pixels on the whiteboard's texture to the color of the marker
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    //Interpolate between the current pixel coordinates and the pixel coordinates from the last frame to create a line between the two points
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        //Calculate the interpolated pixel coordinates
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        //Set a square of pixels on the whiteboard's texture to the color of the marker
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    //Debug.Log("Locking Rotation To " + _lastTouchRot);
                    //Lock the rotation of the marker to the rotation on the previous frame when the marker's tip was touching the whiteboard
                    transform.rotation = _lastTouchRot;

                    //Apply the changes to the whiteboard's texture
                    _whiteboard.texture.Apply();
                }

                //Update the last touch position and rotation
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                //Set _touchedLastFrame to true
                _touchedLastFrame = true;
                return;
            }
        }

        //If the marker's tip is not touching the whiteboard
        _whiteboard = null;
        //Set _touchedLastFrame to false
        _touchedLastFrame = false;
    }
}
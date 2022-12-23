using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardEraser: MonoBehaviour
{
    [SerializeField] private Transform _eraserBottom;
    [SerializeField] private int _eraserSize = 50;

    private Renderer _renderer;
    private Color[] _colors;
    private float _eraserHeight;

    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = _eraserBottom.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _eraserSize * _eraserSize).ToArray();
        _eraserHeight = _eraserBottom.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(_eraserBottom.position, transform.up, out _touch, _eraserHeight))
        {
            Debug.Log("Eraser is Touching Something");
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                Debug.Log("Eraser is Touching the Whiteboard");
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_eraserSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_eraserSize / 2));

                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x) return;

                if (_touchedLastFrame)
                {
                    _whiteboard.texture.SetPixels(x, y, _eraserSize, _eraserSize, _colors);
                    
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _eraserSize, _eraserSize, _colors);
                    }

                    Debug.Log("Locking Rotation To " + _lastTouchRot);
                    transform.rotation = _lastTouchRot;
                     
                    _whiteboard.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }
}
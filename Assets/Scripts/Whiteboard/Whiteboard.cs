using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    // The texture of the whiteboard
    public Texture2D texture;
    // The size of the whiteboard's texture, in pixels
    public Vector2 textureSize = new Vector2(2048,2048);

    // Start is called before the first frame update
    void Start()
    {
        // Get the renderer component of the GameObject
        var r = GetComponent<Renderer>();
        // Create a new texture with the specified size
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        // Set the GameObject's main texture to the newly created texture
        r.material.mainTexture = texture;
    }
}
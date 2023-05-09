using UnityEngine;
using UnityEngine.Video;

public class Change_Screen_MaterialOnVideoPlay : MonoBehaviour
{
    public Material screenVideoMaterial;
    private Material screenOriginalMaterial;
    private MeshRenderer screenMeshRenderer;
    private VideoPlayer videoPlayer;
    private bool isVideoPrepared = false;

    private void Awake()
    {
        screenMeshRenderer = GetComponent<MeshRenderer>();
        screenOriginalMaterial = screenMeshRenderer.material;
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.prepareCompleted += OnVideoPrepareCompleted;
    }

    private void OnVideoPrepareCompleted(VideoPlayer vp)
    {
        isVideoPrepared = true;
    }

    private void Update()
    {
        if (videoPlayer.isPlaying && isVideoPrepared)
        {
            if (screenMeshRenderer.material != screenVideoMaterial)
            {
                screenMeshRenderer.material = screenVideoMaterial;
            }
        }
        else if (!videoPlayer.isPlaying && isVideoPrepared)
        {
            if (screenMeshRenderer.material != screenOriginalMaterial)
            {
                screenMeshRenderer.material = screenOriginalMaterial;
            }
            isVideoPrepared = false;
        }
    }

    private void OnDestroy()
    {
        screenMeshRenderer.material = screenOriginalMaterial;
        videoPlayer.prepareCompleted -= OnVideoPrepareCompleted;
    }
}
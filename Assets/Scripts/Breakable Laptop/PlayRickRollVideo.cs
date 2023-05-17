﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class PlayRickRollVideo : MonoBehaviour
{
    [Tooltip("Whether video should play on load")]
    public bool playAtStart = false;

    [Tooltip("Material used for playing the video (Uses URP/Unlit by default)")]
    public Material videoMaterial = null;

    [Tooltip("List of video clips to pull from")]
    public List<VideoClip> videoClips = new List<VideoClip>();

    public VideoPlayer videoPlayer = null;
    private MeshRenderer meshRenderer = null;

    private readonly string shaderUsed = "Universal Render Pipeline/Unlit";

    private Material offMaterial = null;
    private int index = 0;

    public bool VideoIsPlaying = false;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoClips.Count > 0)
            videoPlayer.clip = videoClips[0];

        offMaterial = meshRenderer.material;

        videoMaterial = new Material(Shader.Find(shaderUsed));
        videoMaterial.color = Color.white;
    }


    private void Start()
    {
        if (playAtStart)
        {
            VideoIsPlaying = true;
            Play();
        }
        else
        {
            Stop();
        }
    }

    public void NextClip()
    {
        index = ++index % videoClips.Count;
        VideoIsPlaying = true;
        Play();
    }

    public void PreviousClip()
    {
        index = --index % videoClips.Count;
        VideoIsPlaying = true;
        Play();
    }

    public void RandomClip()
    {
        if (videoClips.Count > 0)
        {
            index = Random.Range(0, videoClips.Count);
            VideoIsPlaying = true;
            Play();
        }
    }

    public void PlayAtIndex(int value)
    {
        if (videoClips.Count > 0)
        {
            index = Mathf.Clamp(value, 0, videoClips.Count);
            VideoIsPlaying = true;
            Play();
        }
    }

    public void Play()
    {
        if (videoClips.Count > 0)
            videoPlayer.clip = videoClips[index];
        ApplyVideoMaterial();
        VideoIsPlaying = true;
        videoPlayer.Play();
    }

    public void Stop()
    {
        meshRenderer.material = offMaterial;
        videoPlayer.Stop();
    }

    public void TogglePlayStop()
    {
        bool isPlaying = !videoPlayer.isPlaying;
        SetPlay(isPlaying);
    }

    public void TogglePlayPause()
    {
        meshRenderer.material = videoMaterial;

        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            VideoIsPlaying = true;
            videoPlayer.Play();
    }

    public void SetPlay(bool value)
    {
        if (value)
        {
            VideoIsPlaying = true;
            Play();
        }
        else
        {
            Stop();
        }
    }

    private void ApplyVideoMaterial()
    {
        meshRenderer.material = videoMaterial;
    }

    private void OnValidate()
    {
            
        if (TryGetComponent(out VideoPlayer videoPlayer))
            videoPlayer.targetMaterialProperty = "_BaseMap";
    }
}
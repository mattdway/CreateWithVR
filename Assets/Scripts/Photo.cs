using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ApplyPhysics))]
public class Photo : MonoBehaviour
{
    public MeshRenderer imageRenderer = null;
    private Collider currentCollider = null;
    private ApplyPhysics applyPhysics = null;
    public GameObject photoPrefab = null;
    private Polaroid _photoInCamera;

    private void Awake()
    {
        currentCollider = GetComponent<Collider>();
        applyPhysics = GetComponent<ApplyPhysics>();
    }

    private void Start()
    {
        StartCoroutine(EjectOverSeconds(1.5f));
        _photoInCamera = GameObject.Find("PolaroidCamera").GetComponent<Polaroid>();
    }

    public IEnumerator EjectOverSeconds(float seconds)
    {
        applyPhysics.DisablePhysics();
        currentCollider.enabled = false;

        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            transform.position += transform.forward * Time.deltaTime * 0.1f;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        currentCollider.enabled = true;
    }

    public void SetImage(Texture2D texture)
    {
        imageRenderer.material.color = Color.white;
        imageRenderer.material.mainTexture = texture;
    }

    public void EnablePhysics()
    {
        applyPhysics.EnablePhysics();
        //transform.parent = null;
    }

    public void RemovePhotoFromCamera()
    {
        _photoInCamera.photoInCamera = false;
    }
}
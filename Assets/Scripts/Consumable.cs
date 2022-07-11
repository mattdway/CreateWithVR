using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] GameObject[] portions;
    [SerializeField] int index = 0;

    public bool IsFinished => index == portions.Length;

    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        SetVisuals();
    }

    void OnValidate()
    {
        SetVisuals();
    }

    [ContextMenu(itemName: "Consume")]

    public void Consume()
    {
        if (!IsFinished)
        {
            index++;
            SetVisuals();
            _audioSource.Play();
        }
    }

    void SetVisuals()
    {
        for (int i = 0; i < portions.Length; i++)
        {
            portions[i].SetActive(i == index);
        }
    }
}
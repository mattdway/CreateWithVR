using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Book_Page_Flip : MonoBehaviour
{
    [Tooltip("The maximum range")]
    public float maxInterval1 = 1.0f;
    public float maxInterval2 = 1.0f;
    [SerializeField] GameObject Canvas_Notebook_Brown_Pg1;
    [SerializeField] GameObject Canvas_Notebook_Brown_Pg2;
    [SerializeField] GameObject Canvas_Notebook_Brown_Pg3;
    [SerializeField] GameObject White_Background_Back_of_Page;

    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    public void Run()
    {
        //Start the coroutine we define below named BookFlipToPg2Coroutine.
        StartCoroutine(BookFlipToPg2Coroutine());
    }

    IEnumerator BookFlipToPg2Coroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(maxInterval1);

        //After we have waited maxInterval seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        Canvas_Notebook_Brown_Pg1.SetActive(false);
        White_Background_Back_of_Page.SetActive(true);
        Canvas_Notebook_Brown_Pg2.SetActive(true);
        audioData.UnPause();

        StartCoroutine(BookFlipToPg3Coroutine());
    }

    IEnumerator BookFlipToPg3Coroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(maxInterval2);

        //After we have waited maxInterval seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        Canvas_Notebook_Brown_Pg3.SetActive(true);
        White_Background_Back_of_Page.SetActive(true);
        Canvas_Notebook_Brown_Pg2.SetActive(false);
        audioData.UnPause();
    }
}
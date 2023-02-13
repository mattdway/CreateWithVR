using UnityEngine;

public class LighterSetTag : MonoBehaviour
{
    private bool isActivated = false;

    public void Activated()
    {
        //Debug.Log("SetTheTag Method Called");
        isActivated = true;
        //Debug.Log("isActivated = " + isActivated);
    }

    public void Deactivated()
    {
        //Debug.Log("UnsetTheTag Method Called");
        isActivated = false;
        //Debug.Log("isActivated = " + isActivated);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rug")
        {
            //Debug.Log("Tag match: " + collision.gameObject.tag);
            if (isActivated == true)
            {
                gameObject.tag = "Lighter";
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Rug")
        {
            //Debug.Log("Tag match: " + collision.gameObject.tag);
            gameObject.tag = "Untagged";
        }
    }

    public void JustSetTheTag()
    {
        gameObject.tag = "Lighter";
    }

    public void JustUnSetTheTag()
    {
        gameObject.tag = "Untagged";
    }
}
using UnityEngine;
using UnityEngine.UI;

public class Change_Teleportation_Settings_Toggle : MonoBehaviour
{
    GameObject inGameToggle;

    private void Start()
    {
        inGameToggle = GameObject.Find("Teleportation_Settings_Toggle");
    }

    //Use buttons linked to this
    public void ChangeValueToTrue()
    {
        inGameToggle.GetComponent<Toggle>().isOn = true;
    }

    //Use buttons linked to this
    public void ChangeValueToFalse()
    {
        inGameToggle.GetComponent<Toggle>().isOn = false;
    }

}
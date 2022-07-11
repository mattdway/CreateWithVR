using UnityEngine;
using UnityEngine.UI;

public class Change_Continuous_Turn_Settings_Toggle : MonoBehaviour
{
    GameObject inGameToggle_Continuous;
    GameObject inGameToggle_Snap;

    private void Start()
    {
        inGameToggle_Continuous = GameObject.Find("Continuous_Turn_Settings_Toggle");
        inGameToggle_Snap = GameObject.Find("Snap_Turn_Settings_Toggle");
    }

    //Use buttons linked to this
    public void ChangeValueToTrue()
    {
        inGameToggle_Continuous.GetComponent<Toggle>().isOn = true;
    }

    //Use buttons linked to this
    public void ChangeValueToFalse()
    {
        inGameToggle_Continuous.GetComponent<Toggle>().isOn = false;
    }
}
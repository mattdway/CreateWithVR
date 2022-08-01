using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(XRRig))]

public class RoomScalePlayerControllerFix : MonoBehaviour
{
    CharacterController _character;
    XRRig _xrRig;
    private bool wallCheck;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _xrRig = GetComponent<XRRig>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            // ReloadCurrentScene();
            wallCheck = true;
            Debug.Log(wallCheck);
        }
        else
        {
            wallCheck = false;
        }
    }

    void FixedUpdate()
    {
        _character.height = _xrRig.cameraInRigSpaceHeight + 0.15f;

        var centerPoint = transform.InverseTransformPoint(_xrRig.cameraGameObject.transform.position);
            _character.center = new Vector3(
            centerPoint.x,
            _character.height / 2 + _character.skinWidth, centerPoint.z);
        
        if(wallCheck==true)
        {
            _character.Move(new Vector3(0.001f, -0.001f, 0.001f));
            _character.Move(new Vector3(-0.001f, -0.001f, -0.001f));
        }
    }
}
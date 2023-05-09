using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class PhysicsButton_Open_Door: MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;
    public MotorizedFrontDoorOpen openDoor;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        GetComponent<AudioSource>().Play();
        //Debug.Log("Door Button Pressed");
        //Debug.Log(_isPressed);
    }

    private void Released()
    {
        //Debug.Log(_isPressed);
        if (_isPressed == true)
        {
            _isPressed = false;
            onReleased.Invoke();
            openDoor.OpenDaDoor();
            //Debug.Log("Door Button Released");
        }
    }
}
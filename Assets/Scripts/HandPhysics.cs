using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f;
    private Collider[] handColliders;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = true;
        }
    }

    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableHandCollider", delay);
    }

    public void DisableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > showNonPhysicalHandDistance)
        {
            nonPhysicalHand.enabled = true;
        }
        else
            nonPhysicalHand.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        // Rotation
        // Calculate the difference between the rotations of the target and the current object
        Quaternion roationDifference = target.rotation * Quaternion.Inverse(transform.rotation);

        // Convert the rotation difference to an angle and axis representation
        roationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        // Calculate the angular velocity needed to rotate by the rotation difference over a single frame
        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree *Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
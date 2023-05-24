using UnityEngine;

public class UnfreezeSwordPositionRotation : MonoBehaviour
{
    public void UnFreeze()
    {
        // Unfreeze position
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;

        // Unfreeze rotation
        rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationX;
        rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationY;
        rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
    }
}
using UnityEngine;

public class KeepRotationFixed : MonoBehaviour
{
    private Quaternion fixedRotation;

    void Start()
    {
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = fixedRotation;
    }
}

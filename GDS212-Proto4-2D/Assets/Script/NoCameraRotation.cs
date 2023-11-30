using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCameraRotation : MonoBehaviour
{
    private void LateUpdate()
    {
        // Reset the camera's rotation to match the empty GameObject's rotation
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}

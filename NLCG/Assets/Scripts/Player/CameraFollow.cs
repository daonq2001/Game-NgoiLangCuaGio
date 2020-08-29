using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cCamera = null;
    private Vector3 offset;

    void Update()
    {
        offset = gameObject.transform.position;
        offset.z = cCamera.transform.position.z;
        cCamera.transform.position = offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBone : MonoBehaviour
{
    public Transform bone;
    public float rotSpeed = 15;
    public bool working = false;

    /*private void Start()
    {
        rotSpeed = rotSpeed * Screen.width;
    }*/
    private void Update()
    {
        if (!working) return;

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y < Screen.height / 3)
            {
                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

                bone.RotateAround(Vector3.up, -rotX);
                bone.RotateAround(Vector3.forward, -rotY);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 5f, dragSpeed = 200f;
    void Update()
    {
        ProcessRotation();     
    }

    private void ProcessRotation()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(0, dragSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), 0));
            transform.Rotate(new Vector3(dragSpeed * Time.deltaTime * -Input.GetAxis("Mouse Y"), 0, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

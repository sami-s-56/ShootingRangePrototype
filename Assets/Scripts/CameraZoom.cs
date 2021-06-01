using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float scaleSpeed = 150f;
    private Camera thisCamera;
    private void Start()
    {
        thisCamera = GetComponent<Camera>();
    }
    void Update()
    {
        transform.LookAt(transform.parent);
        thisCamera.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * scaleSpeed;
        if(thisCamera.fieldOfView < 30)
        {
            thisCamera.fieldOfView = 30f;
        }else if(thisCamera.fieldOfView > 100)
        {
            thisCamera.fieldOfView = 100f;
        }
    }
}

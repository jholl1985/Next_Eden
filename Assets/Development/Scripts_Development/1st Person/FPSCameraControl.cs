using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraControl : MonoBehaviour {

    public float rotSpeed;

    public float yRot;

    public const float yAngleMin = -45.0f;
    public const float yAngleMax = 80.0f;

	// Use this for initialization
	void Start ()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
	
	// Update is called once per frame
	void Update ()
    {

        yRot -= Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, yAngleMin, yAngleMax);

        float rotY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(yRot, rotY, 0);
        
    }
}

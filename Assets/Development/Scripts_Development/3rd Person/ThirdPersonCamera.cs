using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public GameObject yPivot;
    public GameObject player;

    public float rotSpeed;

    public float yRot;

    public const float yAngleMin = -45.0f;
    public const float yAngleMax = 80.0f;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //3rd Person Cam follows the players position
        transform.position = player.transform.position;

        //Camera Rotations
        yRot -= Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, yAngleMin, yAngleMax);

        //Rotate with Mouse X with 3rd Person Cam
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, 0));

        //Rotate with Mouse Y with Cam Pivot
        float rotY = yPivot.transform.localEulerAngles.y;
        yPivot.transform.localEulerAngles = new Vector3(yRot, rotY, 0);

    }
}

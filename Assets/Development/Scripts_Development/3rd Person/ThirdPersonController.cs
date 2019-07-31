using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public float walkSpeed;
    public float runSpeed;

    public bool canJump;

    public GameObject camPosition;

    public GameObject player;
    private Rigidbody rbody;

   

    // Start is called before the first frame update
    void Start()
    {

        rbody = player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
    
    }

    public void PlayerMovement()
    {
        //Players Movement
        Vector3 forward = gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;

        rbody.velocity = (Input.GetAxis("Horizontal") * right * walkSpeed) + (Input.GetAxis("Vertical") * forward * walkSpeed) + new Vector3(0, rbody.velocity.y, 0);


        //Players Forward Rotates towards 3rd Person Cam Rotation when forward and right are active. If the player is moving the Camera Rotation turns the player.

        Vector3 camRotation = player.transform.eulerAngles;
        Vector3 rotation = camPosition.transform.eulerAngles;

        if (Input.GetKey(KeyCode.W))
        {

            player.transform.eulerAngles = new Vector3(camRotation.x, rotation.y, camRotation.z);

        }

        if (Input.GetKey(KeyCode.S))
        {

            player.transform.eulerAngles = new Vector3(camRotation.x, rotation.y, camRotation.z);

        }

        if (Input.GetKey(KeyCode.D))
        {

            player.transform.eulerAngles = new Vector3(camRotation.x, rotation.y, camRotation.z);

        }

        if (Input.GetKey(KeyCode.A))
        {

            player.transform.eulerAngles = new Vector3(camRotation.x, rotation.y, camRotation.z);

        }
    }
}

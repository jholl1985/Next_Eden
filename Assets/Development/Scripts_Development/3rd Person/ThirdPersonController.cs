using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public float walkSpeed;
    public float runSpeed;
    public float rotSpeed;
    public float jumpSpeed;

    public bool canJump;

    public GameObject camPosition;

    public GameObject player;
    private Rigidbody rbody;

    public GameObject playerMesh;

   

    // Start is called before the first frame update
    void Start()
    {

        rbody = player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
        PlayerJump();
    
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

    public void PlayerJump()
    {

        Ray jumpRay = new Ray();

        jumpRay.origin = playerMesh.transform.position;
        jumpRay.direction = playerMesh.transform.up * -1.0f;

        Debug.DrawLine(jumpRay.origin, jumpRay.origin + jumpRay.direction * 3.0f, Color.blue);

        RaycastHit jumpRayhit;

        if (Physics.Raycast(jumpRay, out jumpRayhit, 3.0f))
        {

            if (jumpRayhit.collider.tag == "Floor")
            {
                canJump = true;
            }
        }
        else
        {

            canJump = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) & canJump == true)
        {

            rbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);

        }

    }
}

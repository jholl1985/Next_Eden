using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSplayerMovement : MonoBehaviour {

    //Player Variables
    public float walkSpeed;
    public float runSpeed;
    public float rotSpeed;
    public float jumpSpeed;

    public bool canJump;

    public GameObject player;
    public GameObject playerMesh;

    private Rigidbody rbody;
    
    

	// Use this for initialization
	void Start ()
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

        //Player Movement
        Vector3 forward = gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;


        if (Input.GetKey(KeyCode.LeftShift))
        {

            rbody.velocity = (Input.GetAxis("Horizontal") * right * runSpeed) + (Input.GetAxis("Vertical") * forward * runSpeed) + new Vector3(0, rbody.velocity.y, 0);

        }

        else
        {

            rbody.velocity = (Input.GetAxis("Horizontal") * right * walkSpeed) + (Input.GetAxis("Vertical") * forward * walkSpeed) + new Vector3(0, rbody.velocity.y, 0);

        }

        //Player Rotation
        player.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, 0));

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

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {

            rbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);

        }

    }
}

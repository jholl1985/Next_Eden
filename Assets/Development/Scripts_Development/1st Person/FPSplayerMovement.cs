using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSplayerMovement : MonoBehaviour {

    //Player Variables
    public float walkSpeed;
    public float runSpeed;
    public float rotSpeed;

    public bool canJump;

    public GameObject player;

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
}

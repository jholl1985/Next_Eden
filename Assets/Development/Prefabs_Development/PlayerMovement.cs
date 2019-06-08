using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Objects and Assets
    private Rigidbody playerRigbody;
    private Animator playerAnimator;

    //Movement Variables
    public float walkSpeed;
    public float runSpeed;


    // Start is called before the first frame update
    void Start()
    {

        playerRigbody = GetComponent<Rigidbody>();

        if(playerRigbody == null)
        {
            Debug.LogError("No Rigidbody found");
        }
        else
        {
            Debug.Log("Rigidbody was found");
        }

        playerAnimator = GetComponent<Animator>();

        

    }

    // Update is called once per frame
    void Update()
    {

        //Player Movement
        Vector3 forward = gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;

        playerRigbody.velocity = (Input.GetAxis("Horizontal") * right * walkSpeed) + (Input.GetAxis("Vertical") * forward * walkSpeed) + new Vector3(0, playerRigbody.velocity.y, 0);

    }
}

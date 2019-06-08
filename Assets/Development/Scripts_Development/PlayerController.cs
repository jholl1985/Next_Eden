using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Players Objects and Assets
    private Rigidbody playerRbody;
    private Animator playerAnimator;

    //Players Movement Variables
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;

    //Bools
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {

        playerRbody = GetComponent<Rigidbody>();
        if (playerRbody == null)
        {
            Debug.LogError("Player's Rigidbody wasn't found");
        }
        else
        {
            Debug.Log("Player's Rigidbody was found");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        //Player Movement
        Vector3 forward = gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;

        playerRbody.velocity = (Input.GetAxis("Horizontal") * right * walkSpeed) + (Input.GetAxis("Vertical") * forward * walkSpeed) + new Vector3(0, playerRbody.velocity.y, 0);

        //RayCast Jumping
        Ray rJump = new Ray();

        rJump.origin = gameObject.transform.position;
        rJump.direction = gameObject.transform.up * -.5f;

        Debug.DrawLine(rJump.origin, rJump.origin + rJump.direction * 0.5f, Color.magenta);

        RaycastHit rJumpHit;
        if (Physics.Raycast(rJump, out rJumpHit, 0.5f))
        {
            if (rJumpHit.collider.tag == "Floor")
            {
                canJump = true;
                Debug.Log("CanJump");
            }
        }
        else
        {
            canJump = false;
            Debug.Log("Can't Jump");
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            playerRbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            Debug.Log("Has Jumped");
        }

    }
}

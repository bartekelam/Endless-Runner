using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    float maxSpeed = 5.0f;
    public bool isOnGround = false;
    bool doubleJump = true;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object s this script
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 10.0f;
        }
        else
        {
            maxSpeed = 5.0f;
        }

        //Create a 'float' that will be equal to the players horizontal input
        //float movementValueX = Input.GetAxis("Horizontal");
        float movementValueX = 1.0f;

        //Change the X velocity of the Rigibody2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX * maxSpeed, playerObject.velocity.y);

        //Check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.0000001f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.velocity = new Vector2(playerObject.velocity.x, 0f);
            playerObject.AddForce(new Vector2(0.0f, 400.0f));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            playerObject.velocity = new Vector2(playerObject.velocity.x, 0f);
            playerObject.AddForce(new Vector2(0.0f, 400.0f));
            doubleJump = false;
        }
        if (isOnGround)
        {
            doubleJump = true;
        }
    }
}

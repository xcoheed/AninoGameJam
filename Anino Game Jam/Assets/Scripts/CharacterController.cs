using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float movementSpeed = 0f;

    [Range(1, 10)]
    public float jumpVelocity;

    private float maximumSpeed = 8f;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (movementSpeed < maximumSpeed)
                movementSpeed += (Time.deltaTime);
        }
        else
        {
            movementSpeed = 5;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Flip(-1.0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Flip(1.0f);
        }

        if (Input.GetButtonDown("Jump"))
        {
            myRigidBody.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
    }

    private void Flip(float value)
    {
        this.transform.localScale = new Vector2(value, this.transform.localScale.y);
        movementSpeed = 5;
    }
}

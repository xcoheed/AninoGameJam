using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    [SerializeField] private float movementSpeed = 0f;

    [Range(1, 10)] public float jumpVelocity;

    [SerializeField] private Animator animator;

    private float maximumSpeed = 8f;
    private bool facingRight = false;

    void Start()
    {
        facingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);
        Flip(horizontal);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (movementSpeed < maximumSpeed)
                movementSpeed += (Time.deltaTime);
        }
        else
        {
            movementSpeed = 5;
        }

        if (Input.GetButtonDown("Jump"))
        {
            myRigidBody.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (horizontal != 0)
        {
            animator.Play("Player_Walk");
        }
        else
        {
            animator.Play("Player_Idle");
        }
    }

    private void Flip(float value)
    {
        /*this.transform.localScale = new Vector2(value, this.transform.localScale.y);
        movementSpeed = 5;*/
        if(value > 0 && !facingRight || value < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 characterScale = transform.localScale;
            characterScale.x *= -1;
            transform.localScale = characterScale;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    [SerializeField] private float movementSpeed = 0f;

    [Range(1, 10)] public float jumpVelocity;

    [SerializeField] private Animator animator;

    private float maximumSpeed = 8f;

    public bool isPlayerHit = false;

    public Animator GetEnemyAnimator
    {
        get { return animator; }
    }

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        animator.Play("Mummy_Running");
        animator.SetBool("Stunned", false);
    }

    void FixedUpdate()
    {
        if (!isPlayerHit)
        {
            myRigidBody.velocity = new Vector2(-1 * movementSpeed, myRigidBody.velocity.y);
        }
    }

    private void HandleMovement(float horizontal)
    {

    }

    private void Flip(float value)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collision.gameObject.tag == "Player")
        {
            animator.Play("Mummy_Attack");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}

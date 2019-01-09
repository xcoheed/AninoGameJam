using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    [SerializeField] private float movementSpeed = 0f;

    [Range(1, 10)] public float jumpVelocity;

    [SerializeField] private Animator animator;

    [SerializeField] private float thrust;

    [SerializeField] private float knockbackDuration;
    [SerializeField] private float stunDuration;

    [SerializeField] private ScrollingBackground[] scrollingItems;

    private float maximumSpeed = 8f;
    private bool facingRight = false;
    private bool isGrounded = true;

    private bool isLeft = false;
    private bool isRight = false;
    
    public bool IsPlayerGrounded
    {
        get { return isGrounded; }
        set { isGrounded = value; }
    }

    void Start()
    {
        facingRight = true;
        myRigidBody = this.GetComponent<Rigidbody2D>();

        animator.Play("Player_Walk");
        animator.SetBool("Stunned", false);

        Camera.main.orthographicSize = 9.0f / Screen.width * Screen.height / 2.0f;
    }

    void Update()
    {
        //animator.SetBool("grounded", isGrounded);

        //Debug.Log(isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //myRigidBody.velocity = Vector2.up * jumpVelocity;
        }

        if (!isGrounded)
        {
            //if (myRigidBody.velocity.y > 0)
            //    animator.Play("Player_Jump");
            //else
            //    animator.Play("Player_Fall");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float horizontal = Input.GetAxis("Horizontal");

        //HandleMovement(horizontal);
        //Flip(horizontal);

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    if (movementSpeed < maximumSpeed)
        //        movementSpeed += (Time.deltaTime);
        //}
        //else
        //{
        //    movementSpeed = 5;
        //}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //{
            //    if (movementSpeed < maximumSpeed)
            //        movementSpeed += (Time.deltaTime);
            //}
            Debug.Log("ASDSADASDSA");
        }
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (isGrounded)
        {
            if (horizontal != 0)
            {
                animator.Play("Player_Walk");
            }
            else if(myRigidBody.velocity.y <= 0)
            {
                //animator.Play("Player_Idle");
            }
        }
    }

    private void Flip(float value)
    {
        /*this.transform.localScale = new Vector2(value, this.transform.localScale.y);
        movementSpeed = 5;*/
        //if(value > 0 && !facingRight || value < 0 && facingRight)
        //{
        //    facingRight = !facingRight;

        //    Vector3 characterScale = transform.localScale;
        //    characterScale.x *= -1;
        //    transform.localScale = characterScale;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        //if (collider.name == "test")
        //{
        //    Vector3 contactPoint = collision.contacts[0].point;
        //    Vector3 center = collider.bounds.center;

        //    bool right = contactPoint.x > center.x;
        //    bool left = contactPoint.x < center.x;
        //    //bool top = contactPoint.y > center.y;
        //    //bool bottom = contactPoint.y < center.y;

        //    isLeft = left;
        //    isRight = right;
        //}

        if (collision.gameObject.tag == "Enemy" && animator.GetBool("Stunned") == false)
        {
            animator.Play("Player_Attack");
            animator.SetBool("Stunned", true);
            //Rigidbody2D enemy = collision.gameObject.GetComponent<Rigidbody2D>();
            //if (enemy != null)
            //{
            //    Vector2 difference = enemy.transform.position - transform.position;
            //    difference = difference.normalized * thrust;
            //    enemy.AddForce(difference, ForceMode2D.Impulse);
            //}

            StartCoroutine(Knockback(knockbackDuration, stunDuration, collision.gameObject));
        }
    }

    private IEnumerator Knockback(float kbDuration = 0f, float stunDuration = 0f, GameObject enemy = null)
    {
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
        Animator enemyAnimator = enemyController.GetEnemyAnimator;

        //MainGameManager.Instance.SlowDownScrolling();
        SlowDownScrolling();

        enemyAnimator.SetBool("Stunned", true);

        enemyController.isPlayerHit = true;
        yield return new WaitForSeconds(kbDuration);
        enemyRigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunDuration);
        enemyController.isPlayerHit = false;

        //MainGameManager.Instance.NormalScrolling();
        NormalScrolling();

        enemyAnimator.SetBool("Stunned", false);
        animator.SetBool("Stunned", false);

        // if enemy is still alive
        //enemyAnimator.Play("Mummy_Running");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //isLeft = false;
        //isRight = false;
    }

    public void SlowDownScrolling()
    {
        if (scrollingItems != null)
        {
            for (int i = 0; i < scrollingItems.Length; i++)
            {
                if (i == 0)
                {
                    scrollingItems[i].Speed = -0.1f;
                }
                else
                {
                    scrollingItems[i].Speed = -0.5f;
                }
            }
        }
    }

    public void NormalScrolling()
    {
        if (scrollingItems != null)
        {
            for (int i = 0; i < scrollingItems.Length; i++)
            {
                if (i == 0)
                {
                    scrollingItems[i].Speed = 0.5f;
                }
                else
                {
                    scrollingItems[i].Speed = 2.0f;
                }
            }
        }
    }
}

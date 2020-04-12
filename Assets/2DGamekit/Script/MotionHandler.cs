using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MotionHandler : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private float speed = 5.0f;
    private float groundCheckRadius = 0.2f;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    public float health = 4;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
        Crouching();
        if (transform.position.y < -5) Death();
    }

    private void FixedUpdate()
    {
        Walking();
        playerAnimator.SetBool(Tags.Grounded, Overlaping());
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 dimension = transform.localScale;
        transform.localScale = new Vector2(-1 * dimension.x, dimension.y);
    }

    void Pushing()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerAnimator.SetBool(Tags.Pushing, true);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            playerAnimator.SetBool(Tags.Pushing, false);
        }
    }

    void Walking()
    {
        float move = Input.GetAxis(Tags.Horizontal);
        if (!playerAnimator.GetBool(Tags.Crouching))
        {
            playerAnimator.SetFloat(Tags.HorizontalSpeed, Mathf.Abs(move));
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

        }
        else
        {
            playerAnimator.SetFloat(Tags.HorizontalSpeed, 0.0f);
            rb.velocity = new Vector2(0.0f,0.0f);
        }
        if (move < 0 & isFacingRight)
        {
            Flip();
        }
        else if (move > 0 & !isFacingRight)
        {
            Flip();
        }
    }

    void Jumping()
    {
        if (playerAnimator.GetBool(Tags.Grounded) & Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetBool(Tags.Grounded, false);
            rb.velocity = new Vector2(0.0f, 20.0f);
            playerAnimator.SetFloat(Tags.VerticalSpeed, Input.GetAxis(Tags.Jump));
        }
    }

    void Crouching()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerAnimator.SetBool(Tags.Crouching, !playerAnimator.GetBool(Tags.Crouching));
        }
    }

    void Death()
    {
        playerAnimator.SetBool(Tags.Dead, true);
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void Flip()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health == 0) Death();
        if(collision.collider.tag == "Enemy")
        {
            health -= 1;
        }
    }
}

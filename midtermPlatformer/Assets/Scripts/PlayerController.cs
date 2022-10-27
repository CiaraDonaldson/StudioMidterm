using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int collect = 0;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    private CapsuleCollider2D boxCollider;

    private bool canDash = true;
    public bool isDashing;
    private float dashingPower = 50f;
    private float dashingTime = .6f;
    private float dashingCooldown = 1f;
    private float wallJumpCooldown;


    public bool IsGrounded = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    public GameController GameController;
    public TextController TextController;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip boom;
    public AudioClip dash;
    public AudioClip death;
    public AudioClip fruit;
    public AudioClip choice;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<CapsuleCollider2D>();
        GameController.FindObjectOfType<GameController>();

       
    }

    void Update()
    {
    
        horizontal = Input.GetAxisRaw("Horizontal");

        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        Flip();



        if (rb.velocity.y == 0)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

        //Wall Jump
        if (sceneName == "Level 2" || GameController.TwoLevel == 1)
        {
            if (wallJumpCooldown > 0.2f)
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


                if (!IsGrounded  && OnWall())
                    {
                        rb.gravityScale = 0;
                        rb.velocity = Vector2.zero;
                    }
                    else
                    {
                        rb.gravityScale = 1;
                    }

                if (Input.GetKeyDown("space"))
                {
                    Jump();
                }


            }
            else
                {
                    wallJumpCooldown += Time.deltaTime;
                }
         }
        
        
        //Dash
        if (sceneName == "Level 1" || GameController.OneLevel == 1)
        {
           if(Input.GetKeyDown(KeyCode.W) && canDash)
            {
                audioSource.PlayOneShot(dash, 1);
                Debug.Log("Dash");
                StartCoroutine(Dash());
                anim.Play("Charged Animation");

            }
        }

      
    }
      
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (IsGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                Jump();

            }
        }


    }

    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    private void Jump()
    {
        if (IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.Play("Bolt Animation");
        }

        else if (OnWall() && IsGrounded)
        {
            if (horizontal == 0)
            {
                rb.velocity = new Vector3(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            rb.velocity = new Vector3(-Mathf.Sign(transform.localScale.x) * 3, 6);
        }
        wallJumpCooldown = 0;

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
       

        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        if (sceneName == "Level 3" || GameController.ThreeLevel == 1)
        {
            if (Input.GetKeyDown(KeyCode.S) && collider.gameObject.tag == "Wall" | collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Boom");
                audioSource.PlayOneShot(boom, 1);
                anim.Play("Hit-4 Animation");
                Destroy(collider.gameObject);
            }
        }
    }

 

    void OnTriggerStay2D(Collider2D collider)
    {
        if ((collider.gameObject.name == "Choice") && (Input.GetKeyDown(KeyCode.Q)))
        {
            Debug.Log("Level Chosen");
            audioSource.PlayOneShot(choice, 1);
            anim.Play("Hit-6 Animation");
            SceneManager.LoadScene("Level 1");
        }

        if ((collider.gameObject.name == "Choice (1)") && (Input.GetKeyDown(KeyCode.Q)))
        {
            Debug.Log("Level Chosen");
            anim.Play("Hit-6 Animation");
            SceneManager.LoadScene("Level 2");
        }

        if ((collider.gameObject.name == "Choice (2)") && (Input.GetKeyDown(KeyCode.Q)))
        {
            Debug.Log("Level Chosen");
            anim.Play("Hit-6 Animation");
            SceneManager.LoadScene("Level 3");
        }

        if (collider.gameObject.tag == "NextLevel")
        {
            anim.Play("Hit-6 Animation");
            SceneManager.LoadScene("the creature");
        }

        if ((collider.gameObject.tag == "Collectable"))
        {
            audioSource.Play(0);
            collect += 1;
            Debug.Log(collect);
            Destroy(collider.gameObject);
            HealthManager.instance.AddScore();
        }
        if ((collider.gameObject.name == "Fruit"))
        {
            audioSource.PlayOneShot(fruit, 1);
            GameController.addFruit();
            Destroy(collider.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "Enemy")
        {
            if (collect > 3)
            {
                collect -= 3;
                Debug.Log(collect);
                HealthManager.instance.MinusScore();
            }
            else if (collect == 3 || collect == 0 || collect == 2 || collect == 1)
            {
                audioSource.PlayOneShot(death, 1);
                Debug.Log("You Died");
                HealthManager.instance.MinusScore();
                GameController.RestartButton();
            }

        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private float dirX;
    private float movementSpeed = 7f;
    private float jumpSpeed = 7f;
    private Rigidbody2D rb;
    private SpriteRenderer sprRend;
    private BoxCollider2D col;
    public LayerMask jumpableGround;
    private Animator anim;
    //public Text tItems;
    //private int numItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        sprRend = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        // tItems = GetComponent<TMPro.TextMeshProUGUI>();

        //numItems = 0;
        //tItems.text = "Items: " + numItems;

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);

        if (dirX > 0)
        {
            sprRend.flipX = false;
        }
        else if (dirX < 0)
        {
            sprRend.flipX = true;
        }

        if (IsGrounded() && Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(0, jumpSpeed); //increment en 0 (no modificar velocitat x)
        }        

        updateAnimation();
    }

    void updateAnimation()
    {
        if (IsGrounded())
        {
            if (dirX > 0.01f)
            {
                anim.SetBool("run", true);
            }
            else if (dirX < 0.01f)
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
        }

        if (rb.velocity.y > 0.01f)
        {
            anim.SetBool("jump", true);
            anim.SetBool("fall", false);
        }
        else if (rb.velocity.y < 0.01f)
        {
            anim.SetBool("jump", false);
            anim.SetBool("fall", true);
        }
        else
        {
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        }
    }

    bool IsGrounded(){

        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround); //centre des meu col.lider, dimensions caixa, punt origen, direcci�, angle 
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //escena actual
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("itemOptions"))
        {
            SceneManager.LoadScene(2);
        }

        if (col.gameObject.CompareTag("itemPlay"))
        {
            SceneManager.LoadScene(3);
        }
    }
}

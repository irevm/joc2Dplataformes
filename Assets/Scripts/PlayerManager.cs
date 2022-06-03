using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private float dirX;
    private float movementSpeed = 7f;
    private float jumpSpeed = 7f;
    private Rigidbody2D rb;
    private SpriteRenderer sprRend;
    private BoxCollider2D col;
    public LayerMask jumpableGround;
    private Animator anim;
    public Text tItems;
    private int numItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        sprRend = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
       // tItems = GetComponent<TMPro.TextMeshProUGUI>();

        numItems = 0;
        tItems.text = "Items: " + numItems;

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
        
        if(dirX > 0){
            sprRend.flipX = false;
        } else if (dirX < 0) {
            sprRend.flipX = true;
        }

        if(IsGrounded() && Input.GetKeyDown("space")) {
            rb.velocity = new Vector2(0, jumpSpeed); //increment en 0 (no modificar velocitat x)
        }

        if(this.transform.position.y < -25f){
            KillPlayer();
        }

        updateAnimation();
    }

    void updateAnimation(){
        if (IsGrounded()){
            if(dirX > 0.01f){
                anim.SetBool("run", true);
            } else if (dirX < 0.01f) {
                anim.SetBool("run", true);
            } else {
                anim.SetBool("run", false);
            }
        }

        if(rb.velocity.y > 0.01f){
            anim.SetBool("jump", true);
            anim.SetBool("fall", false);
        } else if (rb.velocity.y < 0.01f){
            anim.SetBool("jump", false);
            anim.SetBool("fall", true);
        } else {
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.CompareTag("Item"))
        {
            numItems++;
            tItems.text = "Items: " + numItems;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Trap"))
        {
            KillPlayer();
            Destroy(col.gameObject);
        }

    }

    bool IsGrounded(){        

        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround); //centre des meu col.lider, dimensions caixa, punt origen, direcció, angle 
    }

    void KillPlayer(){
        anim.SetTrigger("dead");
        rb.bodyType = RigidbodyType2D.Static;
        Invoke("RestartLevel", 2f); //Nom funció a executar i temps d'espera
    }

    void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //escena actual
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Item")){
            //Incrementar comptador items
            numItems ++;
            tItems.text = "Items: " + numItems;
            //Recollir objecte
            col.GetComponent<Animator>().SetTrigger("collected");
            //Destruir objecte
            //Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Trap")){
            KillPlayer();
        }

        if (col.gameObject.CompareTag("Finish")){
            if(SceneManager.GetActiveScene().buildIndex<4){
                rb.bodyType = RigidbodyType2D.Static;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            } else {
                SceneManager.LoadScene(1);
            }
        }

    }
}

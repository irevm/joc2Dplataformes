using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float dirX;
    private float movementSpeed = 7f;
    private float jumpSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sprRend;
    private BoxCollider2D col;
    public LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
        
        if(dirX > 0.01f){
            sprRend.flipX = false;
        } else if (dirX < 0.01f) {
            sprRend.flipX = true;
        }

        //if(Input.GetKeyDown("space")){
        if(IsGrounded() && Input.GetKeyDown("space")) {
            rb.velocity = new Vector2(0, jumpSpeed); //increment en 0 (no modificar velocitat x)
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        

    }

    bool IsGrounded(){
        
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround); //centre des meu col.lider, dimensions caixa, punt origen, direcció, angle 
    }
}

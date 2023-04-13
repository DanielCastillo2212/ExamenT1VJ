using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    public EnemyCollider enemyCollider;
    public EnemyCollider enemyCollider2;
    public EnemyCollider enemyCollider3;
    // Start is called before the first frame update
    private int currentAnimation = 1;
    public int varVelocity = 5;
    //public float jumpForce = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = 1;
        var velocityY = rb.velocity.y;

        rb.velocity = new Vector2(0, velocityY);

        
         //Run
        if(Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(varVelocity, velocityY);
            Debug.Log(varVelocity);
            sr.flipX = false;
        }
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        /*
        //Jump
        if(Input.GetKeyDown(KeyCode.Space)){
            currentAnimation = 3;
            //rb.velocity = new Vector2(5, velocityY);
            rb.AddForce(new Vector2(0, jumpForce));
        }
        */
        //Roll
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 4;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 4;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        //Die
        if(enemyCollider.enemyColision){

            currentAnimation = 5;
        }
         if(enemyCollider2.enemyColision){

            currentAnimation = 5;
        }
         if(enemyCollider3.enemyColision){

            currentAnimation = 5;
        }

        

        animator.SetInteger("Estado", currentAnimation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que ha entrado en el trigger tiene la etiqueta "Potion", entonces lo hacemos desaparecer
        if (other.gameObject.CompareTag("Enemy"))
        {
            varVelocity+=5;
            //Debug.Log("OnTrigger");
            //other.gameObject.SetActive(false);
            //jumpEnemy = true;
        }
    }
}

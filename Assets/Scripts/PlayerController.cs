using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    
    public GameOverController gameOverController;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public Animator animator;
    public CapsuleCollider2D capsuleCollider;
    public Rigidbody2D rb;
    public int health = 3;
    public ScoreController scoreController;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        
        animator.SetFloat("xInput",Mathf.Abs(xInput));

        float yInput = Input.GetAxis("Vertical");

        animator.SetFloat("yInput", yInput);

       

        Vector3 scale = transform.localScale;
        if(xInput<0)
        {
            scale.x = -1f*Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        if (yInput > 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        

        transform.localScale = scale;
        transform.Translate(xInput*speed*Time.deltaTime, 0, 0);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, 1.1f);
            capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, 0.6f);
            animator.SetTrigger("CrouchTrigger");
      
            
        }
        if(Input.GetKeyUp(KeyCode.LeftControl)) {

            capsuleCollider.size = new Vector2(capsuleCollider.size.x, 2.2f);
            capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, 1f);


        }

    }

    public void PickUpKey()
    {

        scoreController.IncreaseScore(10);
    }

    public void DecreaseHealth()
    {
        health -= 1;

        if (health <= 0)
        {
            KillPlayer();
        }
    }
    public void KillPlayer()
    {

        gameOverController.PlayerDied();
        this.enabled = false;




    }

    
}

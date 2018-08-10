using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //movement var
    public float maxSpeed;
    float speedStop = 0f;
    float actualSpeed;

    //jumping var
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //for attacking 
    bool attack;
    public GameObject swordHit;
    public float weaponDamage;

    //for damage
    public bool canAttack;



    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
 
        facingRight = true;
        canAttack = true;
        
	}
	
	// Update is called once per frame
    void Update()
    {
        //Jump only when grounded
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
        //attacking
        if (Input.GetMouseButtonDown(0))
        {
            if (grounded == true)
            {
                myAnim.SetBool("playerAttack", true);
                attack = true;
                actualSpeed = speedStop;
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                Instantiate(swordHit);
            }
        }
        else
        {
            myAnim.SetBool("playerAttack", false);
            attack = false;
            actualSpeed = maxSpeed;
        }
    }
	void FixedUpdate () {
        //check if grounded - if no, then fall
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
     
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * actualSpeed, myRB.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip(); 
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
	}

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (canAttack == true)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Attackable"))
            {
            if (attack == true)
                {
                if (other.tag == "Enemy")
                    {
                        if (canAttack == true) {
                            enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                            hurtEnemy.addDamage(weaponDamage);
                        }
                        StartCoroutine(doAttack());
                    }
}
            }
        }
    }

    IEnumerator doAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}

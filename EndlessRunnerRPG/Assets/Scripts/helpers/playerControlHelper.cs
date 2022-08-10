using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlHelper : MonoBehaviour
{

    [Header ("variables")]
    //private Player_Base playerBase;
    [SerializeField] private LayerMask whatisTheGound;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    public float jumpVelocity;
    public Animator anim;

    private void Awake() {
        rigidbody2d= transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>(); 
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // jump handler
        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            
        }
    }

    private void FixedUpdate() {
        // move handler
        float moveSpeed = 1f;
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        if(Input.GetKey(KeyCode.LeftArrow))
        
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            transform.localScale = new Vector2(-1,1);
            anim.SetBool("running", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                transform.localScale = new Vector2(1,1);
                anim.SetBool("running", true);
            }                         
             
            
            else
            {
                //no key pressed
                rigidbody2d.velocity = new Vector2(0,rigidbody2d.velocity.y);
                rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
                anim.SetBool("running", false);
            }
        }

        private bool isGrounded()
        {
            float extraHeightText = 0.2f;
            float extraWidth = 0.09f;
            RaycastHit2D raycastHit =  Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, whatisTheGound);
            
            //debuging
            Color rayColor;
            if(raycastHit.collider !=null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            
            Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x,0), Vector2.down*(boxCollider2d.bounds.extents.y+extraHeightText), rayColor);
            Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x,0), Vector2.down*(boxCollider2d.bounds.extents.y+extraHeightText), rayColor);
            Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x,boxCollider2d.bounds.extents.y+extraHeightText), Vector2.right*(boxCollider2d.bounds.extents.x+ extraWidth), rayColor);
            
            Debug.Log(raycastHit.collider);
            return raycastHit.collider != null;
        }

    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerControl : MonoBehaviour
{


    [Header ("variables")]
        private float h;
        private float v;


    [Header ("basicReferences")]
    
    [SerializeField]private Rigidbody2D rb;

    [SerializeField] private Vector3 moveDirection ;
    [SerializeField] private Transform orientation ;

[Header ("movement")]
    [SerializeField]private int speed;

[Header ("gorundDetecion")]
[SerializeField] private Transform groundCheck;
[SerializeField] private float groundRadius;
[SerializeField] private LayerMask whatIsGround;
 [SerializeField]   private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, (int)whatIsGround);
        Debug.Log(isGrounded);

        h= Input.GetAxisRaw("Horizontal");
        v= Input.GetAxisRaw("Vertical");
        moveDirection = (orientation.forward * v + orientation.right * h).normalized;
        
    }
}

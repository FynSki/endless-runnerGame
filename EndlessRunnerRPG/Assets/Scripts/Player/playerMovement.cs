using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    public float speed =10f; 
    private Vector2 direction ;

    public LayerMask groundLayer;

    [Header ("Colision")]
    public bool onGorund = false; 
        
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Vertical"));
        onGorund = Physics2D.Raycast(transform.position, Vector2.down,0.6f, groundLayer); 
    }
}

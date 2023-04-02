using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float jumpSpeed;
    private float horizontalInput;
    private float forwardInput;
    
    private Rigidbody2D rb;
    [SerializeField]private float jumpTime;
    private bool amIJump;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
       

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        

        transform.Translate(Vector3.forward *Time.deltaTime*speed*forwardInput);

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && amIJump==false)
        {
            Jump();

        }


    }


    private void Jump()
    {
        Vector2 direction = transform.right;
        rb.velocity = Quaternion.Euler(0, 0, 90)*direction * jumpSpeed;
        Invoke("OffJump",jumpTime);
        amIJump = true;
    }
    private void OffJump()
    {
        amIJump = false;
        rb.velocity = new Vector2(0,0);
    }
}

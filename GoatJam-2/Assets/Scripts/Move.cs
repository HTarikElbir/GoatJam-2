using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed=200.0f;
    private float horizontalInput;
    private float forwardInput;

   /* private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;*/
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        

        transform.Translate(Vector3.forward *Time.deltaTime*speed*forwardInput);

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
       /* if (Input.GetKeyDown(KeyCode.Space)&& canDash)
        {
            StartCoroutine(Dash());
        }*/
        
    }
    /* private void FixedUpdate()
     {
         if (isDashing)
         {
             return;
         }
     }

     private IEnumerator Dash()
     {
         canDash = false;
         isDashing = true;
         float orginalGravity = rb.gravityScale;
         rb.gravityScale = 0f;
         rb.velocity = new Vector2(transform.localScale.x*dashingPower,0f);
         tr.emitting = true;
         yield return new WaitForSeconds(dashingTime);
         tr.emitting = false;
         rb.gravityScale = orginalGravity;
         isDashing = false;
         yield return new WaitForSeconds(dashingCooldown);
         canDash = true;

     }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private jumpSpeedParameter jump;
    [Serializable]
    public struct jumpSpeedParameter
    {
        public float speed;
        public float durationTime; //zıplama halinde geçen süresi;
        public float hangTime;// zıpladıktan sonra bekleme süresi;

    }

    private float jumpRelaodTime;  //zıplama halinde geçen süresi + zıpladıktan sonra bekleme süresi
    private Rigidbody2D rb;
    private Vector2 rightDirection=Vector2.right;
    private Vector2 leftDirection=Vector2.left;
    private Vector2 upDirection=Vector2.up;
    private Vector2 downDirection=Vector2.down;
    private Vector2 origineDot=Vector2.down;
    private Vector2 originePointVector=Vector2.zero;

    private bool jumpRelaodİsTrue=true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpRelaodTime=jump.durationTime+jump.hangTime;
    }

    void FixedUpdate()
    {
        CheckKeyState();

       
    }

    private void CheckKeyState()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&jumpRelaodİsTrue)
        {
            Jump(upDirection);

        }
        
        else if (Input.GetKeyDown(KeyCode.DownArrow)&&jumpRelaodİsTrue)
        {
            Jump(downDirection);

        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)&&jumpRelaodİsTrue)
        {
            Jump(rightDirection);


        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)&&jumpRelaodİsTrue)
        {
            Jump(leftDirection);

        }

    }


    private void Jump(Vector2 newDirection)
    {
        OnJump();
        rb.velocity=newDirection*jump.speed;
        OffJumpAfterTime();

    }
    private void StopJump()
    {
        rb.velocity=originePointVector;
    }




    private void OnJump()
    {
        jumpRelaodİsTrue=false;
       
    }
    private void OffJump()
    {
        jumpRelaodİsTrue=true;
        

    }
    private void OffJumpAfterTime()
    {
        
        Invoke("StopJump",jump.durationTime);
        Invoke("OffJump",(jumpRelaodTime));
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag=="Hunter")
        {
            
        }
    }

}

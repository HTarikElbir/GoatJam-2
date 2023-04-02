using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class HunterMovement : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private jumpSpeedParameter jump;
    [SerializeField] private float travelerSpeed;

    
    [Serializable]
    public struct jumpSpeedParameter
    {
        public float speed;
        public float addAmount;
        [Range(1,90)]
        public float callRateAddSpeedFunction;
        public float startAddSpeedAfterTime;
        public float durationTime; //zıplama halinde geçen süresi;
        public float hangTime;// zıpladıktan sonra bekleme süresi;
        public float distance;// nekadar yakındayken zıplasın;

        [Range(1,90)]
        [SerializeField] public float İnsensitivity;// zıplama hassasiyeti

    }
    //jumpspeed eklemeyi unutma
    

    private float JumprelaodTime;  //zıplama halinde geçen süresi + zıpladıktan sonra bekleme süresi
    private Rigidbody2D rb;
    private Vector2 rightDirection=Vector2.right;
    private Vector2 origineDot=Vector2.down;
    private Vector2 originePointVector=Vector2.zero;
    private bool jumpRelaodİsTrue;
    private bool amIjumping;
    private float borderMaxX,borderminX,bordermaxY,borderminY;
    private float angle;
    private float theTimer;
    private bool doItouch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target=GameObject.FindGameObjectWithTag("Player");
        JumprelaodTime=jump.durationTime+jump.hangTime;
        jumpRelaodİsTrue=true;
        Invoke("StartAddSpeed",jump.startAddSpeedAfterTime);
        borderMaxX=GameController.GetMaxX();
        borderminX=GameController.GetMinX();
        bordermaxY=GameController.GetMaxY();
        borderminY=GameController.GetMinY();

   

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="wall")
        {
            doItouch=true;
            
        }
        
    }

    private void FixedUpdate() 
    {

        if(CanIJump()==true)
        {
            Jump(DirectionToPlayer());
            
        }
        else if(amIjumping==false)
        {
            if(jumpRelaodİsTrue==false)
            {}//do nothing
            else if(jumpRelaodİsTrue==true)
            {
                Traveler();
            }
            

        }
    }
    public void Traveler()
    {
        if(doItouch==true)
        {
            Invoke("OffTouch",4);
            rb.velocity=(travelerSpeed*(originePointVector-(Vector2)transform.position).normalized);
            rightDirection=Vector2.right;
            angle = UnityEngine.Random.Range(-90, 90);
            rightDirection = Quaternion.Euler(0, 0, angle) * rightDirection;

        }
        else if(doItouch==false)
        {
            theTimer -= Time.deltaTime;
            if (theTimer <= 0)
            {

        
            
                theTimer++;

                // Önceki yönün 90 derece içerisinden rastgele bir yön seç
                angle = UnityEngine.Random.Range(-90, 90);
                rightDirection = Quaternion.Euler(0, 0, angle) * rightDirection;

            
            }

            // Oyun nesnesini seçilen yönde hareket ettir
         
            rb.velocity=(Vector3)rightDirection * travelerSpeed;

        }

        

    
    }

    
    private bool CanIJump()
    {
        if(CheckDistance()&&jumpRelaodİsTrue==true) return true;
        else return false;

    }
    private bool CheckDistance()
    {
        if(Vector2.Distance(target.transform.position,gameObject.transform.position)<jump.distance) return true;
        else return false;
        

    }


    private void Jump(Vector2 newDirection)
    {
        OnJump();
        float randomX = UnityEngine.Random.Range(jump.İnsensitivity,-jump.İnsensitivity);
        newDirection = Quaternion.Euler(0, 0, randomX) * newDirection;
        rb.velocity=newDirection*jump.speed;
        OffJumpAfterTime();

    }
    private void StopJump()
    {
        rb.velocity=originePointVector;
        amIjumping=false;
    }




    private void OnJump()
    {

        jumpRelaodİsTrue=false;
        amIjumping=true;
       
    }
    private void OffJump()
    {

        jumpRelaodİsTrue=true;
        

    }
    private void OffJumpAfterTime()
    {
        
        Invoke("StopJump",jump.durationTime);
        //zıplar ve bir süre bekler
        Invoke("OffJump",(JumprelaodTime));
        
    }

    private Vector2 DirectionToPlayer()
    {
        
        Vector2 unitVector = (target.transform.position - gameObject.transform.position).normalized;
        return unitVector;

    }
    private void StartAddSpeed()
    {
        InvokeRepeating("AddSpeed",0,jump.callRateAddSpeedFunction);
    }
    private void AddSpeed()
    {
        jump.speed=jump.addAmount+jump.speed;
       
    }
    private void OffTouch()
    {
        doItouch=false;
    }
}

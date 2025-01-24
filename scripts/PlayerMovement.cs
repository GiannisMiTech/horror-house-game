using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerMovement: MonoBehaviour
{
  
   public float moveSpeed; //=13
   public float groundDrag;
   public float playerHeight;
   public Transform orientation;
   float horizontalInput;
    float verticalInput;
    Rigidbody rb;
    Vector3  moveDirection;
    public float airMultiplier; //=2
   private Vector3 jump;
   public float jumph = 2;
   public float jumpForce = 1;
   private bool onGround =true;
    public AudioSource footstepsSound , jumpsound ,Running;
 
    



    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        jump = new Vector3(0f , jumph , 0f);
    }

    
    
    // Update is called once per frame
    void Update()
    {
      if(!PauseMenu.paused){
      MyInput();
      SpeedControl();
      FootSteps();

      }
    }
    
       private void FixedUpdate(){
        if(!PauseMenu.paused){
        MovePlayer(); 
         Pjump(); 
        }
       } 

      
       private void MyInput(){
       horizontalInput = Input.GetAxisRaw("Horizontal");
       verticalInput = Input.GetAxisRaw("Vertical");
       }

       private void MovePlayer(){
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;  
         if(Input.GetKey(KeyCode.Z)&& (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) )&& onGround == true )
         {
          moveSpeed = 19;
          rb.AddForce(moveDirection.normalized * moveSpeed *5f , ForceMode.Force);
          footstepsSound.enabled = false;
          Running.enabled =true;

            }else
           {
            moveSpeed = 15;
            rb.AddForce(moveDirection.normalized * moveSpeed *5f , ForceMode.Force);
            Running.enabled=false;
           }
        
           
         }

        private void SpeedControl(){
        Vector3 flatVel =new Vector3(rb.velocity.x , 1f , rb.velocity.z);

        if(flatVel.magnitude > moveSpeed){

            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
      }

     
     
       private void Pjump(){
       
        if(onGround == true)
        {
        if(Input.GetKey(KeyCode.Space))
        {
         rb.AddForce( jump * jumpForce *9, ForceMode.Impulse);
         rb.AddForce( moveDirection.normalized * airMultiplier, ForceMode.Impulse);
         onGround = false;
        } 
          if(Input.GetKey(KeyCode.Space) && onGround == false){
          jumpsound.Play();
          
          }
          else 
          {
           jumpsound.Pause();
          }
        }
}
          private void OnCollisionEnter(Collision col)
          {
            onGround = true;
          }
          
          private void FootSteps()
          {
           if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) )&& onGround == true)
            {
                footstepsSound.enabled = true;
            }
        
           else
           {
            footstepsSound.enabled = false;
           }

          }

      
        

         
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
 public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;
  
    public bool on;
    public bool off;
   [SerializeField] public float sensX;
    [SerializeField]public float sensY;
    public Transform orientation;
    float xRotation;
     float yRotation;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
          off = true;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
         float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation , -90f , 90f);

       transform.rotation = Quaternion.Euler(xRotation , yRotation , 0);
       orientation.rotation = Quaternion.Euler(0 , yRotation , 0);
    

     
     

       if(off && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;

        }
        else if (on && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(false);
             turnOff.Play();
            off = true;
            on = true;
        }
        
       
    }
    
}

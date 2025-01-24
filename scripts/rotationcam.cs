using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationcam : MonoBehaviour   //playercamera
{
    /* private float mousesen = 3.0f; //sensitivity
    private float rotationY , rotationX;
    [SerializeField]private Transform target;
    [SerializeField]private float distanceFromTarget = 3.0f;
    private Vector3 currentRotation;
    private Vector3 smoothVel = Vector3.zero;
    [SerializeField]private float smoothTime;
*/


public float sensx , sensy;
public Transform orientation; //orientation

float xrot;
float yrot;

    // Start is called before the first frame update

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensx;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensy;

        yrot += mousex;
        xrot -= mousey;
        xrot = Mathf.Clamp(xrot , -90f , 90f);

       transform.rotation = Quaternion.Euler(xrot , yrot , 0);
       orientation.rotation = Quaternion.Euler(0 , yrot , 0);











        /*  float mousex = Input.GetAxis("Mouse X") * mousesen;
           float mousey = Input.GetAxis("Mouse Y") * mousesen;
          // Debug.Log(mousex);
           rotationY += mousex;
           rotationX += mousey;

           rotationX = Mathf.Clamp(rotationX , -10 , 10);

           Vector3 nextRotation = new Vector3(rotationX , rotationY);

           currentRotation = Vector3.SmoothDamp(currentRotation , nextRotation , ref smoothVel , smoothTime);
           
           transform.localEulerAngles = currentRotation;
           transform.position = target.position - transform.forward * distanceFromTarget;*/



    }
}

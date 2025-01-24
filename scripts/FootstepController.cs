using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
   
public GameObject footstep;

      void Start(){
    footstep.SetActive(false);
     }
     void Update()
    {
        if(Input.GetKey("w") || Input.GetKeyDown("a")|| Input.GetKeyDown("d")|| Input.GetKeyDown("s"))
        {
            footsteps();
        }
        else if((Input.GetKeyUp("w") || Input.GetKeyUp("a")|| Input.GetKeyUp("d")|| Input.GetKeyUp("s"))) 
        {
            Stopfootsteps();
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }
     void Stopfootsteps()
     {
        footstep.SetActive(false);
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorEscena : MonoBehaviour
{

 
    public void Update(){
      if (Input.GetKey("escape"))
        {
            Debug.Log("salio");
            Application.Quit();
             
        }

        if(Input.anyKeyDown && !(Input.GetKey("escape")))
             {
               Debug.Log("cambio escena");
                 SceneManager.LoadScene("Main Scene");
      
             }
     
    
   }
   


   
}

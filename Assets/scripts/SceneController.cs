 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    

    public void goToMainScene(){

         SceneManager.LoadScene (sceneName:"MainGame");
    }


    public void goToStartScene(){

         SceneManager.LoadScene (sceneName:"StartMenu");
    }

     public void goToGameOverScene(){

         SceneManager.LoadScene (sceneName:"GameOver");
    }


   
}

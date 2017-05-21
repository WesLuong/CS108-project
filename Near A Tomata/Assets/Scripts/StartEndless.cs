using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndless : MonoBehaviour {
 
    private void OnMouseDown()
    {   
        if(this.name == "Endless")
        {
            //Application.LoadLevel("Main");
            SceneManager.LoadScene("Main");
        }
        else if(this.name == "Quit")
        {
            Application.Quit();
        }

    }
}

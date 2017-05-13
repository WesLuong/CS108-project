using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndless : MonoBehaviour {
 
    private void OnMouseDown()
    {   
        if(this.name == "Endless")
        {
            Application.LoadLevel("Main");
        }
        else if(this.name == "Quit")
        {
            Application.Quit();
        }

    }
}

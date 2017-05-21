using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    
    private void Start() //code executed on first frame object instantiated
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

    }
}

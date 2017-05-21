using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour {

    private float[] zValues = {-10, 10, -8, 8,};
    private void Start() //code executed on first frame object instantiated
    {
        GetComponent<Rigidbody>().velocity = transform.forward * zValues[Random.Range(0, zValues.Length)];

    }
}

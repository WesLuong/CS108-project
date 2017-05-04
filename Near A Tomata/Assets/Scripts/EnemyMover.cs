using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {    
        if (player == null)
        {
            return;
        }
        else
        {
            //transform.LookAt(new Vector3(lookAt.x, transform.position.y, lookAt.z));
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereWepController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    public float delay;
    private float nextFire;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
        if (Time.time > nextFire && Player != null)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 45, 0)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 90, 0)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 135, 0)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 225, 0)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 270, 0)));
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 315, 0)));
        }
    }
}

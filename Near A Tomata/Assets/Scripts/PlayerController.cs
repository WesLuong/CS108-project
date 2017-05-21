using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private Camera mainCamera;
    private Vector3 mouseWorldPosition;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundplane.Raycast(cameraRay, out rayLength))
        {
           Vector3 pointToLook = cameraRay.GetPoint(rayLength);
           transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        
        
        //float h = Input.mousePosition.x - Screen.width / 2;
       // float v = Input.mousePosition.y - Screen.height / 2;
        //float angle = -Mathf.Atan2(v, h) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(-90, 0, 245);
        

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        
    }
}

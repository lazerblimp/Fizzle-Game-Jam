using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public float speed = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidBody.AddForce(transform.forward * speed);
        }
	}
}

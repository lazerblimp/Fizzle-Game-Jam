using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public float speed = 100f;
    public float disappear = 0.5f;
    private AudioSource audioSource;
    private float timeBtwShots;
    public float startTimeBtwShots;
    // Use this for initialization
    void Start () 
    {
        audioSource = GetComponent<AudioSource>();
        timeBtwShots = startTimeBtwShots;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && timeBtwShots <= 0)
        {
            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidBody.AddForce(transform.forward * speed);
            audioSource.Play();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        disappear -= Time.deltaTime;

        if(disappear <= 0)
        {
            Destroy(gameObject);
        }
	}
}

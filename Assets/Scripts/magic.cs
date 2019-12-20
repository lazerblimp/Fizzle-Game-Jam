using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour {

    public float disappear = 0.5f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        disappear -= Time.deltaTime;

        

        if(disappear <= 0.0f)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Debug.Log("Hit Wall");
        }
    }
}

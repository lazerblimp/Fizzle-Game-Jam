using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnemy : MonoBehaviour
{ 
    

    private float timeBtwShots;
    public float startTimeBtwShots;
    private AudioSource audioSource;
    private Transform player;
    public GameObject underCircle;
    public Transform underCircleSpawn;
    private GameObject currentUnderCircleEffect;
    public GameObject circle;
    public Transform circleSpawn;
    private GameObject currentCircleEffect;



    public PlayerMovement Freeze;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        Freeze = g.GetComponent<PlayerMovement>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeBtwShots == startTimeBtwShots)
        {
            audioSource.Play();
            currentUnderCircleEffect = Instantiate(underCircle, underCircleSpawn.position, Quaternion.identity);
            currentCircleEffect = Instantiate(circle, circleSpawn.position, Quaternion.identity);
        }
        if (timeBtwShots <= 0)
        {
            Debug.Log("fire");
            Freeze.freeze = true;
            timeBtwShots = startTimeBtwShots;
            Destroy(currentUnderCircleEffect);
            Destroy(currentCircleEffect);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        

        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerShot"))
        {
            timeBtwShots = startTimeBtwShots;
        }
    }
}
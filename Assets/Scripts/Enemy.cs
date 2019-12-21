using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float firingDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject circle;
    public GameObject underCircle;
    public GameObject projectile;
    private Transform player;
    public Transform circleSpawn;
    public Transform underCircleSpawn;
    public float Speed;

    private Transform currentWaypoint;
    public GameObject pointOne;
    public GameObject pointTwo;
    private GameObject currentCircleEffect;
    private GameObject currentUnderCircleEffect;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;


        currentWaypoint = pointOne.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < firingDistance)
        {
            transform.LookAt(player.position);
            if (timeBtwShots <= 0)
            {
                Debug.Log("fire");
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                if (timeBtwShots == startTimeBtwShots)
                {
                    currentCircleEffect = Instantiate(circle, circleSpawn.position, Quaternion.identity);
                    currentUnderCircleEffect = Instantiate(underCircle, underCircleSpawn.position, Quaternion.identity);
                }
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            Destroy(currentCircleEffect);
            Destroy(currentUnderCircleEffect);
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Speed *Time.deltaTime);

            if(transform.position.x == currentWaypoint.position.x && transform.position.y == currentWaypoint.position.y && transform.position.z == currentWaypoint.position.z)
            {
                if(currentWaypoint == pointOne.transform)
                {
                    currentWaypoint = pointTwo.transform;
                }
                else
                {
                    currentWaypoint = pointOne.transform;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerShot"))
        {
            timeBtwShots = startTimeBtwShots;
            Destroy(currentCircleEffect);
            Destroy(currentUnderCircleEffect);
        }
    }
}

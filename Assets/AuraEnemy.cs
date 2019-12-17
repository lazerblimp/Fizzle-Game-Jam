using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraEnemy : MonoBehaviour
{
    public float AuraDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Transform player;

    public float Speed;

    private Transform currentWaypoint;
    public GameObject pointOne;
    public GameObject pointTwo;

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
        if (Vector3.Distance(transform.position, player.position) < AuraDistance)
        {
            if (timeBtwShots <= 0)
            {
                Debug.Log("fire");
                timeBtwShots = startTimeBtwShots;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            timeBtwShots = startTimeBtwShots;

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Speed * Time.deltaTime);

            if (transform.position.x == currentWaypoint.position.x && transform.position.y == currentWaypoint.position.y && transform.position.z == currentWaypoint.position.z)
            {
                if (currentWaypoint == pointOne.transform)
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
}

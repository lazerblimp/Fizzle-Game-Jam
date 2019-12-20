using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraEnemy : MonoBehaviour
{
    public float AuraDistance;
    private AudioSource audioSource;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject lightning;
    public GameObject cloud;
    public GameObject circle;
    public GameObject underCircle;
    public Transform lightningSpawn;
    public Transform cloudSpawn;
    public Transform circleSpawn;
    public Transform underCircleSpawn;
    public DestroyLightningAnimation vanish;
    private Transform player;

    public float Speed;

    [SerializeField]
    private Transform currentWaypoint;
    public GameObject pointOne;
    public GameObject pointTwo;

    private GameObject currentLightningEffect;
    private GameObject currentCloudEffect;
    private GameObject currentCircleEffect;
    private GameObject currentUnderCircleEffect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

        currentWaypoint = pointOne.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < AuraDistance)
        {
            transform.LookAt(player.position);
            if (timeBtwShots <= 0)
            {
                Debug.Log("fire");
                timeBtwShots = startTimeBtwShots;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                if(timeBtwShots == startTimeBtwShots)
                {
                    audioSource.Play();
                    currentLightningEffect = Instantiate(lightning, lightningSpawn.position, Quaternion.identity);
                    currentCloudEffect = Instantiate(cloud, cloudSpawn.position, Quaternion.identity);
                    currentCircleEffect = Instantiate(circle, circleSpawn.position, Quaternion.identity);
                    currentUnderCircleEffect = Instantiate(underCircle, underCircleSpawn.position, Quaternion.identity);
                }
                timeBtwShots -= Time.deltaTime;

            }
        }
        else
        {
            timeBtwShots = startTimeBtwShots;
            Destroy(currentLightningEffect);
            Destroy(currentCloudEffect);
            Destroy(currentCircleEffect);
            Destroy(currentUnderCircleEffect);
            audioSource.Stop();
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Speed * Time.deltaTime);
            transform.LookAt(currentWaypoint.position);
            if (transform.position.x == currentWaypoint.position.x && transform.position.y == currentWaypoint.position.y && transform.position.z == currentWaypoint.position.z)
            {
                Debug.Log("Destination reached!");
                if (currentWaypoint == pointOne.transform)
                {
                    Debug.Log("Go to Point Two");
                    currentWaypoint = pointTwo.transform;
                }
                else
                {
                    Debug.Log("Go to Point One");
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
            Destroy(currentLightningEffect);
            Destroy(currentCloudEffect);
            Destroy(currentCircleEffect);
            Destroy(currentUnderCircleEffect);
            audioSource.Stop();
            Debug.Log("PleaseWork");
        }
    }
    
}

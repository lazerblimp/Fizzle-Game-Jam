using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    private AudioSource audioSource;
    private Transform player;
    private Vector3 target;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);

        transform.LookAt(player.position);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.CompareTag("PlayerShot"))
        {
            DestroyProjectile();
            Debug.Log("Fizzled");
        }
        else if (other.CompareTag("Wall"))
        {
            DestroyProjectile();
            Debug.Log("Hit Wall");
        }
    }

    void DestroyProjectile()
    {

        Destroy(gameObject);
    }
}

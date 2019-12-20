using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public Camera playerCamera;
    public bool freeze;
    public float freezeTimer;
    public float startFreezeTimer;
    private AudioSource audioSource;
    private GameObject currentIceEffect;
    public Transform iceSpawn;
    public GameObject ice;

    private void Start()
    {
        freezeTimer = startFreezeTimer;
        freeze = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenCurrent = playerCamera.WorldToScreenPoint(transform.position);
            Vector2 cursorPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 offset = cursorPosition - screenCurrent;
            offset = offset.normalized;
            transform.forward = -new Vector3(offset.x, 0, offset.y);
        }


        if (freeze == true)
        {
            if (freezeTimer == startFreezeTimer)
            {
                currentIceEffect = Instantiate(ice, iceSpawn.position, Quaternion.identity);
            }
            freezeTimer -= Time.deltaTime;
            audioSource.Play();
        }

        if (freezeTimer <= 0)
        {
            freeze = false;
            Destroy(currentIceEffect);
            freezeTimer = startFreezeTimer;
        }

        if (!freeze)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            transform.position = transform.position - move * Time.deltaTime * rotationSpeed;

        }
    }
}

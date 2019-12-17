using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStolenPlayerController : MonoBehaviour
{
    public float speed;
    public float yRotSpeed;
    public float currentYRot;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //bad practice, Jim should be in jail
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
       
    }
    void Movement()
    {
        float moveForward = 0;
        float moveRight = 0;
        if (Input.GetKey(KeyCode.W))
        {
            moveForward += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveRight -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveForward -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight += 1;
        }
        //Vector3 moveVector = new Vector3(moveRight, 0, moveForward);
        Vector3 moveVector = (transform.forward * moveForward) + (transform.right * moveRight);
        moveVector.Normalize();
        moveVector *= speed * Time.deltaTime;
        transform.position += moveVector;
        if (Input.GetAxis("Mouse X") != 0)
        {
            float dHor = Input.GetAxis("Mouse X") * yRotSpeed;
            currentYRot += dHor;
            transform.rotation = Quaternion.Euler(0, currentYRot, 0);
        }
    }
    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject myBullet = Instantiate(bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation);
            myBullet.tag = "Bullet";
        }
    }
}

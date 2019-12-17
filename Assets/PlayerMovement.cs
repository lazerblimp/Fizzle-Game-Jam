using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public Camera playerCamera;

    private void Start()
    {

    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 screenCurrent = playerCamera.WorldToScreenPoint(transform.position);
            Vector2 cursorPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 offset = cursorPosition - screenCurrent;
            offset = offset.normalized;
            transform.forward = -new Vector3(offset.x, 0, offset.y);
        }
      
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position = transform.position - move * Time.deltaTime * moveSpeed;

    }
}

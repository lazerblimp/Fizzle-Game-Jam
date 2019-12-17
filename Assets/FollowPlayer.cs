using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform PlayerTransform;

    public Vector3 _cameraOffset;

    public float cameraSpeed = 10.0f;

    public float smoothFactor = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

   
    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

   
    }
}

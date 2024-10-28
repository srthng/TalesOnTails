using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public GameObject CameraLimit; 
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public BoxCollider2D playerCollider;
    public BoxCollider2D limitCollider;

    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        limitCollider = GetComponent<BoxCollider2D>();
    }

    

    private void LateUpdate()
    {
        if (player.position.y != CameraLimit.transform.position.y)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.Log("a");
        }
    }
}


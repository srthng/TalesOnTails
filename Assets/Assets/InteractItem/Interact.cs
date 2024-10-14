using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject InteractObject;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InteractObject = GameObject.Find("Interact");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            if (Input.GetKey(KeyCode.E))
            {
                InteractObject.gameObject.SetActive(false);
            }
        }
    }
}

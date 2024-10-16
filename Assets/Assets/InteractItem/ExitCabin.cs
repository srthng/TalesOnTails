using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCabin : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject InteractSquare;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InteractSquare.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InteractSquare.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player")
        {
            ExitCabine();
        }
    }


    private void ExitCabine()
    {
        SceneManager.LoadScene("BoatDeck");
    }
}

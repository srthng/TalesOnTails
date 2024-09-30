using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    private float speed = 8f;
    private float PlayerPositionX;
    private float PlayerPositionY;

    private void Update()
    {
        PlayerPositionX = Player.transform.position.x;
        PlayerPositionY = Player.transform.position.y;
        Debug.Log(PlayerPositionX);
        Debug.Log(PlayerPositionY);
    }
}

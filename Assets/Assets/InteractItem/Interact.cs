using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private BoxCollider2D hitbox;

    private void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
    }
}

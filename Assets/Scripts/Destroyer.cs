﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player collided with destroyer");
            other.GetComponent<Hero>().HitDestroyer();
        }

        if (other.tag == "WorldChunkPrefab")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Entity")
        {
            Destroy(other.gameObject);
        }
    }
}

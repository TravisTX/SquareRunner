﻿using UnityEngine;
using System.Collections;

public class SpeedChange : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player collided with speed change trigger");
            GameManager.Instance.IncreaseSpeed();
            return;
        }

        if (other.tag == "WorldChunkPrefab")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Entity")
        {
            Destroy(other.gameObject);
        }

        //if (other.gameObject.transform.parent)
        //{
        //    Destroy(other.gameObject.transform.parent.gameObject);
        //}
        //else
        //{
        //    Destroy(other.gameObject);
        //}
    }
}

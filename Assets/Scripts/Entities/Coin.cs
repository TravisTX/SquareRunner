﻿using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        Debug.Log("coin collide");
        GameManager.Instance.coins++;
        AudioSource.PlayClipAtPoint(GameManager.Instance.CoinSound, transform.position);
        Destroy(gameObject);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

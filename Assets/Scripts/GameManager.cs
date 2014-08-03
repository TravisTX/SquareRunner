﻿using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using System.Collections;

public class GameManager
{
    public WorldGenerator WorldGenerator = null;
    public Player Player = null;
    public float distanceTraveled;
    public int coins;
    //public GameObject BackgroundHolderGameObject;

    public static GameManager Instance
    {
        get
        {
            return _instance ?? (_instance = new GameManager());
        }
    }
    private static GameManager _instance;

    private GameManager()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //BackgroundHolderGameObject = GameObject.FindGameObjectWithTag("BackgroundHolder");
    }

    public void ResetGame()
    {
        Debug.Log("Reset");
        Time.timeScale = 0;
        //Debug.Break();
        Player.transform.position = new Vector3(0, 10, 0);
        distanceTraveled = 0;
        coins = 0;


        this.WorldGenerator.ResetGame();
        this.Player.Reset();
        Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y);

        Time.timeScale = 1;
    }


}

﻿using UnityEngine;
using System.Collections;

public class InputManager
{
    public static InputManager Instance
    {
        get
        {
            return _instance ?? (_instance = new InputManager());
        }
    }
    private static InputManager _instance;

    public bool Touching()
    {
        if (Input.GetKey(KeyCode.Space))
            return true;

        if (Input.GetMouseButton(0))
        {
            return true;
        }

        if (Input.touchCount > 0)
        {
            return true;
        }
        return false;
    }

    public bool StartTouch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        if (FullScreenTouch.Instance.StartTouch)
            return true;

        return false;
    }

    public Vector2 GetTouch()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }

        if (Input.GetMouseButton(0))
        {
            return Input.mousePosition;
        }

        return new Vector2();
    }

    public bool FullScreenTouching()
    {
        if (Input.GetKey(KeyCode.Space))
            return true;

        return FullScreenTouch.Instance.Touching;
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : ControllInterface
{
    private string secretCode;
    private Transform tr;
    public bool isOpened;
    public bool usbAttached;

    // Start is called before the first frame update
    void Start()
    {
        secretCode = "1851";
        tr = GameObject.Find("Frame").GetComponent<Transform>();
        isOpened = false;
        onGrabbed = OnGrabbed;
        onReleased = OnReleased;
        right = Right;
        left = Left;
        down = Down;
        up = Up;
        usbAttached = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool checkCode()
    {
        string inputCode = "";
        for (int i = 0; i < 4; i++)
        {
            string name = "input" + i;
            Debug.Log(name);
            inputCode += GameObject.Find(name).GetComponent<FrameInputs>().input;
        }
        Debug.Log(inputCode);
        if (inputCode.Equals(secretCode))
        {
            return true;
        }
        return false;
    }

    public void Open()
    {
        if (isOpened)
        {
            return;
        }
        if (checkCode())
        {
            tr.Rotate(0, 180, 0);
            isOpened = true;
            if (usbAttached)
            {
                GameObject.Find("USB").GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public void Close()
    {
        if (!isOpened)
        {
            return;
        }
        tr.Rotate(0, -180, 0);
        isOpened = false;
    }

    public void Right()
    {
        Close();
    }

    public void Left()
    {
        Open();
    }

    public void Down()
    {
    }

    public void Up()
    {
    }

    public void OnGrabbed()
    {
        _tr.parent = _parent;
        GameObject.Find("player").GetComponent<ControllerInputV>().movable = false;
    }
    public void OnReleased()
    {
        GameObject.Find("player").GetComponent<ControllerInputV>().movable = true;
    }
}

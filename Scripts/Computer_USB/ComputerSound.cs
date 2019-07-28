using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSound : ControllInterface
{
    public bool usbAttached;
    public float timer = 5f;
    public float coolTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        onGrabbed = OnGrabbed;
        onReleased = OnReleased;
        usbAttached = false;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (usbAttached)
        {
            turnOffSetting();
            onGrabbed = OnGrabbed;
            onReleased = OnReleased;
        }
    }


    public void OnGrabbed()
    {
        if (usbAttached)
        {
            GameObject.Find("player").GetComponent<ObjectControll>().ReleaseObject();
        }
    }
    public void OnReleased()
    {
        if (usbAttached)
        {
            if (timer >= coolTime)
            {
                GameObject.Find("USBPort").GetComponent<Computer>().TurnOnMos();
                timer = 0;
            }

        }
    }
}

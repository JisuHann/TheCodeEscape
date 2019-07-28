using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject drawer;
    public GameObject screenon;
    public AudioClip clip;
    private AudioSource audio;


    void Start()
    {
        screenon = GameObject.Find("screenon");
        screenon.SetActive(false);
        audio = GetComponent<AudioSource>();
        //turnOffSetting();

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "USB")
        {
            Debug.Log("usb crashed");
            GameObject usb = GameObject.Find("USB");
            if (GameObject.Find("player").GetComponent<ObjectControll>().obj.name == "USB")
            {
                GameObject.Find("player").GetComponent<ObjectControll>().ReleaseObject();
            }
            Destroy(usb.GetComponent<Rigidbody>());
            Destroy(usb.GetComponent<BoxCollider>());
            screenon.SetActive(true);
            Transform laptop = gameObject.GetComponent<Transform>().parent;
            laptop.gameObject.GetComponent<ComputerSound>().usbAttached = true;

            usb.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>().parent;
            usb.GetComponent<Transform>().localPosition = new Vector3(-0.16f, 0, -0.06f);
            usb.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
            usb.GetComponent<Transform>().localScale = new Vector3(0.0008f, 0.0008f, 0.0008f);
            TurnOnMos();
        }
    }

    public void TurnOnMos()
    {
        audio.PlayOneShot(clip);
    }
}

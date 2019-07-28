using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : MonoBehaviour
{
    public GameObject image;
    public GameObject doorWood;
    public bool doorOpen = false;

    void Start()
    {
        image = GameObject.Find("KeyImage");
        doorWood = GameObject.Find("Door_Wood");
    }

    void Update()
    {
        if (doorOpen)
        {
            var newRot = Quaternion.RotateTowards(GetComponent<Transform>().rotation, Quaternion.Euler(-90.0f, 0.0f, -90.0f), Time.deltaTime * 250);
            doorWood.GetComponent<Transform>().rotation = newRot;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "player" && GameVariables.key == true)
        {
            GameVariables.key = false;
            image.active = false;
            
            doorOpen = true;
        }
    }
}

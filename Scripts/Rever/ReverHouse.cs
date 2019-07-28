using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverHouse : MonoBehaviour
{
    public GameObject handle;
    public Transform reverhouse;

    void Start()
    {
        handle = GameObject.Find("ReverHandle");

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "ReverHandle")
        {
            handle.GetComponent<Transform>().parent = null;
            handle.GetComponent<BoxCollider>().isTrigger = false;
            handle.GetComponent<ReverHandle>().isset = true;
            handle.GetComponent<ReverHandle>().beingCarried = false;
            handle.GetComponent<ReverHandle>().touched = false;
            handle.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 vector;
            vector = transform.position;
            vector.x = 10.35f;
            vector.y = 2f;
            vector.z = -10.5f;
            handle.GetComponent<Transform>().position = vector;
        }
    }
}

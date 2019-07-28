using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject drawer;

    void Start()
    {
        drawer = GameObject.Find("Drawer1");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "WhiteKing")
        {
            drawer.GetComponent<Transform>().Translate(1f, 0, 0);
        }
    }
}

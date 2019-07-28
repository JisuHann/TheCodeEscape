using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Ball : MonoBehaviour
{
    private VRInteractiveItem interactiveItem;
    private MeshRenderer _renderer;
    private Color originColor;

    public Transform self;
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    public bool beingCarried = false;
    public int dmg;
    private bool touched = false;

    private void Awake()
    {
        interactiveItem = GetComponent<VRInteractiveItem>();
        _renderer = GetComponent<MeshRenderer>();
        originColor = _renderer.material.color;
        self = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        interactiveItem.OnOver += HandleGazeOver;
        interactiveItem.OnOut += HandleGazeOut;
        interactiveItem.OnClick += HandleClick;
        interactiveItem.OnDoubleClick += HandleDoubleClick;
    }

    private void OnDisable()
    {
        interactiveItem.OnOver -= HandleGazeOver;
        interactiveItem.OnOut -= HandleGazeOut;
        interactiveItem.OnClick -= HandleClick;
        interactiveItem.OnDoubleClick -= HandleDoubleClick;
    }

    void HandleGazeOver()
    {
        _renderer.material.color = Color.yellow;
    }

    void HandleGazeOut()
    {
        _renderer.material.color = originColor;
    }

    void HandleClick()
    {
        self.transform.Rotate(new Vector3(0, 50, 0));
    }

    void HandleDoubleClick()
    {

        if (beingCarried)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<MeshCollider>().isTrigger = false;
            transform.parent = null;
            beingCarried = false;
            touched = false;
            GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;

            GetComponent<MeshCollider>().isTrigger = true;
            transform.parent = playerCam;
            beingCarried = true;
        }
    }

    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}


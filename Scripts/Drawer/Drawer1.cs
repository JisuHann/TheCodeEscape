using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Drawer1 : MonoBehaviour
{
    private VRInteractiveItem interactiveItem;
    private MeshRenderer _renderer;
    private Color originColor;

    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    private bool touched = false;
    private bool opened = false;

    private void Awake()
    {
        interactiveItem = GetComponent<VRInteractiveItem>();
        _renderer = GetComponent<MeshRenderer>();
        originColor = _renderer.material.color;
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
        if (opened == false)
        {
            GetComponent<Transform>().Translate(1f, 0, 0);
            opened = true;
        }
        else if (opened == true)
        {
            GetComponent<Transform>().Translate(-1f, 0, 0);
            opened = false;
        }
    }

    void HandleDoubleClick()
    {

    }

    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class chest_top : MonoBehaviour
{
    private VRInteractiveItem interactiveItem;
    private MeshRenderer _renderer;
    private Color originColor;

    public Transform self;
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public AudioClip[] soundToPlay;
    private AudioSource audio;
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
    }

    private void OnDisable()
    {
        interactiveItem.OnOver -= HandleGazeOver;
        interactiveItem.OnOut -= HandleGazeOut;
        interactiveItem.OnClick -= HandleClick;
    }

    void HandleGazeOver()                                                                   //커서가 갈 때
    {
        _renderer.material.color = Color.yellow;
    }

    void HandleGazeOut()                                                                   //커서가 지나갈 때
    {
        _renderer.material.color = originColor;
    }

    void HandleClick()
    {
        transform.RotateAround(transform.position, Vector3.left,90);
    }
    
}

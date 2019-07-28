using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class LeverHandler : ControllInterface
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
    public bool touched = false;
    public bool isset = false;
    public bool isOpened = false;
    public float coolTime = 0.05f;
    public float timer = 0.05f;
    private void Start()
    {
        interactiveItem = GetComponent<VRInteractiveItem>();
        _renderer = GetComponent<MeshRenderer>();
        originColor = _renderer.material.color;
        self = GetComponent<Transform>();
        turnOffSetting();
        onGrabbed = OnGrabbed;
        onReleased = OnReleased;
    }

    private void Update()
    {
        timer += Time.deltaTime;
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
        Debug.Log("clicked");
        if (isset)
        {
            var bookshelf = GameObject.Find("bookshelf");
            bookshelf.GetComponent<Transform>().Translate(-1000, 0, 0);
        }
        else
        {
            self.transform.Rotate(new Vector3(0, 50, 0));
        }
    }

    void HandleDoubleClick()
    {
        if (beingCarried)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            beingCarried = false;
            touched = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().isTrigger = true;
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

    public void OnGrabbed()
    {
        //_tr.LookAt(_player);
        if (isset)
        {

            GameObject.Find("player").GetComponent<ObjectControll>().ReleaseObject();
        }
    }
    public void OnReleased()
    {
        if (isset)
        {
            GetComponent<Rigidbody>().useGravity = false;
            if (timer >= coolTime)
            {
                var bookshelf = GameObject.Find("bookshelf");
                if (!isOpened)
                {
                    bookshelf.GetComponent<Transform>().Translate(-8, 0, 0);
                    Debug.Log("moved");
                    isOpened = true;
                    GameObject.Find("leverHolder").GetComponent<Transform>().rotation = Quaternion.Euler(30, 90, 90);
                }
                else
                {
                    bookshelf.GetComponent<Transform>().Translate(8, 0, 0);
                    Debug.Log("back moved");
                    isOpened = false;
                    GameObject.Find("leverHolder").GetComponent<Transform>().rotation = Quaternion.Euler(-30, 90, 90);
                }
                timer = 0f;
            }
        }
    }
}


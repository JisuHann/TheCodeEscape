using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllInterface : MonoBehaviour
{
    public Transform _tr;
    public Transform _player;
    public Transform _parent;
    public Rigidbody _body;
    public MeshCollider _collider;

    public Action onGrabbed;
    public Action onReleased;
    public Action right;
    public Action rightB;
    public Action rightX;
    public Action rightY;
    public Action left;
    public Action leftB;
    public Action leftX;
    public Action leftY;
    public Action down;
    public Action downB;
    public Action downX;
    public Action downY;
    public Action up;
    public Action upB;
    public Action upX;
    public Action upY;
    public Vector3 originScale;
    public int rotSpeed = 1;
    public int speed = 3;
    private int originLayer;
    // Use this for initialization

    void Awake()
    {
        _tr = GetComponent<Transform>();
        _player = Camera.main.GetComponent<Transform>();
        _body = GetComponent<Rigidbody>();
        _collider = GetComponent<MeshCollider>();
        onGrabbed = _OnGrabbed;
        onReleased = _OnReleased;
        right = _Right;
        rightB = _RightB;
        rightX = _RightX;
        rightY = _RightY;
        left = _Left;
        leftB = _LeftB;
        leftX = _LeftX;
        leftY = _LeftY;
        down = _Down;
        downB = _DownB;
        downX = _DownX;
        downY = _DownY;
        up = _Up;
        upB = _UpB;
        upX = _UpX;
        upY = _UpY;
    }

    // Update is called once per frame


    public void Grabbed()
    {
        Debug.Log("grabbed");
        originScale = _tr.localScale;
        _parent = _tr.parent;
        _tr.parent = _player;
        if (_body != null)
        {
            _body.useGravity = false;
        }
        if (_collider != null)
        {
            if (_collider.convex == true)
            {
                _collider.isTrigger = false;
            }
        }
        gameObject.layer = 10;
        Debug.Log("interface grabbed");
        onGrabbed();
    }

    public void Released()
    {
        Debug.Log("released");
        _tr.parent = _parent;
        _tr.localScale = originScale;
        if (_body != null)
        {
            _body.useGravity = true;
        }
        if (_collider != null)
        {
            if (_collider.convex == true)
            {
                _collider.isTrigger = false;
            }
        }
        gameObject.layer = originLayer;
        onReleased();
    }

    public bool OnInput()
    {
        bool res = true;
        if (OVRInput.Get(OVRInput.Button.DpadRight) || Input.GetKey(KeyCode.RightArrow))
        {
            if (OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.S))
            {
                Debug.Log("right input");
                if (right!=null)
                    right();
            }
            else if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.D))
            {
                Debug.Log("right D input");
                if (rightB != null)
                    rightB();
            }
            else if (OVRInput.Get(OVRInput.Button.Three) || Input.GetKey(KeyCode.A))
            {
                Debug.Log("right A input");
                if (rightX != null)
                    rightX();
            }
            else if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.W))
            {
                Debug.Log("right W input");
                if (rightY != null)
                    rightY();
            }
        }

        else if (OVRInput.Get(OVRInput.Button.DpadLeft) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.S))
            {
                if (left != null)
                    left();
            }
            else if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.D))
            {
                if (leftB != null)
                    leftB();
            }
            else if (OVRInput.Get(OVRInput.Button.Three) || Input.GetKey(KeyCode.A))
            {
                if (leftX != null)
                    leftX();
            }
            else if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.W))
            {
                if (leftY != null)
                    leftY();
            }
        }

        else if (OVRInput.Get(OVRInput.Button.DpadDown) || Input.GetKey(KeyCode.DownArrow))
        {
            if (OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.S))
            {
                if (down != null)
                    down();
            }
            else if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.D))
            {
                if (downB != null)
                    downB();
            }
            else if (OVRInput.Get(OVRInput.Button.Three) || Input.GetKey(KeyCode.A))
            {
                if (downX != null)
                    downX();
            }
            else if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.W))
            {
                if (downY != null)
                    downY();
            }
        }

        else if (OVRInput.Get(OVRInput.Button.DpadUp) || Input.GetKey(KeyCode.UpArrow))
        {
            if (OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.S))
            {
                if (up != null)
                    up();
            }
            else if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.D))
            {
                if (upB != null)
                    upB();
            }
            else if (OVRInput.Get(OVRInput.Button.Three) || Input.GetKey(KeyCode.A))
            {
                if (upX != null)
                    upX();
            }
            else if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.W))
            {
                if (upY != null)
                    upY();
            }
        }
        else
        {
            res = false;
        }
        return res;
    }


    public void _Right()
    {
        Debug.Log("right");
        Vector3 dir = _player.TransformDirection(Vector3.right);
        dir = _tr.InverseTransformDirection(dir);
        _tr.Translate(dir*speed*Time.deltaTime);
    }

    public void _RightB()
    {
        Debug.Log("rightB");
    }

    public void _RightX()
    {
    }

    public void _RightY()
    {
        Debug.Log("righty");
        _tr.Rotate(0, -rotSpeed, 0);
    }

    public void _Left()
    {
        Vector3 dir = _player.TransformDirection(Vector3.left);
        dir = _tr.InverseTransformDirection(dir);
        _tr.Translate(dir * speed * Time.deltaTime);
    }

    public void _LeftB()
    {
       
    }

    public void _LeftX()
    {
    }

    public void _LeftY()
    {
        _tr.Rotate(0, rotSpeed, 0);
    }
    public void _Down()
    {
        Vector3 dir = _player.TransformDirection(Vector3.down);
        dir = _tr.InverseTransformDirection(dir);
        _tr.Translate(dir * speed * Time.deltaTime);
    }
    public void _DownB()
    {
        Vector3 dir = _player.TransformDirection(Vector3.back);
        dir = _tr.InverseTransformDirection(dir);
        _tr.Translate(dir * speed * Time.deltaTime);
    }

    public void _DownX()
    {

    }

    public void _DownY()
    {
        _tr.Rotate(rotSpeed, 0, 0);
    }
    public void _Up()
    {
        Vector3 dir = _player.TransformDirection(Vector3.up);
        dir = _tr.InverseTransformDirection(dir);
        _tr.Translate(dir * speed * Time.deltaTime);
    }
    public void _UpB()
    {
        Vector3 dir = _player.TransformDirection(Vector3.forward);
        dir = _tr.InverseTransformDirection(dir);
        _tr.Translate(dir * speed * Time.deltaTime);
    }

    public void _UpX()
    {

    }

    public void _UpY()
    {
        _tr.Rotate(rotSpeed, 0, 0);
    }

    public void _OnGrabbed()
    {
        _tr.LookAt(_player);
        Debug.Log("original on grabbed");
    }
    public void _OnReleased() { }

    void OnCollisionExit(Collision collision)
    {
        _body.isKinematic = true;
        _body.isKinematic = false;
    }

    public void EmptyFunc() { }

    public void turnOffSetting()
    {
        onGrabbed = EmptyFunc;
        onReleased = EmptyFunc;
        right = EmptyFunc;
        rightB = EmptyFunc;
        rightX = EmptyFunc;
        rightY = EmptyFunc;
        left = EmptyFunc;
        leftB = EmptyFunc;
        leftX = EmptyFunc;
        leftY = EmptyFunc;
        down = EmptyFunc;
        downB = EmptyFunc;
        downX = EmptyFunc;
        downY = EmptyFunc;
        up = EmptyFunc;
        upB = EmptyFunc;
        upX = EmptyFunc;
        upY = EmptyFunc;
    }

    public void turnOnSetting()
    {
        onGrabbed = _OnGrabbed;
        onReleased = _OnReleased;
        right = _Right;
        rightB = _RightB;
        rightX = _RightX;
        rightY = _RightY;
        left = _Left;
        leftB = _LeftB;
        leftX = _LeftX;
        leftY = _LeftY;
        down = _Down;
        downB = _DownB;
        downX = _DownX;
        downY = _DownY;
        up = _Up;
        upB = _UpB;
        upX = _UpX;
        upY = _UpY;
    }
}

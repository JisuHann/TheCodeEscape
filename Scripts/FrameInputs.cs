using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameInputs : ControllInterface
{
    public int input;
    private float _angle;
    private Transform tr;
    private Vector3 origin;
    private Quaternion originAngle;
    public float timer = 0.1f;
    public float coolTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        input = 1;
        _angle = 36f;
        onGrabbed = OnGrabbed;
        onReleased = OnReleased;
        right = Right;
        left = Left;
        down = Down;
        up = Up;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void RotateTo(int target)
    {
        if (timer >= coolTime)
        {
            Debug.Log("rotate !!");
            int delta = target - input;
            float deltaAngle = delta * _angle;
            tr.Rotate(0, deltaAngle, 0);
            input = target;
            timer = 0;
        }
    }

    public void Right()
    {
        RotateTo((input + 1) % 10);
    }

    public void Left()
    {
        RotateTo((input + 9) % 10);
    }

    public void Down()
    {
    }

    public void Up()
    {
    }

    public void OnGrabbed()
    {
        origin = tr.position;
        originAngle = tr.rotation;
        tr.localPosition = new Vector3(0, 0, 0.2f);
        tr.LookAt(_player);
        int newInput = input;
        input = 6;
        RotateTo(newInput);
        GameObject.Find("player").GetComponent<ControllerInputV>().movable = false;
    }
    public void OnReleased()
    {
        int newInput = input;
        tr.position = origin;
        tr.rotation = originAngle;
        input = 1;
        RotateTo(newInput);
        GameObject.Find("player").GetComponent<ControllerInputV>().movable = true;
    }
}

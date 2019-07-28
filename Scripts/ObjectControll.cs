using UnityEngine;
using System.Collections;

public class ObjectControll : MonoBehaviour
{
    public ControllInterface obj;
    public bool onGrab;
    // Use this for initialization
    void Start()
    {
        onGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GrabObject(ControllInterface obj)
    {
        this.obj = obj;
        this.onGrab = true;
        obj.Grabbed();
    }

    public void ReleaseObject()
    {
        this.obj.Released();
        this.obj = null;
        this.onGrab = false;

    }

    public bool HandleObject()
    {
        if (!onGrab)
        {
            return false;
        }

        if (OVRInput.Get(OVRInput.Button.Three) || Input.GetKey(KeyCode.A))
        {
            ReleaseObject();
            return true;
        }

        return this.obj.OnInput();

    }

}


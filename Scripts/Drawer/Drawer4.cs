using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer4 : MonoBehaviour
{
    public bool plate1 = false;
    public bool plate2 = false;
    public bool plate3 = false;
    bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plate1 && plate2 && plate3 && !opened)
        {
            GetComponent<Transform>().Translate(1f, 0, 0);
            opened = true;
        }
    }
}

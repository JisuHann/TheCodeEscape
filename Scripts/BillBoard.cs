using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    private Transform camTr;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.transform;
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        tr.LookAt(camTr.position);
    }
}

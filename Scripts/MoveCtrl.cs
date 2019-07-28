using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public enum MoveType
    {
        WAY_POINT,
        LOOK_AT,
    }

    public MoveType moveType = MoveType.LOOK_AT;

    public float speed = 1000.0f;

    public float damping = 3.0f;

    public static bool isStopped = false;

    private Transform tr;
    private Transform camTr;
    private CharacterController cc;

    private Transform[] points;

    private int nextIdx = 1;


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        camTr = Camera.main.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();

        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped)
            return;

        switch (moveType)
        {
            case MoveType.WAY_POINT:
                MoveWayPoint();
                break;

            case MoveType.LOOK_AT:
                MoveLookAt();
                break;
        }

    }

    void MoveWayPoint()
    {
        Vector3 direction = points[nextIdx].position - tr.position;

        Quaternion rot = Quaternion.LookRotation(direction);

        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void MoveLookAt()
    {
        Vector3 dir = camTr.TransformDirection(Vector3.forward);
        cc.SimpleMove(dir * speed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Point"))
        {
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
        }
    }
}

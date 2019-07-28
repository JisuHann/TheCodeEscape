using UnityEngine;

public class ControllerInputV : MonoBehaviour
{

    public int speed = 10;      // 걸음 속도
    public float updownSpeed = 0.1f;
    public GameObject bullet;      // 발사할 총알
    public Transform firePos;      // 발사되는 위치

    private Transform tr;          // 플레이어 트랜스폼
    private Transform camTr;
    private CharacterController cc;
    private float dirX = 0;
    private float dirZ = 0;
    public bool movable;
    public ObjectControll objCon;
    public float timer = 0.3f;
    public float coolTime = 0.3f;

    void Start()
    {
        movable = true;
        tr = GetComponent<Transform>();
        camTr = Camera.main.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        objCon = GetComponent<ObjectControll>();
    }

    void Update()
    {
        MovePlayer();
        timer += Time.deltaTime;
    }

    // 주인공 이동
    void MovePlayer()
    {


        dirX = 0;   // 좌우 이동 방향(왼쪽:-1, 오른쪽:1)
        dirZ = 0;   // 전진 후진 이동 방향(후진:-1, 전진:1)


        //메인 카메라가 바라보는 방향
        Vector3 dir = camTr.TransformDirection(Vector3.forward);
        Vector3 dirright = camTr.TransformDirection(Vector3.right);
        Vector3 dirleft = camTr.TransformDirection(Vector3.left);
        

        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.S) || OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.D)
            || OVRInput.Get(OVRInput.Button.Three) || Input.GetKey(KeyCode.A) || OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.W))
        {
            float del = timer;
            if (!objCon.HandleObject())
            {
                if (timer >= coolTime)
                {
                    if (OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.S))
                    {
                        if (camTr.position.y > 0.6)
                            camTr.Translate(camTr.InverseTransformDirection(Vector3.down) * updownSpeed);
                    }
                    if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.W))
                    {
                        if (camTr.position.y < 8.0)
                            camTr.Translate(camTr.InverseTransformDirection(Vector3.up) * updownSpeed);
                    }
                    del -= coolTime;
                }
            }
            timer -= del;
        }
        else
        {
            if (!movable)
            {
                return;
            }
            if (OVRInput.Get(OVRInput.Button.DpadUp) || Input.GetKey(KeyCode.RightArrow))
            {
                dirZ = dirright.z;
                dirX = dirright.x;
            }

            if (OVRInput.Get(OVRInput.Button.DpadDown) || Input.GetKey(KeyCode.LeftArrow))
            {
                dirX = dirleft.x;
                dirZ = dirleft.z;
            }

            if (OVRInput.Get(OVRInput.Button.DpadRight) || Input.GetKey(KeyCode.DownArrow))
            {
                dirX = -dir.x;
                dirZ = -dir.z;
            }

            if (OVRInput.Get(OVRInput.Button.DpadLeft) || Input.GetKey(KeyCode.UpArrow))
            {
                dirX = dir.x;
                dirZ = dir.z;
            }

            // 이동 방향 설정 후 이동
        }
        Vector3 moveDir = new Vector3(dirX, 0, dirZ);

        cc.SimpleMove(tr.TransformDirection(moveDir) * speed);
    }
}
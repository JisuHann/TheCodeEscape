using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject text;
    public string curPassword = "326174859";
    public string input;
    public bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("screentext");
        text.GetComponent<TextMesh>().text = "Password";
    }

    // Update is called once per frame
    void Update()
    {

        if (input == curPassword)
        {
            text.GetComponent<TextMesh>().text = "correct";
            text.GetComponent<TextMesh>().color = Color.green;
            StartCoroutine(Fade());
        }

        if (doorOpen)
        {
            var newRot = Quaternion.RotateTowards(GetComponent<Transform>().rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
            GetComponent<Transform>().rotation = newRot;
        }

        if (input.Length == 9 && input != curPassword)
        {
            text.GetComponent<TextMesh>().text = "incorrect";
            text.GetComponent<TextMesh>().color = Color.red;
            input = "";
        }

        if (input.Length > 0 && input != curPassword)
        {
            text.GetComponent<TextMesh>().color = Color.black;
            text.GetComponent<TextMesh>().text = input;
        }

    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        doorOpen = true;
    }
}

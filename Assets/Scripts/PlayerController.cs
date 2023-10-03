using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private hogehoge h;
    // Start is called before the first frame update
    void Start()
    {
        h = GameObject.Find("Main Camera").GetComponent<hogehoge>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("Btn1") || h.getE1())
        {
            h.resetE1();
            transform.position += new Vector3(30f, 55f, 0f);
        }
        if (Input.GetKey("Btn2"))
        {
            transform.position += new Vector3(84.5f, 55f, 0f);
        }
    }
}

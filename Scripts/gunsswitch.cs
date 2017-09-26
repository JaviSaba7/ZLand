using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunsswitch : MonoBehaviour
{

    public GameObject weapon01;
    public GameObject weapon02;

    // Use this for initialization
    void Start()
    {
        weapon01.SetActive(true);
        weapon02.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            weapon01.SetActive(true);
            weapon02.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            weapon01.SetActive(false);
            weapon02.SetActive(true);
        }
    }
}

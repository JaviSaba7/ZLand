using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport2 : MonoBehaviour
{

    public FadeManager fadeManager;
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            fadeManager.Teleport(other.transform, new Vector3(249.56f, -632.87f, 6.706f));
           
        }
       
    }



}
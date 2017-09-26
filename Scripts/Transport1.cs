using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport1 : MonoBehaviour
{

    public FadeManager fadeManager;
    
    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            fadeManager.Teleport(other.transform, new Vector3(255.0712f, -390.1712f, 59.71313f));
            
        }

    }



}
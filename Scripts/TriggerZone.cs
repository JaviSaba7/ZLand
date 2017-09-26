using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone : MonoBehaviour
{
    public Text text;
    public SwitchCameras switchCameras;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //AllowTrip = true;
            //text = GetComponent<GUIText>(); 
            switchCameras.AllowTrip = true; 
            text.text = "Pulse F to travel";
            text.enabled = true; 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //AllowTrip = true;
            //text = GetComponent<GUIText>();  
            switchCameras.AllowTrip = false;
            text.text = "";
            text.enabled = false;
        }
    }



}
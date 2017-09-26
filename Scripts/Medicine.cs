using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medicine : MonoBehaviour
{
    public PlayerBehaviour player;
    public Medicine medicine;
    public LifeBarUI lifeBar;

    void Start()
    {
        medicine.enabled = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            player.SetDamage(-100);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            medicine.enabled = false;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_buena : MonoBehaviour
{
    [Header("Properties")]
    public int maxAmmo;
    public int currentAmmo;
    public float maxDistance = Mathf.Infinity;
    public float firerate;
    public float reloadTime;
    public bool auto;
    public int damage;
    public float hitForce;

    private bool canShot;
    public AudioSource shotSource;

	// Use this for initialization
	void Start ()
    {
        currentAmmo = maxAmmo;
        canShot = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButton("Fire1"))
        {
            if(canShot) ;
            {
                if(currentAmmo > 0) Shot();
                else Reload();
            }
        }
	}

    void Shot ()
    {
        currentAmmo--;
        canShot = false;
        shotSource.Play();
        shotSource.pitch = Random.Range(0.98f, 1.03f);
        shotSource.volume = Random.Range(0.12f, 0.17f);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(ray.origin, hit.point, Color.red, 3);
        }
        
        StartCoroutine("Cooldown", firerate);
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        StartCoroutine("Cooldown", reloadTime);
    }
    IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canShot = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Properties")]
    public int maxAmmo;
    public int currentAmmo;
    public float maxDistance = Mathf.Infinity;
    public float fireRate;
    public float reloadTime;
    public bool auto;

    public LayerMask layerMask;

    public int hitDamage = 10;
    public float hitForce;

    //AUDIOS
    public AudioSource reloadSound;
    public AudioSource shotSource;

    public bool canShot;
    public bool reloading;

    public Animator anim;
    public bool walk, run;

    // Use this for initialization
    void Start()
    {
        currentAmmo = maxAmmo;
        canShot = true;
        reloading = false;
    }

    private void Update()
    {
        MoveAnimation();

        if(!canShot)
        {
            //contador para reiniciar el shot
        }
        if(reloading)
        {
           //contador para reiniciar el reload
        }
    }

    void Shot()
    {
        currentAmmo--;        
        shotSource.Play();
        shotSource.pitch = Random.Range(0.98f, 1.03f);
        shotSource.volume = Random.Range(0.12f, 0.17f);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//desde el centro de la camara hacia el mundo
        RaycastHit hit = new RaycastHit(); //la informacion del rayo la guardamos en hit

        anim.SetTrigger("Shot");

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(ray.origin, hit.point, Color.red, 3);

            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                hit.transform.GetComponent<EnemyBehaviour>().SetDamage(hitDamage);
            }
        }
        if(canShot) StartCoroutine("CooldownShot", fireRate);
    }

    public void Reload()
    {
        reloadSound.Play();//reproduce el sonido

        reloadSound.pitch = Random.Range(0.98f, 1.03f);
        reloadSound.volume = Random.Range(0.25f, 0.40f);

        if (!reloading) StartCoroutine("CooldownReload");//Llamada a la corutina del reload

        anim.SetTrigger("Reload");
    }

    IEnumerator CooldownShot(float time)
    {
        canShot = false;
        yield return new WaitForSeconds(time);
        canShot = true;
    }
    IEnumerator CooldownReload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        currentAmmo = maxAmmo;//tu arma pasa a tener el maxAmmo
    }

    public void TryShot() //Prueba a disparar
    {
        if (canShot && !reloading)//Si puedes disparar y además no estás recargando
        {
            if (currentAmmo > 0) Shot();//(en el caso de que haya municion) DISPARA
            else Reload();//Llamamos al reload
        }
    }


    void MoveAnimation()
    {
        anim.SetBool("Walk", walk);
        anim.SetBool("Run", run);
    }

    public void EndReload()
    {
        reloading = false;
    }
}

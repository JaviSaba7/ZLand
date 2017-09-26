using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour
{
    private CharacterController controller;

    public LifeBarUI lifeBar;

    public AudioSource damageSound;
    public AudioSource deadSound;

    public Vector3 moveDirection;
    private Vector3 desiredDirection;

    private Vector2 axis;

    public float speed;
    public float runSpeed;
    public float walkSpeed;
    public float jumpSpeed;
    public float forceToGround = Physics.gravity.y;
    public float gravityMagnitude = 1;

    public bool jump;
    public bool isGrounded;

    public int life = 100;
    public bool dead = false;

	void Start ()
    {
        controller = GetComponent<CharacterController>();



        lifeBar.Init(life);
	}
	
	// Update is called once per frame
	void Update ()
    {

        // Reset states
        if (!controller.isGrounded) isGrounded = false;

        // Logic
        if(isGrounded && !jump)
        {
            moveDirection.y = forceToGround;
        }
        else
        {
            moveDirection.y += forceToGround * gravityMagnitude * Time.deltaTime;
        }

        desiredDirection = transform.forward * axis.y + transform.right * axis.x;

        moveDirection.x = desiredDirection.x * speed;
        moveDirection.z = desiredDirection.z * speed;

        // Apply Changes
        if (!dead)
        {
            controller.Move(moveDirection * Time.deltaTime);
        }
	}
    public void moreLife()
    {
        life = 100;
    }

    public void SetHorizontalAxis(float x)
    {
        axis.x = x;
    }

    public void SetVerticalAxis(float z)
    {
        axis.y = z;
    }

    public void Jump()
    {
        if(isGrounded)
        {
            jump = true;
            moveDirection.y = jumpSpeed;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if(controller.isGrounded)
            {
                isGrounded = true;
                jump = false;
            }
        }
    }

    public void Run()
    {
        // Speed
        if (isGrounded)
        {
            speed = runSpeed;
        }
    }

    public void Walk()
    {
        // Speed
        speed = walkSpeed;
    }

    public void SetDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            dead = true;
            life = 0;
            //SceneManager.LoadScene("Menu", LoadSceneMode.Additive);

            deadSound.Play();
            Debug.Log("killpalyer");
            Application.LoadLevel(Application.loadedLevel -1);
            deadSound.pitch = Random.Range(0.98f, 1.03f);
            deadSound.volume = Random.Range(0.12f, 0.17f);
            //sonido de muerte
            //animación de muerte
            //feedback de muerte
            //GAMEOVER ?
        }
        else
        {
            damageSound.Play();

            damageSound.pitch = Random.Range(0.98f, 1.03f);
            damageSound.volume = Random.Range(0.12f, 0.17f);
            //animación o feedback de daño
        }

        lifeBar.UpdateBar(life);   
    }
}

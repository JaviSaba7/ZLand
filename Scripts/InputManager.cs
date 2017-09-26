using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 inputAxis;
    private PlayerBehaviour player;
    private Vector2 mouseAxis;
    public float sensitivity = 3;
    private CameraBehaviour cameraBehaviour;
    private MouseCursor mouse;

    public Gun[] guns;
    public int gunSelected = 0;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<PlayerBehaviour>();
        cameraBehaviour = GetComponentInChildren<CameraBehaviour>();
        mouse = GetComponent<MouseCursor>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.dead) return;

        inputAxis.x = Input.GetAxis("Horizontal");
        player.SetHorizontalAxis(inputAxis.x);

        inputAxis.y = Input.GetAxis("Vertical");
        player.SetVerticalAxis(inputAxis.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.Run();
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.Walk();
        }
        

        mouseAxis.y = Input.GetAxis("Mouse Y") * sensitivity;
        cameraBehaviour.SetRotationX(mouseAxis.y);
        mouseAxis.x = Input.GetAxis("Mouse X") * sensitivity;
        cameraBehaviour.SetRotationY(mouseAxis.x);

        if (guns[gunSelected].auto)
        {
            if (Input.GetButton("Fire1")) guns[gunSelected].TryShot();
        }
        else
        {
            if (Input.GetButtonDown("Fire1")) guns[gunSelected].TryShot();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            guns[gunSelected].gameObject.SetActive(false);
            gunSelected = 0;
            guns[gunSelected].gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            guns[gunSelected].gameObject.SetActive(false);
            gunSelected = 1;
            guns[gunSelected].gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Cancel")) mouse.Show();
        if (Input.GetMouseButtonDown(0)) mouse.Hide();

        if(Input.GetKeyDown(KeyCode.G))
        {
            player.SetDamage(10);
        }

        if(Input.GetKey(KeyCode.H))
        {
            //player
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private float rotationX;
    private float rotationY;

    private Transform cameraTransform;
    private Quaternion cameraRotation;

    private Transform playerTransform;
    private Quaternion playerRotation;

    public float smooth = 10;

    // Use this for initialization
    void Start ()
    {
        cameraTransform = this.transform;
        cameraRotation = cameraTransform.localRotation;

        playerTransform = this.transform.parent;
        playerRotation = playerTransform.localRotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        cameraRotation *= Quaternion.Euler(-rotationX, 0, 0);
        cameraTransform.localRotation = Quaternion.Lerp(cameraTransform.localRotation, cameraRotation, Time.deltaTime * smooth);

        playerRotation *= Quaternion.Euler(0, rotationY, 0);
        playerTransform.localRotation = Quaternion.Lerp(playerTransform.localRotation, playerRotation, Time.deltaTime * smooth);
    }

    public void SetRotationX(float y)
    {
        rotationX = y;
    }

    public void SetRotationY(float x)
    {
        rotationY = x;
    }
}

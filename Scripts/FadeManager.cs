using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    public float Transparence;
    public bool FadeOut;
    public float Fade = 0.01f;
    public bool fadeActive;

    public Image fadeImage;
    public float fadeTime = 1;
    private Vector3 teleportPosition;
    private bool startFade;
    private Transform t;
    CanvasRenderer canvasRenderer;
	// Use this for initialization
	void Start ()
    {
        Transparence = 1;
        fadeActive = false;
        canvasRenderer = GetComponent<CanvasRenderer>();
        fadeImage.CrossFadeAlpha(0, fadeTime, true);
    }

    // Update is called once per frame
    void Update()
    {/*
        if (fadeActive = true)
        {
            Transparence = Mathf.Clamp(Transparence, 0, 1);
            if (FadeOut)
            {
                Transparence += Fade;

            }
            else
            {
                Transparence -= Fade;
            }

            GetComponent<CanvasGroup>().alpha = Transparence;
        }*/
        if(startFade)
        {
            if(canvasRenderer.GetColor().a == 1)
            {
                startFade = false;
                t.position = teleportPosition;
                fadeImage.CrossFadeAlpha(0, fadeTime, true);
            }
        }
        
    }

    

    public void Teleport(Transform target, Vector3 newPos)
    {
        t = target;
        teleportPosition = newPos;
        startFade = true;
        canvasRenderer.SetColor(Color.clear);
        
        fadeImage.CrossFadeAlpha(1, fadeTime, true);
    }
}

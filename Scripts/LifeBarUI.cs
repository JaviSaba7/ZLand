using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarUI : MonoBehaviour
{

    public RectTransform maskRectTransform;
    public RectTransform lifeRectTransform;
    public PlayerBehaviour player;
    public float maxWidth;
    public float currentWidth;

    private int maxLife;


	public void Init(int life)
    {
        maxWidth = maskRectTransform.sizeDelta.x;
        maxLife = life;

        UpdateBar(maxLife);
	}
	
	public void UpdateBar(int newLife)
    {
        currentWidth = (maxWidth * newLife) / maxLife;

        
        lifeRectTransform.sizeDelta = new Vector2(currentWidth, lifeRectTransform.sizeDelta.y);

        
    }
}

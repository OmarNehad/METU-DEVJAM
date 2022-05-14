using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{

    public static HealthControl Instance { get; set; }

    public  int health = 3;

    public  Image[] hearts;


    public  Sprite fullheart;

    public Sprite emptyHeart;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public  void DecreaseHelath()
    {
        hearts[health - 1].sprite = emptyHeart;
        health -=1;
    }


}

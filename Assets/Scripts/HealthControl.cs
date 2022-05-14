using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;

    public Sprite fullheart;
    public Sprite emptyHeart;
    // Update is called once per frame
    void Update()
    {
        foreach ( Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for ( int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullheart;
        }
        
    }
}

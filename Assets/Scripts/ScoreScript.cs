using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    private int ScoreNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum;
        
    }
    private void OnTriggerEnter2D(Collider2D tea)
    {
        if(tea.tag == "shay" || tea.tag == "PowerUp")
        {
            ScoreNum += 1;
            Destroy(tea.gameObject);
            MyscoreText.text = "Score: " + ScoreNum;
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_TRACK : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 15);
    }
}

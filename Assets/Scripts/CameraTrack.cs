using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player1;

    void Update()
    {
        transform.position = new Vector3(player1.transform.position.x, 250, 0);
    }
}

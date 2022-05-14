using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_TRACK : MonoBehaviour
{
    


    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y,transform.position.z);
    }
}

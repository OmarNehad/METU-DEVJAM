using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{

    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, 0,-5);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demolish : MonoBehaviour
{
    [SerializeField]
    private bool demolish;
    
    [SerializeField]
    private float demolishRate = 1;
    
    [SerializeField]
    private float speed = 5.0f;
    
    [SerializeField]
    private float intensity = 1;


    public GameObject Fire;

    //public ParticleSystem dust;


    private Transform childTransform;
    //private float Threshhold;


    private void Awake()
    {
        Fire = Instantiate(Fire);
        Fire.gameObject.SetActive(false);
        childTransform = transform.GetChild(0);
        //Threshhold = -(mainCanvas.rect.height / 2) - (childImage.GetComponent<RectTransform>().rect.width / 2);

    }

    private void Update()
    {
        if (demolish)
        {
            Fire.gameObject.SetActive(true);
            Fire.transform.position = new Vector3(gameObject.transform.position.x,-2.5f, 0);
            DemolishBuilding();

            if (!childTransform.GetComponent<SpriteRenderer>().isVisible)
            {
                Destroy(Fire);
                Destroy(gameObject);
            }
    }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            demolish = true;
        }
    }

    private void DemolishBuilding()
    {
        childTransform.localPosition = new Vector2(
           intensity * Mathf.PerlinNoise(speed * Time.time, -1),0);
        transform.position = new Vector3(transform.position.x, transform.position.y-(demolishRate*Time.deltaTime), transform.position.z);
 
    }

}

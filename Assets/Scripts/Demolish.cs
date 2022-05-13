using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demolish : MonoBehaviour
{
    [SerializeField]
    private bool demolish;
    
    [SerializeField]
    private float demolishRate;
    
    [SerializeField]
    private float speed = 5.0f;
    
    [SerializeField]
    private float intensity = 0.1f;


    //public ParticleSystem dust;

    public RectTransform mainCanvas;

    private Transform childImage;
    private float Threshhold;


    private void Start()
    {
        childImage = transform.GetChild(0);
        Threshhold = -(mainCanvas.rect.height / 2) - (childImage.GetComponent<RectTransform>().rect.width / 2);

    }

    private void Update()
    {
        if (demolish)
        {
             DemolishBuilding();
        }
        if (GetComponent<RectTransform>().anchoredPosition.y < Threshhold)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "player")
        {
            demolish = true;
        }
    }

    private void DemolishBuilding()
    {
        childImage.localPosition = new Vector2(
           intensity * Mathf.PerlinNoise(speed * Time.time, 1),0);
        transform.position = new Vector3(transform.position.x, transform.position.y-(demolishRate*Time.deltaTime), transform.position.z);
        //dust.Play();
 
    }

}

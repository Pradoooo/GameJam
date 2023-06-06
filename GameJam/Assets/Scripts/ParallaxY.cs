using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxY : MonoBehaviour
{
    private float posicaoMaximaY;
    private float posicaoInicialY;

    private Transform cam;


    public float parallaxEffect;

    void Start()
    {
        posicaoInicialY = transform.position.y;
        posicaoMaximaY = GetComponent<SpriteRenderer>().bounds.size.y;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = cam.transform.position.y * parallaxEffect;
        transform.position = new Vector3(posicaoInicialY + distancia, transform.position.y, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float posicaoMaxima;
    private float posicaoInicial;

    private Transform cam;


    public float parallaxEffect;

    void Start()
    {
        posicaoInicial = transform.position.x;
        posicaoMaxima = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(posicaoInicial + distancia, transform.position.y, transform.position.z);
    }
}

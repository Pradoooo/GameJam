using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScroller : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento da câmera

    private void Update()
    {
        // Calcula o movimento da câmera
        float moveAmount = speed * Time.deltaTime;
        transform.Translate(Vector3.right * moveAmount);
    }
}



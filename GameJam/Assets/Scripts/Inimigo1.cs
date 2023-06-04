using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
    public float speed;
    public bool direcao;

    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "paredeDireita")
        {
            Flip();
            direcao = true;
        }
        if (collision.gameObject.tag == "paredeEsquerda")
        {
            Flip();
            direcao = false;
        }
    }

    void Flip()
    {
        if (!direcao)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (direcao)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

}

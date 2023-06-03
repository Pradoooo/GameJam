using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade;
    public float forcaDoPulo;
    public float forcaDoPuloDuplo;

    public bool estaPulando;
    public bool puloDuplo;

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    private Rigidbody2D personagem;

    void Start()
    {
        personagem = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Corre();
        Pula();
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.rotation);
        }
    }

    void Corre()
    {
        Vector3 corrida = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += corrida * Time.deltaTime * velocidade;
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        //if (Input.GetAxis("Horizontal") == 0f)
        //{

        //}
    }

    void Pula()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!estaPulando)
            {
                personagem.AddForce(new Vector2(0f, forcaDoPuloDuplo), ForceMode2D.Impulse);
                puloDuplo = true;
            }
            else
            {
                if (puloDuplo)
                {
                    personagem.AddForce(new Vector2(0f, forcaDoPulo), ForceMode2D.Impulse);
                    puloDuplo = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            estaPulando = false;
            Debug.Log("estaPulando = " + estaPulando);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            estaPulando = true;
            Debug.Log ("estaPulando = " + estaPulando);
        }
    }
}

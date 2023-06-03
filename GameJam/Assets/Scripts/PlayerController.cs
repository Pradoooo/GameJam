using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade;
    public float forcaDoPulo;
    public float forcaDoPuloDuplo;
    public string direcao;

    public bool estaPulando;
    public bool puloDuplo;
    public bool hasWeapon = true;

    public ProjectileBehaviour ProjectilePre;
    public Transform LaunchOffset;
    public Transform feet;

    public GameObject garfoquica;

    private Rigidbody2D personagem;

    void Start()
    {
        personagem = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Corre();
        Pula();
        Arremessa();
        Quica();
    }

    void Arremessa()
    {
        if (Input.GetButtonDown("Fire1") && hasWeapon == true)
        {
            hasWeapon = false;
            Instantiate(ProjectilePre, LaunchOffset.position, LaunchOffset.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            hasWeapon = true;
            
        }
    }

    void Corre()
    {
        Vector3 corrida = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += corrida * Time.deltaTime * velocidade;
        if (Input.GetAxis("Horizontal") > 0f)
        {
            direcao = "direita";
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            direcao = "esquerda";
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
            forcaDoPuloDuplo = 10;
            estaPulando = false;
            Debug.Log("estaPulando = " + estaPulando);
            
        }
        if(collision.gameObject.layer == 9)
        {
            forcaDoPuloDuplo = 20;
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
        if(collision.gameObject.layer == 9)
        {
            estaPulando = true;
            Debug.Log("estaPulando = " + estaPulando);
        }
    }
    void Quica()
    {
        if (estaPulando)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                garfoquica.SetActive(true);
            }
        }

    }
}

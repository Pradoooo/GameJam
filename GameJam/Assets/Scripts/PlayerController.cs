using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float velocidade;
    public float forcaDoPulo;
    public float forcaDoPuloDuplo;
    public float speed = 0f;

    public string direcao;

    public bool estaPulando;
    public bool puloDuplo;
    public bool hasWeapon = true;

    private int vida;
    public int vidaMaxima = 4;


    public ProjectileBehaviour ProjectilePre;
    public Transform LaunchOffset;
    public Transform feet;
    public PhysicsMaterial2D quica;
    public Animator animator;


    [SerializeField] GameObject vidaOn0;
    [SerializeField] GameObject vidaOn1;
    [SerializeField] GameObject vidaOn2;
    [SerializeField] GameObject vidaOn3;

    private Rigidbody2D personagem;


    void Start()
    {
        personagem = GetComponent<Rigidbody2D>();
        vida = vidaMaxima;
    }

    void Update()
    {
        speed = Input.GetAxisRaw("Horizontal") * velocidade;
        Corre();
        Pula();
        Arremessa();
        Quica();
        animator.SetFloat("Speed", Mathf.Abs(speed));

    }

    void Arremessa()
    {
        if (Input.GetButtonDown("Fire1") && hasWeapon == true)
        {
            hasWeapon = false;
            animator.SetBool("HasWeapon", false);
            animator.SetTrigger("Attack");
            Instantiate(ProjectilePre, LaunchOffset.position, LaunchOffset.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            hasWeapon = true;
            animator.SetBool("HasWeapon", true);

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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            forcaDoPuloDuplo = 10;
            estaPulando = false;
            Debug.Log("estaPulando = " + estaPulando);

        }
        if (collision.gameObject.layer == 9)
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
            Debug.Log("estaPulando = " + estaPulando);
        }
        if (collision.gameObject.layer == 9)
        {
            estaPulando = true;
            Debug.Log("estaPulando = " + estaPulando);
        }
    }
    void Quica()
    {
        if (estaPulando && hasWeapon == true)
        {
            animator.SetBool("isJumping", true);
            if (Input.GetKey(KeyCode.E))
            {
                personagem.sharedMaterial = quica;
                animator.SetTrigger("Bounce");
                animator.SetBool("isJumping", false);
            }
            else
            {
                personagem.sharedMaterial = null;
            }
        }
        else
        {
            
            animator.SetBool("isJumping", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Dano();
        }
    }

    public void Dano()
    {
        vida -= 1;
        Debug.Log(vida);
        if (vida == 1)
        {
            vidaOn0.SetActive(false);
            vidaOn1.SetActive(true);
            vidaOn2.SetActive(false);
            vidaOn3.SetActive(false);
        }else
        if (vida == 2)
        {
            vidaOn0.SetActive(false);
            vidaOn1.SetActive(false);
            vidaOn2.SetActive(true);
            vidaOn3.SetActive(false);
        }else
        if (vida == 3)
        {
            vidaOn0.SetActive(false);
            vidaOn1.SetActive(false);
            vidaOn2.SetActive(false);
            vidaOn3.SetActive(true);
        }else

        if (vida <= 0)
        {
            vidaOn0.SetActive(true);
            vidaOn1.SetActive(false);
            vidaOn2.SetActive(false);
            vidaOn3.SetActive(false);
            Debug.Log("GameOver");
        }
    }
}

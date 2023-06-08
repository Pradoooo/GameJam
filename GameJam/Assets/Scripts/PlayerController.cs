using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public AudioSource audioSourceAttack;
    public AudioSource audioSourceJump;
    public AudioSource audioSourceDamage;
    public AudioSource audioSourceDeath;
    public AudioSource audioSourceVaca;
    

    public float velocidade;
    public float forcaDoPulo;
    public float forcaDoPuloDuplo;
    public float speed = 0f;
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;

    public string direcao;

    public bool estaPulando;
    public bool puloDuplo;
    public bool hasWeapon = true;
    public bool isAtk;
    private bool isTakingDamage = false;
    private bool takingdmg = false;

    private int vida;
    public int vidaMaxima = 4;
    public int qtdvacas = 0;




    public ProjectileBehaviour ProjectilePre;
    public Transform LaunchOffset;
    public Transform feet;
    public PhysicsMaterial2D quica;
    public Animator animator;
    public Transform enemy;
    

    [SerializeField] GameObject vacaspawn;
    [SerializeField] GameObject vidaOn0;
    [SerializeField] GameObject vidaOn1;
    [SerializeField] GameObject vidaOn2;
    [SerializeField] GameObject vidaOn3;
    [SerializeField] GameObject vacaOn1;
    [SerializeField] GameObject vacaOn2;
    [SerializeField] GameObject vacaOn3;


    private Rigidbody2D personagem;


    void Start()
    {
        personagem = GetComponent<Rigidbody2D>();
        vida = vidaMaxima;
        qtdvacas = 0;
        vacaOn1.SetActive(false);
        vacaOn2.SetActive(false);
        vacaOn3.SetActive(false);
    }

    void Update()
    {
        speed = Input.GetAxisRaw("Horizontal") * velocidade;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Arremessa();
        Corre();
        Pula();
        Quica();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("prisao") && isAtk == true)
        {
            Destroy(collision.gameObject);
            qtdvacas++;
            vacas();
            audioSourceVaca.Play();
            Instantiate(vacaspawn, transform.position, transform.rotation);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chão") || collision.gameObject.CompareTag("garfo") || collision.gameObject.CompareTag("prisao") || collision.gameObject.CompareTag("vaca"))
        {
            estaPulando = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chão") || collision.gameObject.CompareTag("garfo") || collision.gameObject.CompareTag("prisao") || collision.gameObject.CompareTag("vaca"))
        {
            estaPulando = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {

            enemy = collision.transform;
            Dano();
            if(vida > 0)
            {
                animator.SetBool("Damage", true);
            }
        }
        if (collision.gameObject.tag == "boss")
        {
            Dano();
            Dano();
            Dano();
        }
    }


    void Arremessa()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasWeapon == true)
        {
            audioSourceAttack.Play();
            hasWeapon = false;
            animator.SetBool("HasWeapon", false);
            animator.SetTrigger("Attack");
            Instantiate(ProjectilePre, LaunchOffset.position, LaunchOffset.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Q))
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
    }

    void Pula()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            audioSourceJump.Play();
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

    void Quica()

    {
        if (estaPulando && hasWeapon == true)
        {
            animator.SetBool("isJumping", true);
            if (Input.GetKey(KeyCode.E))
            {
                isAtk = true;
                personagem.sharedMaterial = quica;
                animator.SetTrigger("Bounce");
                animator.SetBool("isJumping", false);
            }
            else
            {
                personagem.sharedMaterial = null;
                isAtk = false;
            }
        }
        else
        {

            animator.SetBool("isJumping", false);
        }
    }

    public void Dano()
    {
        audioSourceDamage.Play();
        takingdmg = true;

        vida -= 1;
        if (vida == 1)
        {
            vidaOn0.SetActive(false);
            vidaOn1.SetActive(true);
            vidaOn2.SetActive(false);
            vidaOn3.SetActive(false);
        }
        else
        if (vida == 2)
        {
            vidaOn0.SetActive(false);
            vidaOn1.SetActive(false);
            vidaOn2.SetActive(true);
            vidaOn3.SetActive(false);
        }
        else
        if (vida == 3)
        {
            vidaOn0.SetActive(false);
            vidaOn1.SetActive(false);
            vidaOn2.SetActive(false);
            vidaOn3.SetActive(true);
        }
        else

        if (vida <= 0)
        {
            vidaOn0.SetActive(true);
            vidaOn1.SetActive(false);
            vidaOn2.SetActive(false);
            vidaOn3.SetActive(false);
            audioSourceDeath.Play();
            animator.SetTrigger("Death");
            GameManager.instance.GameOver();
        }
    }

    public void vacas()
    {

        if (qtdvacas == 1)
        {
            vacaOn1.SetActive(true);
            vacaOn2.SetActive(false);
            vacaOn3.SetActive(false);
        }
        else
                if (qtdvacas == 2)
        {
            vacaOn1.SetActive(true);
            vacaOn2.SetActive(true);
            vacaOn3.SetActive(false);
        }
        else
                if (qtdvacas == 3)
        {
            vacaOn1.SetActive(true);
            vacaOn2.SetActive(true);
            vacaOn3.SetActive(true);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
                if(nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
                else{
                SceneManager.LoadScene("Menu");
            }

        }
        else

                if (qtdvacas == 0)
        {
            vacaOn1.SetActive(false);
            vacaOn2.SetActive(false);
            vacaOn3.SetActive(false);
        }
    }

    public void AnimationFinished()
    {
        GameManager.instance.GameOver();
    }

    public void DmgFinished()
    {
        takingdmg = false;
        animator.SetBool("Damage", false);
    }
    
}

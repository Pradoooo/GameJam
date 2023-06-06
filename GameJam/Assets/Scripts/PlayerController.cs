using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
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

    private int vida;
    public int vidaMaxima = 4;
    public int qtdvacas = 0;


    public ProjectileBehaviour ProjectilePre;
    public Transform LaunchOffset;
    public Transform feet;
    public PhysicsMaterial2D quica;
    public Animator animator;
    public Transform enemy;
    
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chão") || collision.gameObject.CompareTag("garfo"))
        {
            estaPulando = false;
            Debug.Log("estaPulando = " + estaPulando);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chão") || collision.gameObject.CompareTag("garfo"))
        {
            estaPulando = true;
            Debug.Log("estaPulando = " + estaPulando);
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
                animator.SetTrigger("Damage");
            }
        }
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
        if (!isTakingDamage)
        {
            Vector2 knockbackDirection = transform.position - enemy.position;
            knockbackDirection.Normalize();
            StartCoroutine(DoKnockback(knockbackDirection));
        }

        vida -= 1;
        Debug.Log(vida);
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
            Debug.Log("GameOver");
            animator.SetTrigger("Death");
            
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
        }
        else

                if (qtdvacas == 0)
        {
            vacaOn1.SetActive(false);
            vacaOn2.SetActive(false);
            vacaOn3.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("prisao") && isAtk == true)
        {
            Destroy(collision.gameObject);
            qtdvacas++;
            vacas();
        }
    }
    private IEnumerator DoKnockback(Vector2 direction)
    {
        isTakingDamage = true;

        // Aplica a força do knockback
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        // Espera a duração do knockback
        yield return new WaitForSeconds(knockbackDuration);

        // Restaura a posição normal do personagem
        rb.velocity = Vector2.zero;

        isTakingDamage = false;
    }
    public void AnimationFinished()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}


using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject ProjetilGarfo;
    public float speedGarfo = 4.5f;

    private void Start()
    {
        //rd  GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Arremesso();
        if (Input.GetButtonDown("Fire2"))
        {

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Colidiu inimgo");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chão")
        {
            speedGarfo = 0f;
        }
    }
    void Arremesso()
    {
        transform.position += -transform.right * Time.deltaTime * speedGarfo;
    }
}
   


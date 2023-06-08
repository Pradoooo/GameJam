
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject ProjetilGarfo;
    public float speedGarfo = 4.5f;
    public AudioSource audioSourceAlien;


    private void Update()
    {
        Arremesso();
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                audioSourceAlien.Play();
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
   



using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speedGarfo = 4.5f;

    private void Update()
    {
        Arremesso();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
    void Arremesso()
    {
        transform.position += -transform.right * Time.deltaTime * speedGarfo;
    }
   
}


using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speedGarfo = 4.5f;

    private void Update()
    {
        Arremesso();
        if (Input.GetButtonDown("Fire2"))
        {
            
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "parede")
        {
            speedGarfo =0f;
        }
    }
    void Arremesso()
    {
        transform.position += -transform.right * Time.deltaTime * speedGarfo;
    }
   
}

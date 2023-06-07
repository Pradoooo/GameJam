using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource audioSourceQuica;
    public void Die()
    {

        Destroy(gameObject);
        audioSourceQuica.Play();
    }
}

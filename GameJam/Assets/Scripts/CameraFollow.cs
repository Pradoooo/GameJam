using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Refer�ncia ao transform do jogador
    public float smoothSpeed = 0.5f; // Velocidade de suaviza��o do movimento da c�mera

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position; // Calcula a diferen�a inicial entre a c�mera e o jogador
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calcula a posi��o desejada da c�mera

        // Aplica uma interpola��o suave para mover a c�mera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referência ao transform do jogador
    public float smoothSpeed = 0.5f; // Velocidade de suavização do movimento da câmera

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position; // Calcula a diferença inicial entre a câmera e o jogador
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calcula a posição desejada da câmera

        // Aplica uma interpolação suave para mover a câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
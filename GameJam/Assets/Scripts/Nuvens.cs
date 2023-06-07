using UnityEngine;

public class Nuvens : MonoBehaviour
{
    public float velocidade = 1f; // Velocidade de movimento das nuvens

    void Update()
    {
        // Movimenta as nuvens da direita para a esquerda
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        // Verifica se as nuvens estão fora da tela e as reposiciona do lado direito
        if (transform.position.x < -20f)
        {
            float novaPosicaoX = Random.Range(20f, 30f); // Define uma nova posição X aleatória
            float novaPosicaoY = Random.Range(5f, 15f); // Define uma nova posição Y aleatória

            transform.position = new Vector2(novaPosicaoX, novaPosicaoY);
        }
    }
}
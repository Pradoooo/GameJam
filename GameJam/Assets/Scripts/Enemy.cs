using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        // Adicione aqui qualquer lógica adicional que você deseja executar quando o inimigo morrer,
        // como reproduzir uma animação de morte, pontuação do jogador, etc.
        Destroy(gameObject);
    }
}

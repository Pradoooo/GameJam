using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        // Adicione aqui qualquer l�gica adicional que voc� deseja executar quando o inimigo morrer,
        // como reproduzir uma anima��o de morte, pontua��o do jogador, etc.
        Destroy(gameObject);
    }
}

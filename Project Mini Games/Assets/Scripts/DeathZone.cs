using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    [SerializeField] private float TimeToRestart = 2f;

    // Este m�todo � chamado automaticamente quando algo entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou � o jogador (voc� pode ajustar a tag do jogador)
        if (other.CompareTag("Player"))
        {
            // Chama uma fun��o para lidar com a morte do jogador
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        // Coloque aqui qualquer l�gica que voc� queira executar quando o jogador morrer
        Debug.Log("O jogador morreu!");

        // Reinicia o jogo ap�s um breve atraso (voc� pode ajustar o tempo conforme necess�rio)
        Invoke("RestartGame", TimeToRestart);
    }

    private void RestartGame()
    {
        // Reinicia a cena atual (certifique-se de ter uma cena �nica na build settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

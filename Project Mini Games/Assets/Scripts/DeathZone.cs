using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    [SerializeField] private float TimeToRestart = 2f;

    // Este método é chamado automaticamente quando algo entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou é o jogador (você pode ajustar a tag do jogador)
        if (other.CompareTag("Player"))
        {
            // Chama uma função para lidar com a morte do jogador
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        // Coloque aqui qualquer lógica que você queira executar quando o jogador morrer
        Debug.Log("O jogador morreu!");

        // Reinicia o jogo após um breve atraso (você pode ajustar o tempo conforme necessário)
        Invoke("RestartGame", TimeToRestart);
    }

    private void RestartGame()
    {
        // Reinicia a cena atual (certifique-se de ter uma cena única na build settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton para acesso global

    [SerializeField] private float timeToRestart = 2f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Victory()
    {
        // Execute qualquer l�gica de vit�ria aqui (por exemplo, transi��o de cena, exibi��o de mensagem, etc.)
        Debug.Log("Voc� completou a fase! Vit�ria!");
        RestartGame(timeToRestart);

        // Parar o jogador de andar
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.StopMoving();
        }
    }

    // M�todo para reiniciar o jogo com um atraso especificado
    public void RestartGame(float timeToRestart)
    {
        StartCoroutine(RestartGameCoroutine(timeToRestart));
    }

    private IEnumerator RestartGameCoroutine(float timeToRestart)
    {
        yield return new WaitForSeconds(timeToRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

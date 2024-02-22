using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton para acesso global

    [SerializeField] private float timeToRestart = 2f;
    [SerializeField] private float timeToNextLevel = 2f;

    private int currentLevelIndex; // Índice do nível atual

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

    private void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Defeat()
    {
        // Execute qualquer lógica de morte aqui (por exemplo, exibição de mensagem, etc.)
        Debug.Log("Você morreu! Reiniciando o nível...");
        RestartLevel(timeToRestart);
    }

    public void Victory()
    {
        // Execute qualquer lógica de vitória aqui (por exemplo, transição de cena, exibição de mensagem, etc.)
        Debug.Log("Você completou a fase! Avançando para o próximo nível...");

        //// Parar o jogador de andar
        PlayerControllerJoystick playerControllerJoystick = FindObjectOfType<PlayerControllerJoystick>();

        if (playerControllerJoystick != null)
        {
            playerControllerJoystick.StopMoving();
        }
        LoadNextLevel(timeToNextLevel);
    }

    // Método para reiniciar o nível atual com um atraso especificado
    private void RestartLevel(float timeToRestart)
    {
        StartCoroutine(RestartLevelCoroutine(timeToRestart));
    }

    private IEnumerator RestartLevelCoroutine(float timeToRestart)
    {
        yield return new WaitForSeconds(timeToRestart);
        SceneManager.LoadScene(currentLevelIndex);
    }

    // Método para carregar o próximo nível com um atraso especificado
    private void LoadNextLevel(float timeToNextLevel)
    {
        StartCoroutine(LoadNextLevelCoroutine(timeToNextLevel));
    }

    private IEnumerator LoadNextLevelCoroutine(float timeToNextLevel)
    {
        yield return new WaitForSeconds(timeToNextLevel);

        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            // Se chegarmos ao último nível, volte ao primeiro nível
            SceneManager.LoadScene(0);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); // Carrega a segunda cena, assumindo que a primeira cena é o menu inicial
    }
}

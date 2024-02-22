using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton para acesso global

    [SerializeField] private float timeToRestart = 2f;
    [SerializeField] private float timeToNextLevel = 2f;

    private int currentLevelIndex; // �ndice do n�vel atual

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
        // Execute qualquer l�gica de morte aqui (por exemplo, exibi��o de mensagem, etc.)
        Debug.Log("Voc� morreu! Reiniciando o n�vel...");
        RestartLevel(timeToRestart);
    }

    public void Victory()
    {
        // Execute qualquer l�gica de vit�ria aqui (por exemplo, transi��o de cena, exibi��o de mensagem, etc.)
        Debug.Log("Voc� completou a fase! Avan�ando para o pr�ximo n�vel...");

        //// Parar o jogador de andar
        PlayerControllerJoystick playerControllerJoystick = FindObjectOfType<PlayerControllerJoystick>();

        if (playerControllerJoystick != null)
        {
            playerControllerJoystick.StopMoving();
        }
        LoadNextLevel(timeToNextLevel);
    }

    // M�todo para reiniciar o n�vel atual com um atraso especificado
    private void RestartLevel(float timeToRestart)
    {
        StartCoroutine(RestartLevelCoroutine(timeToRestart));
    }

    private IEnumerator RestartLevelCoroutine(float timeToRestart)
    {
        yield return new WaitForSeconds(timeToRestart);
        SceneManager.LoadScene(currentLevelIndex);
    }

    // M�todo para carregar o pr�ximo n�vel com um atraso especificado
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
            // Se chegarmos ao �ltimo n�vel, volte ao primeiro n�vel
            SceneManager.LoadScene(0);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); // Carrega a segunda cena, assumindo que a primeira cena � o menu inicial
    }
}

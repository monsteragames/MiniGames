using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; } // Singleton para acesso global

    private List<GameObject> collectibles = new List<GameObject>(); // Lista de colecion�veis ativos
    private int totalItems = 0; // Total de itens na cena
    private int collectedItems = 0; // Total de itens coletados

    [SerializeField] private TMP_Text collectiblesText; // Refer�ncia ao objeto de texto para exibir a contagem de colecion�veis

    [SerializeField] private float textVisibleDuration = 2f; // Dura��o em segundos que o texto ser� vis�vel ap�s a coleta

    private float textVisibleTimer = 0f; // Contador de tempo para controlar a visibilidade do texto
    private bool isTextVisible = false; // Indica se o texto est� vis�vel

    [SerializeField] private float fadeSpeed = 1f; // Velocidade de fade-in e fade-out

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
        HideCollectiblesText();
    }

    private void Update()
    {
        if (isTextVisible)
        {
            textVisibleTimer -= Time.deltaTime;

            if (textVisibleTimer <= 0f)
            {
                HideCollectiblesText();
            }
        }
    }

    public void RegisterCollectible(GameObject collectible)
    {
        collectibles.Add(collectible); // Adiciona um colecion�vel � lista
        totalItems++;
        UpdateCollectiblesText();
    }

    public void UnregisterCollectible(GameObject collectible)
    {
        collectibles.Remove(collectible); // Remove um colecion�vel da lista
        totalItems--;
        UpdateCollectiblesText();
    }

    public void ItemCollected()
    {
        collectedItems++;
        Debug.Log("Coletou");

        // Verifica se todos os itens foram coletados
        if (collectedItems >= totalItems)
        {
            // Todos os itens foram coletados, ativar a condi��o de vit�ria
            GameManager.Instance.Victory();
        }

        ShowCollectiblesText();
        textVisibleTimer = textVisibleDuration;
        isTextVisible = true;

        UpdateCollectiblesText();
    }

    public void Reset()
    {
        // Redefine as contagens de colecion�veis para seus valores iniciais
        collectedItems = 0;
        totalItems = 0;

        // Limpa a lista de colecion�veis
        collectibles.Clear();
        UpdateCollectiblesText();
    }

    // M�todo para atualizar o texto com a contagem de colecion�veis
    private void UpdateCollectiblesText()
    {
        if (collectiblesText != null)
        {
            collectiblesText.text = "Colecion�veis: " + collectedItems + " / " + totalItems;
        }
    }

    // M�todo para tornar o texto dos colecion�veis vis�vel
    private void ShowCollectiblesText()
    {
        if (collectiblesText != null)
        {
            collectiblesText.gameObject.SetActive(true);
            StartCoroutine(FadeInText());
        }
    }

    // M�todo para tornar o texto dos colecion�veis invis�vel
    private void HideCollectiblesText()
    {
        if (collectiblesText != null)
        {
            StartCoroutine(FadeOutText());
        }
    }

    // Corotina para realizar o fade-in do texto gradualmente
    private IEnumerator FadeInText()
    {
        Color textColor = collectiblesText.color;
        float alpha = 0f;

        while (alpha < 1f)
        {
            alpha += fadeSpeed * Time.deltaTime;
            textColor.a = alpha;
            collectiblesText.color = textColor;
            yield return null;
        }
    }

    // Corotina para realizar o fade-out do texto gradualmente
    private IEnumerator FadeOutText()
    {
        Color textColor = collectiblesText.color;
        float alpha = 1f;

        while (alpha > 0f)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            textColor.a = alpha;
            collectiblesText.color = textColor;
            yield return null;
        }

        collectiblesText.gameObject.SetActive(false);
        isTextVisible = false;
    }
}

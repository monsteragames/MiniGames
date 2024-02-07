using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; } // Singleton para acesso global

    private List<GameObject> collectibles = new List<GameObject>(); // Lista de colecionáveis ativos
    private int totalItems = 0; // Total de itens na cena
    private int collectedItems = 0; // Total de itens coletados

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

    public void RegisterCollectible(GameObject collectible)
    {
        collectibles.Add(collectible); // Adiciona um colecionável à lista
        totalItems++;
    }

    public void UnregisterCollectible(GameObject collectible)
    {
        collectibles.Remove(collectible); // Remove um colecionável da lista
        totalItems--;
    }

    public void ItemCollected()
    {
        collectedItems++;
        Debug.Log("Coletou");

        // Verifica se todos os itens foram coletados
        if (collectedItems >= totalItems)
        {
            // Todos os itens foram coletados, ativar a condição de vitória
            GameManager.Instance.Victory();
        }
    }

    public void Reset()
    {
        // Redefine as contagens de colecionáveis para seus valores iniciais
        collectedItems = 0;
        totalItems = 0;

        // Limpa a lista de colecionáveis
        collectibles.Clear();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void CollectCollectible(int collectibleIndex)
    {
        // Encontra todos os colecionáveis UI na cena
        CollectibleUIItem[] collectibleUIItems = FindObjectsOfType<CollectibleUIItem>();

        // Ativa o colecionável UI correspondente ao índice coletado
        foreach (CollectibleUIItem uiItem in collectibleUIItems)
        {
            if (uiItem.collectibleIndex == collectibleIndex)
            {
                uiItem.ActivateCollectibleUI();
                break;
            }
        }
    }
}

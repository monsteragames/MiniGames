using UnityEngine;
using UnityEngine.UI;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; }

    [SerializeField] private GameObject collectibleUIItemPrefab; // Prefab do item de UI do colecionável
    [SerializeField] private Transform collectibleUIParent; // Transform do pai para os itens de UI do colecionável

    private CollectibleUIItem[] collectibleUIItems; // Array para armazenar os itens de UI do colecionável
    private float horizontalSpacing = 100f; // Espaçamento horizontal entre as imagens da UI

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
        // Ativa o colecionável UI correspondente ao índice coletado
        Transform collectibleUI = collectibleUIParent.GetChild(collectibleIndex);
        CollectibleUIItem uiItem = collectibleUI.GetComponent<CollectibleUIItem>();
        if (uiItem != null)
        {
            uiItem.ActivateCollectibleUI();
        }
    }

    // Método para criar os itens de UI para os colecionáveis
    public void CreateCollectibleUIItems(int totalCollectibles)
    {
        // Inicializar o array de itens de UI com o tamanho do número de colecionáveis
        collectibleUIItems = new CollectibleUIItem[totalCollectibles];

        // Iterar sobre o número total de colecionáveis para criar e configurar cada item de UI
        for (int i = 0; i < totalCollectibles; i++)
        {
            // Calcular a posição horizontal do item de UI com base no índice e no espaçamento horizontal
            float xPos = i * horizontalSpacing;

            // Instanciar um objeto de item de UI do colecionável a partir do prefab
            GameObject collectibleUIItemObject = Instantiate(collectibleUIItemPrefab, collectibleUIParent);

            // Definir a posição do item de UI
            RectTransform rectTransform = collectibleUIItemObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(xPos, 0f);

            // Obter o componente CollectibleUIItem do objeto instanciado
            CollectibleUIItem collectibleUIItem = collectibleUIItemObject.GetComponent<CollectibleUIItem>();

            // Verificar se o componente CollectibleUIItem foi encontrado
            if (collectibleUIItem != null)
            {
                // Definir o índice do colecionável para corresponder ao índice na iteração
                collectibleUIItem.collectibleIndex = i;

                // Adicionar o item de UI ao array de itens de UI
                collectibleUIItems[i] = collectibleUIItem;
            }
        }
    }
}
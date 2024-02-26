using UnityEngine;
using UnityEngine.UI;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; }

    [SerializeField] private GameObject collectibleUIItemPrefab; // Prefab do item de UI do colecionável
    [SerializeField] private Transform collectibleUIParent; // Transform do pai para os itens de UI do colecionável

    [SerializeField] private GameObject collectibleUIShadowPrefab; // Prefab da sombra da UI do colecionável
    [SerializeField] private Transform collectibleUIShadowParent; // Transform do pai para os itens de UI do colecionável

    private CollectibleUIItem[] collectibleUIItems; // Array para armazenar os itens de UI do colecionável
    private CollectibleUIItem[] collectibleUIShadows; // Array para armazenar as sombras da UI do colecionável
    private float horizontalSpacing = 200f; // Espaçamento horizontal entre as imagens da UI

   private int totalCollectibles; // Número total de colecionáveis na cena
    private int collectedCount = 0; // Contador de colecionáveis coletados

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

    private void Start()
    {
        // Cria os itens de UI com base no número total de colecionáveis na cena
        totalCollectibles = FindObjectsOfType<CollectibleController>().Length;
       
        CreateCollectibleUIItems(totalCollectibles);

        // Cria as sombras da UI com base no número total de colecionáveis na cena
        CreateCollectibleUIShadows(totalCollectibles);
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

        // Ativa o colecionável UI correspondente ao índice coletado
        Transform collectibleUIShadow = collectibleUIShadowParent.GetChild(collectibleIndex);
        CollectibleUIItem uiItemShadow = collectibleUIShadow.GetComponent<CollectibleUIItem>();

        // Atualiza o contador de colecionáveis coletados
        collectedCount++;

        CheckVictory();
    }

    // Método para criar os itens de UI para os colecionáveis
    public void CreateCollectibleUIItems(int totalColl)
    {
        // Inicializar o array de itens de UI com o tamanho do número de colecionáveis
        collectibleUIItems = new CollectibleUIItem[totalColl];

        // Iterar sobre o número total de colecionáveis para criar e configurar cada item de UI
        for (int i = 0; i < totalColl; i++)
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

    // Método para criar as sombras da UI para os colecionáveis
    private void CreateCollectibleUIShadows(int totalColl)
    {
        // Inicializar o array de itens de UI com o tamanho do número de colecionáveis
        collectibleUIShadows = new CollectibleUIItem[totalColl];

        // Iterar sobre o número total de colecionáveis para criar e configurar cada item de UI
        for (int i = 0; i < totalColl; i++)
        {
            // Calcular a posição horizontal do item de UI com base no índice e no espaçamento horizontal
            float xPos = i * horizontalSpacing;

            // Instanciar um objeto de item de UI do colecionável a partir do prefab
            GameObject collectibleUIShadowItemObject = Instantiate(collectibleUIShadowPrefab, collectibleUIShadowParent);

            // Definir a posição do item de UI
            RectTransform rectTransform = collectibleUIShadowItemObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(xPos, 0f);

            // Obter o componente CollectibleUIItem do objeto instanciado
            CollectibleUIItem collectibleUIShadowItem = collectibleUIShadowItemObject.GetComponent<CollectibleUIItem>();

            // Verificar se o componente CollectibleUIItem foi encontrado
            if (collectibleUIShadowItem != null)
            {
                // Definir o índice do colecionável para corresponder ao índice na iteração
                collectibleUIShadowItem.collectibleIndex = i;

                // Adicionar o item de UI ao array de itens de UI
                collectibleUIShadows[i] = collectibleUIShadowItem;
            }
        }
    }

    public void Reset()
    {
        // Itera sobre todos os itens de UI dos colecionáveis
        foreach (CollectibleUIItem uiItem in collectibleUIItems)
        {
            // Desativa a imagem do item de UI
            uiItem.gameObject.SetActive(false);
        }

        // Itera sobre todas as sombras da UI dos colecionáveis
        foreach (CollectibleUIItem shadowItem in collectibleUIShadows)
        {
            // Ativa a imagem da sombra do item de UI
            shadowItem.gameObject.SetActive(true);
        }
    }

    private void CheckVictory()
    {
        // Verifica se todos os colecionáveis foram coletados
        if (collectedCount == totalCollectibles)
        {
            GameManager.Instance.Victory();
        }
    }
}
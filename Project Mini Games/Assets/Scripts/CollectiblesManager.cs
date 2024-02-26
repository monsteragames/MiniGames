using UnityEngine;
using UnityEngine.UI;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; }

    [SerializeField] private GameObject collectibleUIItemPrefab; // Prefab do item de UI do colecion�vel
    [SerializeField] private Transform collectibleUIParent; // Transform do pai para os itens de UI do colecion�vel

    [SerializeField] private GameObject collectibleUIShadowPrefab; // Prefab da sombra da UI do colecion�vel
    [SerializeField] private Transform collectibleUIShadowParent; // Transform do pai para os itens de UI do colecion�vel

    private CollectibleUIItem[] collectibleUIItems; // Array para armazenar os itens de UI do colecion�vel
    private CollectibleUIItem[] collectibleUIShadows; // Array para armazenar as sombras da UI do colecion�vel
    private float horizontalSpacing = 200f; // Espa�amento horizontal entre as imagens da UI

   private int totalCollectibles; // N�mero total de colecion�veis na cena
    private int collectedCount = 0; // Contador de colecion�veis coletados

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
        // Cria os itens de UI com base no n�mero total de colecion�veis na cena
        totalCollectibles = FindObjectsOfType<CollectibleController>().Length;
       
        CreateCollectibleUIItems(totalCollectibles);

        // Cria as sombras da UI com base no n�mero total de colecion�veis na cena
        CreateCollectibleUIShadows(totalCollectibles);
    }


    public void CollectCollectible(int collectibleIndex)
    {
        // Ativa o colecion�vel UI correspondente ao �ndice coletado
        Transform collectibleUI = collectibleUIParent.GetChild(collectibleIndex);
        CollectibleUIItem uiItem = collectibleUI.GetComponent<CollectibleUIItem>();
        if (uiItem != null)
        {
            uiItem.ActivateCollectibleUI();
        }

        // Ativa o colecion�vel UI correspondente ao �ndice coletado
        Transform collectibleUIShadow = collectibleUIShadowParent.GetChild(collectibleIndex);
        CollectibleUIItem uiItemShadow = collectibleUIShadow.GetComponent<CollectibleUIItem>();

        // Atualiza o contador de colecion�veis coletados
        collectedCount++;

        CheckVictory();
    }

    // M�todo para criar os itens de UI para os colecion�veis
    public void CreateCollectibleUIItems(int totalColl)
    {
        // Inicializar o array de itens de UI com o tamanho do n�mero de colecion�veis
        collectibleUIItems = new CollectibleUIItem[totalColl];

        // Iterar sobre o n�mero total de colecion�veis para criar e configurar cada item de UI
        for (int i = 0; i < totalColl; i++)
        {
            // Calcular a posi��o horizontal do item de UI com base no �ndice e no espa�amento horizontal
            float xPos = i * horizontalSpacing;

            // Instanciar um objeto de item de UI do colecion�vel a partir do prefab
            GameObject collectibleUIItemObject = Instantiate(collectibleUIItemPrefab, collectibleUIParent);

            // Definir a posi��o do item de UI
            RectTransform rectTransform = collectibleUIItemObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(xPos, 0f);

            // Obter o componente CollectibleUIItem do objeto instanciado
            CollectibleUIItem collectibleUIItem = collectibleUIItemObject.GetComponent<CollectibleUIItem>();

            // Verificar se o componente CollectibleUIItem foi encontrado
            if (collectibleUIItem != null)
            {
                // Definir o �ndice do colecion�vel para corresponder ao �ndice na itera��o
                collectibleUIItem.collectibleIndex = i;

                // Adicionar o item de UI ao array de itens de UI
                collectibleUIItems[i] = collectibleUIItem;
            }
        }
    }

    // M�todo para criar as sombras da UI para os colecion�veis
    private void CreateCollectibleUIShadows(int totalColl)
    {
        // Inicializar o array de itens de UI com o tamanho do n�mero de colecion�veis
        collectibleUIShadows = new CollectibleUIItem[totalColl];

        // Iterar sobre o n�mero total de colecion�veis para criar e configurar cada item de UI
        for (int i = 0; i < totalColl; i++)
        {
            // Calcular a posi��o horizontal do item de UI com base no �ndice e no espa�amento horizontal
            float xPos = i * horizontalSpacing;

            // Instanciar um objeto de item de UI do colecion�vel a partir do prefab
            GameObject collectibleUIShadowItemObject = Instantiate(collectibleUIShadowPrefab, collectibleUIShadowParent);

            // Definir a posi��o do item de UI
            RectTransform rectTransform = collectibleUIShadowItemObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(xPos, 0f);

            // Obter o componente CollectibleUIItem do objeto instanciado
            CollectibleUIItem collectibleUIShadowItem = collectibleUIShadowItemObject.GetComponent<CollectibleUIItem>();

            // Verificar se o componente CollectibleUIItem foi encontrado
            if (collectibleUIShadowItem != null)
            {
                // Definir o �ndice do colecion�vel para corresponder ao �ndice na itera��o
                collectibleUIShadowItem.collectibleIndex = i;

                // Adicionar o item de UI ao array de itens de UI
                collectibleUIShadows[i] = collectibleUIShadowItem;
            }
        }
    }

    public void Reset()
    {
        // Itera sobre todos os itens de UI dos colecion�veis
        foreach (CollectibleUIItem uiItem in collectibleUIItems)
        {
            // Desativa a imagem do item de UI
            uiItem.gameObject.SetActive(false);
        }

        // Itera sobre todas as sombras da UI dos colecion�veis
        foreach (CollectibleUIItem shadowItem in collectibleUIShadows)
        {
            // Ativa a imagem da sombra do item de UI
            shadowItem.gameObject.SetActive(true);
        }
    }

    private void CheckVictory()
    {
        // Verifica se todos os colecion�veis foram coletados
        if (collectedCount == totalCollectibles)
        {
            GameManager.Instance.Victory();
        }
    }
}
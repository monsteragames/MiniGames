using UnityEngine;
using UnityEngine.UI;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; }

    [SerializeField] private GameObject collectibleUIItemPrefab; // Prefab do item de UI do colecion�vel
    [SerializeField] private Transform collectibleUIParent; // Transform do pai para os itens de UI do colecion�vel

    private CollectibleUIItem[] collectibleUIItems; // Array para armazenar os itens de UI do colecion�vel
    private float horizontalSpacing = 100f; // Espa�amento horizontal entre as imagens da UI

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
        // Ativa o colecion�vel UI correspondente ao �ndice coletado
        Transform collectibleUI = collectibleUIParent.GetChild(collectibleIndex);
        CollectibleUIItem uiItem = collectibleUI.GetComponent<CollectibleUIItem>();
        if (uiItem != null)
        {
            uiItem.ActivateCollectibleUI();
        }
    }

    // M�todo para criar os itens de UI para os colecion�veis
    public void CreateCollectibleUIItems(int totalCollectibles)
    {
        // Inicializar o array de itens de UI com o tamanho do n�mero de colecion�veis
        collectibleUIItems = new CollectibleUIItem[totalCollectibles];

        // Iterar sobre o n�mero total de colecion�veis para criar e configurar cada item de UI
        for (int i = 0; i < totalCollectibles; i++)
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
}
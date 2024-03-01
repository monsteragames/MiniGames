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

    private int totalCollectibles = 0; // N�mero total de colecion�veis na cena
    private int collectedCount = 0; // Contador de colecion�veis coletados

    private bool[] collectedStatus; // Array para armazenar o status de coleta de cada colecion�vel

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

    }

    public void CollectCollectible(int collectibleIndex)
    {
        // Atualiza o status de coleta do colecion�vel
        collectedStatus[collectibleIndex] = true;

        // Atualiza o contador de colecion�veis coletados
        collectedCount++;

        // Atualiza a UI
        UpdateCollectibleUI();

        CheckVictory();
    }

    private void UpdateCollectibleUI()
    {
        // Ativa as sombras da UI de todos os colecion�veis
        foreach (CollectibleUIItem shadowItem in collectibleUIShadows)
        {
            shadowItem.ActivateUI();
        }

        // Ativa as imagens dos colecion�veis coletados
        for (int i = 0; i < collectibleUIItems.Length; i++)
        {
            if (collectedStatus[i])
            {
                collectibleUIItems[i].ActivateUI();
            }
        }
    }

    // M�todo para criar os itens de UI para os colecion�veis
    public void CreateCollectibleUIItems(int totalColl)
    {
        // Inicializar o array de itens de UI com o tamanho do n�mero de colecion�veis
        collectibleUIItems = new CollectibleUIItem[totalColl];
        collectedStatus = new bool[totalColl];

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
                collectedStatus[i] = false; // Inicialmente nenhum colecion�vel foi coletado
            }
        }
    }

    // M�todo para criar as sombras da UI para os colecion�veis
    public void CreateCollectibleUIShadows(int totalColl)
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

    public void TotalCollectible(int totalColl)
    {
        totalCollectibles = totalColl; //recebe valor do numero de spawnpoints do CollictibleSpwaner
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
            // Desativa a imagem da sombra do item de UI
            shadowItem.gameObject.SetActive(false);
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

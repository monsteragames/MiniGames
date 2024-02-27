using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab; // Prefab do colecionável
    [SerializeField] private Transform[] spawnPoints;

    private CollectiblesManager collectibleManager; // Referência ao CollectibleManager
    //private static int lastAssignedIndex = -1; // Índice atribuído mais recentemente

    private void Start()
    {
        collectibleManager = CollectiblesManager.Instance;
        if (collectibleManager == null)
        {
            Debug.LogWarning("CollectibleManager não foi inicializado corretamente!");
        }
        else
        {
            int totalCollectibles = spawnPoints.Length;
            collectibleManager.CreateCollectibleUIItems(totalCollectibles); // Cria os elementos da UI para os colecionáveis
            collectibleManager.CreateCollectibleUIShadows(totalCollectibles); // Cria os elementos da UI shadow para os colecionáveis
            collectibleManager.TotalCollectible(totalCollectibles); //Envia a quantidade de coleveis para o manager
            SpawnCollectibles();
        }
    }

    private void SpawnCollectibles()
    {
        // Itera sobre cada transform filho deste objeto (que devem ser os pontos de spawn)
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i];
            GameObject collectible = Instantiate(collectiblePrefab, spawnPoint.position, Quaternion.identity);

            // Define o índice do colecionável para corresponder ao índice de spawnPoint
            collectible.GetComponent<CollectibleController>().collectibleIndex = i;
        }
    }
}

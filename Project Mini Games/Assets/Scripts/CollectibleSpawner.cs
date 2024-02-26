using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab; // Prefab do colecionável

    private void Start()
    {
        SpawnCollectibles();
    }

    private void SpawnCollectibles()
    {
        // Itera sobre cada transform filho deste objeto (que devem ser os pontos de spawn)
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform spawnPoint = transform.GetChild(i);
            GameObject collectible = Instantiate(collectiblePrefab, spawnPoint.position, Quaternion.identity);

            // Define o índice do colecionável para corresponder ao índice de spawnPoint
            collectible.GetComponent<CollectibleController>().collectibleIndex = i;
        }
    }
}

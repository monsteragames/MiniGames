using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    private CollectiblesManager collectiblesManager;

    private void Start()
    {
        collectiblesManager = CollectiblesManager.Instance;
        if (collectiblesManager == null)
        {
            Debug.LogWarning("CollectiblesManager não foi inicializado corretamente!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            if (collectiblesManager != null)
            {
                collectiblesManager.ItemCollected();
            }
        }
    }
}

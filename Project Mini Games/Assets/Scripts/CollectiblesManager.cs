using UnityEngine;
using UnityEngine.UI;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance { get; private set; }

    [SerializeField] private CollectibleUIItem[] collectibleUIItems;

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
        if (collectibleIndex >= 0 && collectibleIndex < collectibleUIItems.Length)
        {
            collectibleUIItems[collectibleIndex].ActivateCollectibleUI();
        }
    }
}

using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // �ndice do colecion�vel
    public int collectibleIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectiblesManager.Instance.CollectCollectible(collectibleIndex);
            gameObject.SetActive(false); // Desativa o objeto colecion�vel ao ser coletado
        }
    }
}

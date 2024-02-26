using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Índice do colecionável
    public int collectibleIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectiblesManager.Instance.CollectCollectible(collectibleIndex);
            gameObject.SetActive(false); // Desativa o objeto colecionável ao ser coletado
        }
    }
}

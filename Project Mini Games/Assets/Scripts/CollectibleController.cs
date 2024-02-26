using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public int collectibleIndex; // Índice do colecionável

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectiblesManager.Instance.CollectCollectible(collectibleIndex);
            gameObject.SetActive(false); // Desativa o objeto colecionável ao ser coletado
        }
    }
}
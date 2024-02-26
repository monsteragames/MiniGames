using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public int collectibleIndex; // �ndice do colecion�vel

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectiblesManager.Instance.CollectCollectible(collectibleIndex);
            gameObject.SetActive(false); // Desativa o objeto colecion�vel ao ser coletado
        }
    }
}
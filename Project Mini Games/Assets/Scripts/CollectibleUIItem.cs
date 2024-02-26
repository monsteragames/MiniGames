using UnityEngine;
using UnityEngine.UI;

public class CollectibleUIItem : MonoBehaviour
{
    public int collectibleIndex; // �ndice do colecion�vel correspondente a este item na UI

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false; // Inicialmente desativa a imagem na UI
    }

    public void ActivateCollectibleUI()
    {
        image.enabled = true; // Ativa a imagem na UI ao coletar o colecion�vel correspondente
    }
}
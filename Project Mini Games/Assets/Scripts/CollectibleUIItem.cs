using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleUIItem : MonoBehaviour
{
    public int collectibleIndex; // Índice do colecionável correspondente a este item na UI

    private Image image;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        image = GetComponent<Image>();
        //image.enabled = false; // Inicialmente desativa a imagem na UI
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    public void ActivateUI()
    {
        // Inicia o efeito de fade in
        fadeCoroutine = StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        StopFadeOut();

        // Inicializa a transparência como zero (totalmente transparente)
        float alpha = 0f;

        // Enquanto o alpha for menor que 1 (totalmente visível)
        while (alpha < 1f)
        {
            // Aumenta gradualmente o alpha
            alpha += Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            yield return null;
        }

        // Espera o tempo desejado antes de iniciar o fade out
        yield return new WaitForSeconds(3f);

        StartFadeOut();
    }

    public void StartFadeOut()
    {
        // Inicia o efeito de fade out
        fadeCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        // Enquanto o alpha for maior que 0 (totalmente transparente)
        while (image.color.a > 0f)
        {
            // Reduz gradualmente o alpha
            image.color -= new Color(0f, 0f, 0f, Time.deltaTime);

            yield return null;
        }

        // Desativa o item da UI após o fade out completo
        //image.enabled = false;
    }

    public void StopFadeOut()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
    }
}

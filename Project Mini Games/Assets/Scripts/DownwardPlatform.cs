using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardPlatform : MonoBehaviour
{
    [SerializeField] private float downwardSpeed = 2f; // Velocidade de movimento para baixo
    [SerializeField] private float maxDescent = 10f; // Limite m�ximo de descida da plataforma

    private bool playerOnPlatform = true; // Indica se o jogador est� na plataforma

    private void Update()
    {
        // Verifica se o jogador n�o est� na plataforma e se a plataforma ainda n�o atingiu o limite inferior
        if (!playerOnPlatform && transform.position.y > -maxDescent)
        {
            // Calcula a nova posi��o da plataforma
            float newY = Mathf.Max(transform.position.y - (downwardSpeed * Time.deltaTime), -maxDescent);

            // Move a plataforma para baixo
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu � o jogador
        if (other.CompareTag("Player"))
        {
            // Define que o jogador est� na plataforma
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu � o jogador
        if (other.CompareTag("Player"))
        {
            // Define que o jogador n�o est� mais na plataforma
            playerOnPlatform = false;
        }
    }
}

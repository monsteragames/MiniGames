using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardPlatform : MonoBehaviour
{
    [SerializeField] private float downwardSpeed = 2f; // Velocidade de movimento para baixo
    [SerializeField] private float maxDescent = 10f; // Limite máximo de descida da plataforma

    private bool playerOnPlatform = true; // Indica se o jogador está na plataforma

    private void Update()
    {
        // Verifica se o jogador não está na plataforma e se a plataforma ainda não atingiu o limite inferior
        if (!playerOnPlatform && transform.position.y > -maxDescent)
        {
            // Calcula a nova posição da plataforma
            float newY = Mathf.Max(transform.position.y - (downwardSpeed * Time.deltaTime), -maxDescent);

            // Move a plataforma para baixo
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (other.CompareTag("Player"))
        {
            // Define que o jogador está na plataforma
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu é o jogador
        if (other.CompareTag("Player"))
        {
            // Define que o jogador não está mais na plataforma
            playerOnPlatform = false;
        }
    }
}

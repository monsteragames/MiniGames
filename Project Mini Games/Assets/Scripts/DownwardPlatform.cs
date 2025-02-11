using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardPlatform : MonoBehaviour
{
    [SerializeField] private float downwardSpeed = 2f; // Velocidade de movimento para baixo
    [SerializeField] private float maxDescent = 10f; // Limite m�ximo de descida da plataforma

    private bool playerOnPlatform = true; // Indica se o jogador est� na plataforma

    [SerializeField] private Transform platform;
    [SerializeField] private Animator animator; // Adiciona uma refer�ncia ao componente Animator

    private void Update()
    {
        // Verifica se o jogador n�o est� na plataforma e se a plataforma ainda n�o atingiu o limite inferior
        if (!playerOnPlatform && platform.transform.position.y > -maxDescent)
        {
            // Calcula a nova posi��o da plataforma
            float newY = Mathf.Max(platform.transform.position.y - (downwardSpeed * Time.deltaTime), -maxDescent);

            // Move a plataforma para baixo
            platform.transform.position = new Vector3(platform.transform.position.x, newY, platform.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu � o jogador
        if (other.CompareTag("Player"))
        {
            // Define que o jogador est� na plataforma
            playerOnPlatform = true;

            // Atualiza o par�metro no animator para controlar a transi��o de anima��o
            animator.SetBool("Trigger", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu � o jogador
        if (other.CompareTag("Player"))
        {
            // Define que o jogador n�o est� mais na plataforma
            playerOnPlatform = false;

            // Atualiza o par�metro no animator para controlar a transi��o de anima��o
            animator.SetBool("Trigger", false);
        }
    }
}

using UnityEngine;
using System.Collections;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField] private Transform startPoint; // Ponto inicial da plataforma
    [SerializeField] private Transform endPoint; // Ponto final da plataforma
    [SerializeField] private float movementSpeed = 2f; // Velocidade de movimento da plataforma
    [SerializeField] private float stopTime = 2f; // Tempo de parada nos pontos máximo e mínimo

    private Vector3 initialPosition; // Posição inicial da plataforma
    private Vector3 targetPosition; // Posição para a qual a plataforma está se movendo
    private bool isMovingUp = true; // Indica se a plataforma está se movendo para cima
    private bool isStopping = false; // Indica se a plataforma está parando

    private void Start()
    {
        initialPosition = startPoint.position;
        targetPosition = endPoint.position;
    }

    private void Update()
    {
        // Verifica se a plataforma não está parando
        if (!isStopping)
        {
            // Move a plataforma entre os pontos inicial e final
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            // Verifica se a plataforma atingiu o ponto final
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Inverte a direção do movimento
                isMovingUp = !isMovingUp;

                // Define o próximo ponto de destino com base na direção do movimento
                targetPosition = isMovingUp ? startPoint.position : endPoint.position;

                // Inicia a contagem regressiva para parar a plataforma
                StartCoroutine(StopPlatform());
            }
        }
    }

    private IEnumerator StopPlatform()
    {
        // Define que a plataforma está parando
        isStopping = true;

        // Aguarda o tempo de parada configurado
        yield return new WaitForSeconds(stopTime);

        // Define que a plataforma não está mais parando
        isStopping = false;
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha uma linha entre os pontos inicial e final para visualização no Editor
        if (startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }
}

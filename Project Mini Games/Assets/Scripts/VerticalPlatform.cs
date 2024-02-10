using UnityEngine;
using System.Collections;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField] private Transform startPoint; // Ponto inicial da plataforma
    [SerializeField] private Transform endPoint; // Ponto final da plataforma
    [SerializeField] private float movementSpeed = 2f; // Velocidade de movimento da plataforma
    [SerializeField] private float stopTime = 2f; // Tempo de parada nos pontos m�ximo e m�nimo

    private Vector3 initialPosition; // Posi��o inicial da plataforma
    private Vector3 targetPosition; // Posi��o para a qual a plataforma est� se movendo
    private bool isMovingUp = true; // Indica se a plataforma est� se movendo para cima
    private bool isStopping = false; // Indica se a plataforma est� parando

    private void Start()
    {
        initialPosition = startPoint.position;
        targetPosition = endPoint.position;
    }

    private void Update()
    {
        // Verifica se a plataforma n�o est� parando
        if (!isStopping)
        {
            // Move a plataforma entre os pontos inicial e final
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            // Verifica se a plataforma atingiu o ponto final
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Inverte a dire��o do movimento
                isMovingUp = !isMovingUp;

                // Define o pr�ximo ponto de destino com base na dire��o do movimento
                targetPosition = isMovingUp ? startPoint.position : endPoint.position;

                // Inicia a contagem regressiva para parar a plataforma
                StartCoroutine(StopPlatform());
            }
        }
    }

    private IEnumerator StopPlatform()
    {
        // Define que a plataforma est� parando
        isStopping = true;

        // Aguarda o tempo de parada configurado
        yield return new WaitForSeconds(stopTime);

        // Define que a plataforma n�o est� mais parando
        isStopping = false;
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha uma linha entre os pontos inicial e final para visualiza��o no Editor
        if (startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }
}

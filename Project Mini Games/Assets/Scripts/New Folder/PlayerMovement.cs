using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float initialForwardSpeed = 0f; // Velocidade inicial configurada no editor
    public float swipeTurnSpeed = 2f;

    private float forwardSpeed;
    private bool hasStarted = false; // Indica se o jogador j� deu o primeiro toque

    void Start()
    {
        forwardSpeed = initialForwardSpeed; // Inicializa a velocidade conforme configurada no editor
    }

    void Update()
    {
        // Se o jogador j� come�ou e a velocidade for maior que zero, mover para frente
        if (hasStarted && forwardSpeed > 0)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

        // Swipe-based turning
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Debug.Log(touch);
            // Verifica se o jogador deu o primeiro toque
            if (touch.phase == TouchPhase.Began)
            {
                hasStarted = true;
                forwardSpeed = initialForwardSpeed; // Aplica a velocidade inicial
            }

            // Verifica se o jogador est� arrastando
            if (touch.phase == TouchPhase.Moved)
            {
                RotatePlayer(touch.deltaPosition);
            }
        }

    }


    // M�todo para rotacionar o jogador com base no arrasto do toque
    private void RotatePlayer(Vector2 swipeDelta)
    {
        // Calcula a dire��o do arrasto no espa�o mundial
        Vector3 swipeDirection = new Vector3(swipeDelta.x, 0f, swipeDelta.y).normalized;

        // Rotaciona o jogador com base na dire��o do arrasto
        Vector3 newForward = Vector3.RotateTowards(transform.forward, swipeDirection, swipeTurnSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newForward);
    }
}

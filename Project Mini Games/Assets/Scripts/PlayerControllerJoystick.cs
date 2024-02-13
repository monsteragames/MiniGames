////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;
////using EasyJoystick;

////public class PlayerControllerJoystick : MonoBehaviour
////{
////    [SerializeField] private float speed;
////    [SerializeField] private Joystick joystick;

////    private void Update ()
////    {
////        float xMovement = joystick.Horizontal();
////        float zMovement = joystick.Vertical();

////        transform.position += new Vector3(xMovement, 0f, zMovement) * speed * Time.deltaTime;

////    }
////}

//////--------------------------------------------------------------------
using UnityEngine;

public class PlayerControllerJoystick : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 720f;
    [SerializeField] private FloatingJoystick joystick;

    private Vector3 moveDirection = Vector3.zero; // Direção de movimento atual
    private bool isMoving = false; // Flag para verificar se o jogador está se movendo

    private void Update()
    {
        // Verifica se o joystick está sendo movido
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            // Define a direção de movimento com base no joystick
            moveDirection = new Vector3(joystick.Horizontal, 0f, joystick.Vertical).normalized;
            isMoving = true; // Define a flag para true para indicar que o jogador está se movendo
        }

        // Verifica se o jogador está se movendo
        if (isMoving)
        {
            // Move o jogador na direção definida com uma velocidade constante
            // transform.position += moveDirection * speed * Time.deltaTime;
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Rotaciona o jogador na direção do movimento
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    // Método para parar o movimento do jogador
    public void StopMoving()
    {
        speed = 2f;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockFeedbackManager : MonoBehaviour
{
    public ClockFeedbackSwitcher[] clockControllers;
    public float activationInterval = 1.0f; // Intervalo de ativação entre cada objeto
    public float resetDelay = 5.0f; // Tempo para reiniciar o timer após todos os objetos serem ativados

    private int currentIndex = 0;
    private float timer = 0.0f;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        // Desliga todos os objetos do timer inicialmente
        foreach (ClockFeedbackSwitcher clockController in clockControllers)
        {
            clockController.SetMaterial(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = true;
        }

        if (isRunning)
        {
            timer += Time.deltaTime;
            if (timer >= activationInterval)
            {
                timer = 0.0f;
                ActivateNextObject();
            }
        }
    }

    private void ActivateNextObject()
    {
        clockControllers[currentIndex].SetMaterial(true);
        currentIndex++;
        if (currentIndex >= clockControllers.Length)
        {
            // Todos os objetos foram ativados, reinicia o timer
            currentIndex = 0;
            isRunning = false;
            Invoke("ResetTimer", resetDelay);
        }
    }

    private void ResetTimer()
    {
        // Desliga todos os objetos do timer
        foreach (ClockFeedbackSwitcher clockController in clockControllers)
        {
            clockController.SetMaterial(false);
        }
        // Inicia o timer novamente
        isRunning = true;
    }

    public void SetRunning(bool running)
    {

        if (running)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
}

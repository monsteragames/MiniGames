using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockFeedbackSwitcher : MonoBehaviour
{
    public Material onMaterial; // Material quando está ligado
    public Material offMaterial; // Material quando está desligado

    private Renderer rend;
    private bool isOn = false; // Estado atual do material

    void Start()
    {
        // Obtém o componente Renderer do objeto
        rend = GetComponent<Renderer>();

        // Define o material inicial como desligado
        SetMaterial(isOn);
    }

    void Update()
    {
        // Verifica se a tecla de espaço foi pressionada para alternar o material
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOn = !isOn; // Inverte o estado do material
            SetMaterial(isOn); // Define o material de acordo com o novo estado
        }
    }

    // Define o material com base no estado especificado
    public void SetMaterial(bool isOn)
    {
        if (isOn)
        {
            // Aplica o material ligado
            rend.material = onMaterial;
        }
        else
        {
            // Aplica o material desligado
            rend.material = offMaterial;
        }
    }
}



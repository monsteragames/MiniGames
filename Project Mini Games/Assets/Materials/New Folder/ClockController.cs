using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        SetObjectState(false); // Começa desligado
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetObjectState(bool state)
    {
        if (animator != null)
        {
            if (state)
            {
                animator.SetBool("Estate", true);
            }
            else
            {
                animator.SetBool("Estate", false);
            }
        }
        else
        {
            Debug.LogWarning("Animator not found in ClockController!");
        }

    }
}

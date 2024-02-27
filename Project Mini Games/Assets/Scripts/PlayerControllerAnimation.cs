using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnimation : MonoBehaviour
{
    public static PlayerControllerAnimation Instance { get; private set; }

    
    [SerializeField] private Animator animator; // Adiciona uma referência ao componente Animator


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayerAnimationMoving()
    {
        animator.SetBool("IsMoving", true); // Ativa a animação de walk do jogador
    }

    public void PlayerAnimationNOTMoving()
    {
        animator.SetBool("IsMoving", false); // Ativa a animação de idle do jogador
    }

    public void PlayerAnimationDefeat()
    {
        animator.SetTrigger("Defeat"); // Ativa a animação de derrota do jogador
    }

    public void PlayerAnimationVictory()
    {
        animator.SetTrigger("Victory"); // Ativa a animação de vitória do jogador
    }
}

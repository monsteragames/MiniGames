using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //[SerializeField] private float timeToRestart = 2f;

    private CollectiblesManager collectiblesManager;

    private void Start()
    {
        collectiblesManager = CollectiblesManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        //Debug.Log("O jogador morreu!");

       
       // GetComponent<CameraController>().DisableCameraFollowing();

        // Resetar o CollectiblesManager
        if (collectiblesManager != null)
        {
            collectiblesManager.Reset();
        }

        // Em vez de chamar Invoke, chame o método RestartGame diretamente do GameManager
        GameManager.Instance.Defeat();
    }
}
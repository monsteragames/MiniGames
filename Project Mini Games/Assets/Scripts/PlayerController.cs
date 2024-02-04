using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float playerSpeed;

    private Vector3 playerDirection = Vector3.zero;
   private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);

    }

    private void OnSwipe(string swipe)
    {
      switch (swipe)
        {
            case "Left":
                playerDirection = Vector3.left; 
                break;
            case "Right":
                playerDirection = Vector3.right;
                break;
            case "Up":
                playerDirection = Vector3.forward;
                break;
            case "Down":
                playerDirection = Vector3.back;
                break;
            case "UpLeft":
                playerDirection = new Vector3(-1f, 0, 1f).normalized;
                break;
            case "UpRight":
                playerDirection = new Vector3(1f, 0, 1f).normalized;
                break;
            case "DownLeft":
                playerDirection = new Vector3(-1f, 0, -1f).normalized;
                break;
            case "DownRight":
                playerDirection = new Vector3(1f, 0, -1f).normalized;
                break;
        }
        Debug.Log(swipe + playerDirection);

        RotatePlayer();
    }

    private void Update()
    {
        playerTransform.position += (Vector3)playerDirection * playerSpeed * Time.deltaTime;
    }

    private void RotatePlayer()
    {
        // Rotaciona o jogador para a direção do movimento
        if (playerDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerDirection.normalized, Vector3.up);
            playerTransform.rotation = toRotation;
        }
    }

    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}

//using UnityEngine;
//using GG.Infrastructure.Utils.Swipe;
//using UnityEngine.EventSystems;

//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] private SwipeListener swipeListener;
//    [SerializeField] private Transform playerTransform;
//    [SerializeField] private float playerSpeed;
//    [SerializeField] private float rotationSpeed;

//    private Vector3 playerDirection = Vector3.zero;

//    private void OnEnable()
//    {
//        swipeListener.OnSwipe.AddListener(OnSwipe);
//    }

//    private void OnSwipe(string swipe)
//    {
//        switch (swipe) //  moveDirection = new Vector3(joystick.Horizontal(), 0f, joystick.Vertical()).normalized;
//        {
//            case "Left":
//                playerDirection = Vector3.left;
//                break;
//            case "Right":
//                playerDirection = Vector3.right;
//                break;
//            case "Up":
//                playerDirection = Vector3.forward;
//                break;
//            case "Down":
//                playerDirection = Vector3.back;
//                break;
//            case "UpLeft":
//                playerDirection = new Vector3(-1f, 0, 1f).normalized;
//                break;
//            case "UpRight":
//                playerDirection = new Vector3(1f, 0, 1f).normalized;
//                break;
//            case "DownLeft":
//                playerDirection = new Vector3(-1f, 0, -1f).normalized;
//                break;
//            case "DownRight":
//                playerDirection = new Vector3(1f, 0, -1f).normalized;
//                break;
//        }
//        //Debug.Log(swipe + playerDirection); 


//        RotatePlayer();
//    }



//    private void Update()
//    {
//        //playerTransform.position += (Vector3)playerDirection * playerSpeed * Time.deltaTime;
//        playerTransform.Translate((Vector3)playerDirection * playerSpeed * Time.deltaTime, Space.World);
//    }

//    //private void RotatePlayer()
//    //{
//    //    // Rotaciona o jogador para a direção do movimento
//    //    if (playerDirection != Vector3.zero)
//    //    {
//    //        //Quaternion toRotation = Quaternion.LookRotation(playerDirection.normalized, Vector3.up);
//    //       // playerTransform.rotation = toRotation;

//    //        Quaternion toRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
//    //          playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, toRotation, rotationSpeed* Time.deltaTime);
//    //    }
//    //}

//    private void RotatePlayer()
//    {
//        // Verifica se há uma direção de movimento válida
//        if (playerDirection != Vector3.zero)
//        {
//            // Calcula a rotação com base na direção do movimento
//            Quaternion targetRotation = Quaternion.LookRotation(playerDirection, Vector3.up);

//            // Suaviza a rotação para evitar movimentos bruscos
//            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

//        }
//    }



//    private void OnDisable()
//    {
//        swipeListener.OnSwipe.RemoveListener(OnSwipe);
//    }

//    // Método para parar o movimento do jogador
//    public void StopMoving()
//    {
//        playerSpeed = 2f;
//    }
//}

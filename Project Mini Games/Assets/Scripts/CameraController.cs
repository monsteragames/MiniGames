using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float portraitFOV = 60f; // Ajuste conforme necessário
    [SerializeField] private float landscapeFOV = 60f; // Ajuste conforme necessário
    [SerializeField] private Transform target; // Jogador (o objeto a ser seguido pela câmera)
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -5f); // Distância e altura da câmera em relação ao jogador
    [SerializeField] private float minY = -1f; // Posição mínima do jogador antes de parar de seguir
    private bool canFollowPlayer = true; // Variável para controlar se a câmera deve seguir o jogador ou não

    private void Update()
    {
        AdjustCameraSettings();
        if (canFollowPlayer)
            FollowPlayer();
    }

    private void AdjustCameraSettings()
    {
        // Obtenha a resolução atual da tela
        float screenRatio = (float)Screen.width / Screen.height;

        // Verifique a orientação do dispositivo e ajuste o campo de visão da câmera
        if (screenRatio > 1.0f)
        {
            // Dispositivo está em pé (landscape)
            SetCameraSettings(landscapeFOV);
        }
        else
        {
            // Dispositivo está deitado (portrait)
            SetCameraSettings(portraitFOV);
        }

        // Ajuste a posição da câmera apenas na direção Y, se a câmera puder seguir o jogador
        if (canFollowPlayer)
            transform.position = new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z);
    }

    private void SetCameraSettings(float fieldOfView)
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Ajuste o campo de visão da câmera
            mainCamera.fieldOfView = fieldOfView;
        }
    }

    private void FollowPlayer()
    {
        // Verifique se o jogador está definido e se não está caindo (posição Y acima do minY)
        if (target != null && target.position.y >= minY)
        {
            // Atualiza a posição da câmera para seguir o jogador
            transform.position = target.position + offset;
        }
    }

    // Método para impedir que a câmera siga o jogador
    public void DisableCameraFollowing()
    {
        canFollowPlayer = false;
    }
}

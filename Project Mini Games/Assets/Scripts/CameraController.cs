using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float portraitFOV = 60f; // Ajuste conforme necess�rio
    [SerializeField] private float landscapeFOV = 60f; // Ajuste conforme necess�rio
    [SerializeField] private Transform target; // Jogador (o objeto a ser seguido pela c�mera)
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -5f); // Dist�ncia e altura da c�mera em rela��o ao jogador
    [SerializeField] private float minY = -1f; // Posi��o m�nima do jogador antes de parar de seguir
    private bool canFollowPlayer = true; // Vari�vel para controlar se a c�mera deve seguir o jogador ou n�o

    private void Update()
    {
        AdjustCameraSettings();
        if (canFollowPlayer)
            FollowPlayer();
    }

    private void AdjustCameraSettings()
    {
        // Obtenha a resolu��o atual da tela
        float screenRatio = (float)Screen.width / Screen.height;

        // Verifique a orienta��o do dispositivo e ajuste o campo de vis�o da c�mera
        if (screenRatio > 1.0f)
        {
            // Dispositivo est� em p� (landscape)
            SetCameraSettings(landscapeFOV);
        }
        else
        {
            // Dispositivo est� deitado (portrait)
            SetCameraSettings(portraitFOV);
        }

        // Ajuste a posi��o da c�mera apenas na dire��o Y, se a c�mera puder seguir o jogador
        if (canFollowPlayer)
            transform.position = new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z);
    }

    private void SetCameraSettings(float fieldOfView)
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Ajuste o campo de vis�o da c�mera
            mainCamera.fieldOfView = fieldOfView;
        }
    }

    private void FollowPlayer()
    {
        // Verifique se o jogador est� definido e se n�o est� caindo (posi��o Y acima do minY)
        if (target != null && target.position.y >= minY)
        {
            // Atualiza a posi��o da c�mera para seguir o jogador
            transform.position = target.position + offset;
        }
    }

    // M�todo para impedir que a c�mera siga o jogador
    public void DisableCameraFollowing()
    {
        canFollowPlayer = false;
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float portraitFOV = 60f; // Ajuste conforme necessário
    [SerializeField] private float landscapeFOV = 60f; // Ajuste conforme necessário

    private void Update()
    {
        AdjustCameraSettings();
    }

    private void AdjustCameraSettings()
    {
        float screenRatio = (float) Screen.width / Screen.height;

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
    }

    private void SetCameraSettings(float fieldOfView)
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Ajuste o campo de visão da câmera
            mainCamera.fieldOfView = fieldOfView;

            // Outros ajustes conforme necessário, como a posição, projeção, etc.
            // mainCamera.transform.position = ...;
            // mainCamera.projectionMatrix = ...;
        }
    }
}

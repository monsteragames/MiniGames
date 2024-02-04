using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float portraitFOV = 60f; // Ajuste conforme necess�rio
    [SerializeField] private float landscapeFOV = 60f; // Ajuste conforme necess�rio

    private void Update()
    {
        AdjustCameraSettings();
    }

    private void AdjustCameraSettings()
    {
        float screenRatio = (float) Screen.width / Screen.height;

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
    }

    private void SetCameraSettings(float fieldOfView)
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Ajuste o campo de vis�o da c�mera
            mainCamera.fieldOfView = fieldOfView;

            // Outros ajustes conforme necess�rio, como a posi��o, proje��o, etc.
            // mainCamera.transform.position = ...;
            // mainCamera.projectionMatrix = ...;
        }
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2f;
    private float currentY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        currentY -= mouseY;
        currentY = Mathf.Clamp(currentY, -20f, 60f);
        transform.localRotation = Quaternion.Euler(currentY, 0, 0);
    }
}
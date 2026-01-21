using UnityEngine;
using TMPro;

public class TopdownRotation : MonoBehaviour
{
    public enum RotationTarget { Mouse, TargetObject }
    public RotationTarget currentMode = RotationTarget.Mouse;
    public Transform targetTransform;
    public float rotationSpeed = 10f;
    public TextMeshProUGUI angleDisplay;

    void Update()
    {
        Vector3 targetPos = Vector3.zero;

        if (currentMode == RotationTarget.Mouse)
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
            targetPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        }
        else if (currentMode == RotationTarget.TargetObject && targetTransform != null)
        {
            targetPos = targetTransform.position;
        }
        Vector3 direction3D = targetPos - transform.position;
        Vector2 direction = new Vector2(direction3D.x, direction3D.y);
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (angleDisplay != null)
        {
            angleDisplay.text = $"Mode: {currentMode}\nAngle: {angle:F2}°";
        }

        if (Input.GetKeyDown(KeyCode.Space))
            currentMode = (currentMode == RotationTarget.Mouse) ? RotationTarget.TargetObject : RotationTarget.Mouse;
    }
}
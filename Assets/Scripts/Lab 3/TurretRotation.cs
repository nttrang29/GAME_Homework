using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f; 
    public enum RotationMode { DirectLookAt, SmoothRotateTowards, SmoothSlerp }
    public RotationMode mode = RotationMode.DirectLookAt;

    void Update()
    {
        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        switch (mode)
        {
            case RotationMode.DirectLookAt:
                transform.LookAt(target.position);
                break;

            case RotationMode.SmoothRotateTowards:
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation, 
                    targetRotation, 
                    rotationSpeed * 100f * Time.deltaTime
                );
                break;

            case RotationMode.SmoothSlerp:
                transform.rotation = Quaternion.Slerp(
                    transform.rotation, 
                    targetRotation, 
                    rotationSpeed * Time.deltaTime
                );
                break;
        }
    }
}
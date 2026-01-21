using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float sensitivity = 2f;
    public Transform pivotTransform;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(Vector3.up * mouseX);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDir = (transform.forward * v + transform.right * h).normalized;

        if (moveDir != Vector3.zero)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }
}
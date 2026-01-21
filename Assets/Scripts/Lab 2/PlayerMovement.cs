using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    private Vector3 moveDirection;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");  
        moveDirection = new Vector3(horizontal, 0f, vertical);
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    void OnDrawGizmos()
    {
        if (moveDirection != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, moveDirection * 2f);
            Gizmos.DrawSphere(transform.position + moveDirection * 2f, 0.1f);
        }
    }
}
using UnityEngine;

public class PlayerController_Lab8_Fixed : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float moveSpeed = 5f;

    private int speedHash;
    private int attackHash;

    private float lastSpeed;

    void Awake()
    {
        speedHash = Animator.StringToHash("Speed");
        attackHash = Animator.StringToHash("Attack");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float targetSpeed = Mathf.Abs(moveInput);

        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        if (!Mathf.Approximately(lastSpeed, targetSpeed))
        {
            anim.SetFloat(speedHash, targetSpeed);
            lastSpeed = targetSpeed;
        }

        if (moveInput > 0.1f) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(attackHash);
        }
    }
}
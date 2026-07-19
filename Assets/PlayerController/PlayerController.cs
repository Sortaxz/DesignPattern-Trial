using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpHeight = 1.2f;
    public float gravity = -19.62f;

    [Header("Kamera & Etkileşim")]
    public Transform playerCamera;
    public float mouseSensitivity = 200f;
    public float reachDistance = 5f;
    public GameObject blockPrefab;
    public LayerMask blockLayer;

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        // Fareyi ekrana kilitle ve gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        LookAround();
        MovePlayer();
        HandleBlockInteraction();
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void MovePlayer()
    {
        bool isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleBlockInteraction()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, reachDistance, blockLayer))
        {
            // SOL TIK: Blok Kırma
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(hit.transform.gameObject);
            }

            // SAĞ TIK: Blok Koyma
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 spawnPos = hit.transform.position + hit.normal;
                spawnPos = new Vector3(
                    Mathf.Round(spawnPos.x),
                    Mathf.Round(spawnPos.y),
                    Mathf.Round(spawnPos.z)
                );

                // Oyuncunun durduğu yere blok koymayı engelle
                if (Vector3.Distance(spawnPos, transform.position) > 1.2f)
                {
                    Instantiate(blockPrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }
}
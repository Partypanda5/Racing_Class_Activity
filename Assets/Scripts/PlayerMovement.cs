using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character Controller")]
    private CharacterController controller;

    [Header("Character Settings")]
    [Space(10)]
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [Header("Bullet Settings")]
    [Space(10)]
    [SerializeField] private float bulletSpeed = 5;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Vector 3s")]
    private Vector3 playerVelocity;
    private Vector2 _playerInput;

    [Header("Bools")]
    private bool groundedPlayer;
    private bool jump;
    private bool shoot;


    public void playerMove(InputAction.CallbackContext context)
    {
        
        _playerInput = context.ReadValue<Vector2>();
    }

    public void playerJump(InputAction.CallbackContext context) 
    {
        jump = context.action.triggered;
        Debug.Log(jump);
    }

    public void playerShoot(InputAction.CallbackContext context) 
    {
        shoot = context.action.triggered;
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(_playerInput.y * -1, 0, _playerInput.x);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (jump && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (shoot) 
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody Bulletrb = bullet.GetComponent<Rigidbody>();
            Bulletrb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);

        }
    }





}

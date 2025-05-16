using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    private float speed = 8f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3 (horizontal, 0, 0);
        characterController.Move(movement * Time.deltaTime * speed);
    }
}

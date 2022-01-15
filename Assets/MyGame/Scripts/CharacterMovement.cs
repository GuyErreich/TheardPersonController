using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(InputManager))]
public class CharacterMovement : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform cam;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 6f, strafeSpeed = 4f, sprintSpeed = 8f, strafeSprintSpeed = 6f;

    private Vector3 velocity;
    private bool sprintPressed;
    private Rigidbody rb;

    Vector2 movementInput;

    void Start() {
        this.rb = this.GetComponent<Rigidbody>();
        this.rb.freezeRotation = true;
    }

    private void Update() {
        float _walkSpeed = sprintPressed ? sprintSpeed : walkSpeed;
        float _strafeSpeed = sprintPressed ? strafeSprintSpeed : strafeSpeed;
            
        velocity = (transform.right * movementInput.x * _strafeSpeed) + (transform.forward * movementInput.y * _walkSpeed);
    }

    private void FixedUpdate() {
        this.rb.velocity = velocity;
    }

    public void ReceiveInput(Vector2 _movementInput, bool _sprintPressed) {
        movementInput = _movementInput;
        sprintPressed = _sprintPressed;
    }
}
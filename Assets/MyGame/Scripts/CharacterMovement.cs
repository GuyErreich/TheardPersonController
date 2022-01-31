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
    [SerializeField, Range(0, 1)] private float turnSpeed = 0.5f;

    private Vector3 velocity;
    private bool sprintPressed;
    private Rigidbody rb;

    Vector2 movementInput;

    void Start() {
        this.rb = this.GetComponent<Rigidbody>();
        this.rb.freezeRotation = true;
    }

    private void Update() {
        float walkSpeed = this.sprintPressed ? this.sprintSpeed : this.walkSpeed;
        float strafeSpeed = this.sprintPressed ? this.strafeSprintSpeed : this.strafeSpeed;
            
        this.velocity = (this.transform.right * this.movementInput.x * strafeSpeed) + (this.transform.forward * this.movementInput.y * walkSpeed);

        //CHECK: Does it realy only work wis DOTween?
        // Quaternion target = this.transform.rotation;
        // target.y = this.cam.transform.rotation.y; 
        // this.transform.DORotateQuaternion(target, 0.5f);

        Vector3 target = this.transform.rotation.eulerAngles;
        target.y = this.cam.transform.rotation.eulerAngles.y; 
        this.transform.DORotate(target, this.turnSpeed, RotateMode.Fast);
    }

    private void FixedUpdate() {
        this.rb.velocity = velocity;
    }

    public void ReceiveInput(Vector2 _movementInput, bool _sprintPressed) {
        movementInput = _movementInput;
        sprintPressed = _sprintPressed;
    }
}
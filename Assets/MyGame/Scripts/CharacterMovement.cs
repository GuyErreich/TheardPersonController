using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterMovement : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform cam;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 6f, strafeSpeed = 4f, sprintSpeed = 8f, strafeSprintSpeed = 6f;

    private Vector3 velocity;
    private bool sprintPressed, isBackward = false;
    private Rigidbody rb;

    Vector2 movementInput;

    void Start() {
        this.rb = this.GetComponent<Rigidbody>();
        this.rb.freezeRotation = true;
    }

    private void Update() {
        float _walkSpeed = sprintPressed ? sprintSpeed : walkSpeed;
        float _strafeSpeed = sprintPressed ? strafeSprintSpeed : strafeSpeed;

        if (movementInput.y < 0f)
            isBackward = true;
        if (movementInput.y > 0f)
            isBackward = false;
            
        if (!isBackward)
        {
            velocity = (transform.right * movementInput.x * _strafeSpeed) + (transform.forward * movementInput.y * _walkSpeed);
            handleRotation(0f);
        }
        else
        {
            velocity = (transform.right * -movementInput.x * _strafeSpeed) + (transform.forward * -movementInput.y * _walkSpeed);

            handleRotation(180f);
        }

    }

    private void handleRotation(float angle)
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = cam.eulerAngles.y + angle; 
        print("currentRotation" + currentRotation);
        transform.DORotate(currentRotation, 0f);
    }

    private void FixedUpdate() {
        this.rb.velocity = velocity;
    }

    public void ReceiveInput(Vector2 _movementInput, bool _sprintPressed) {
        movementInput = _movementInput;
        sprintPressed = _sprintPressed;
    }
}
using UnityEngine;

public class InputManager : MonoBehaviour {
    
    [SerializeField] private CharacterMovement movement;
    [SerializeField] private float smoothInputSpeed;
    // [SerializeField] CameraController mouseLook;

    private PlayerControls controls;
    private PlayerControls.MovementActions movementInput;

    private Vector2 movementInputValue, currentMovementInputValue, smoothInputVelocity;


    Vector2 mouseInput;

    private void Awake() {
        this.controls = new PlayerControls();
        this.movementInput = this.controls.Movement;
        
        this.movementInput.Movement.performed += ctx => this.movementInputValue = ctx.ReadValue<Vector2>();
        // this.movementInput.MouseLook.performed += ctx => this.mouseInput = ctx.ReadValue<Vector2>();
    }

    private void Update() {
        this.currentMovementInputValue = Vector2.SmoothDamp(this.currentMovementInputValue, this.movementInputValue, 
                                                        ref this.smoothInputVelocity, this.smoothInputSpeed);
        this.movement.ReceiveInput(currentMovementInputValue);
        // mouseLook.ReceiveInput(mouseInput)
    }

    private void OnEnable() {
        this.controls.Enable();
    }

    private void OnDestroy() {
        this.controls.Disable();
    }
}
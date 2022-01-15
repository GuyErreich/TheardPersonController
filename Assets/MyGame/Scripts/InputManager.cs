using UnityEngine;

public class InputManager : MonoBehaviour {
    
    [SerializeField] CharacterMovement movement;
    // [SerializeField] CameraController mouseLook;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    Vector2 movementInput;
    Vector2 mouseInput;

    bool sprintPressed;

    private void Awake() {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        
        groundMovement.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        groundMovement.Sprint.performed += ctx => sprintPressed = ctx.ReadValueAsButton();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update() {
        movement.ReceiveInput(movementInput, sprintPressed);
        // mouseLook.ReceiveInput(mouseInput)
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDestroy() {
        controls.Disable();
    }
}
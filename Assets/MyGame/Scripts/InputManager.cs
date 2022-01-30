using UnityEngine;

public class InputManager : MonoBehaviour {
    
    [SerializeField] CharacterMovement movement;
    // [SerializeField] CameraController mouseLook;
    [SerializeField] AnimationController anim;


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
        groundMovement.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
    }

    private void Update() {
        movement.ReceiveInput(movementInput, sprintPressed);
        // mouseLook.ReceiveInput(mouseInput)
        anim.ReceiveInput(movementInput, sprintPressed);
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDestroy() {
        controls.Disable();
    }
}
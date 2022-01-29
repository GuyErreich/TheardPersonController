using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]
public class CharacterMovement : MonoBehaviour {
    private Animator anim;
    private Vector3 movementInput;
    private Rigidbody rb;

    void Start() {
        this.rb = this.GetComponent<Rigidbody>();
        this.rb.freezeRotation = true;

        this.anim = this.GetComponent<Animator>();
    }

    private void Update() {
        anim.SetFloat("Velocity", movementInput.y);
    }

    public void ReceiveInput(Vector2 movementInput) {
        this.movementInput = movementInput;
    }
}
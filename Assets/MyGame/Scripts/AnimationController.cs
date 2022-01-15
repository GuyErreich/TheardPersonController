using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private bool sprintPressed;
    private Vector2 movementInput;
    private Animator anim;
    private int movementSpeedHash;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movementSpeedHash = Animator.StringToHash("MovementSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(movementSpeedHash, movementInput.y);
    }

    public void ReceiveInput(Vector2 _movementInput, bool _sprintPressed) {
        movementInput = _movementInput;
        sprintPressed = _sprintPressed;
    }
}

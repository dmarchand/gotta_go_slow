
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour {
    public InputActionAsset playerControls;

    private InputAction movement;
    private PlayerStatsController playerStatsController;

    private Vector3 movementVector = Vector3.zero;

    private void Awake() {
        var playerActionMap = playerControls.FindActionMap("Player");

        if (playerActionMap == null) {
            throw new System.MissingMemberException("No Player Action Map found. Did you rename the Player Action Map?");
        }

        movement = playerActionMap.FindAction("Move");

        if (movement == null) {
            throw new System.MissingMemberException("No movement action found in the Player Action Map");
        }

        movement.performed += FireMoveEvent;
        movement.canceled += StopMoving;
        movement.Enable();

        playerStatsController = GetComponent<PlayerStatsController>();

        if (playerStatsController == null) {
            throw new System.MissingMemberException("Did you forget the player stats controller?");
        }
    }

    public void FireMoveEvent(InputAction.CallbackContext context) {
        var direction = (Vector3)context.ReadValue<Vector2>();

        movementVector = direction * playerStatsController.CurrentControlSpeed;
    }

    public void StopMoving(InputAction.CallbackContext context) {
        movementVector = Vector3.zero;
    }

    private void Update() {
        transform.Translate(movementVector * Time.deltaTime);
    }
}

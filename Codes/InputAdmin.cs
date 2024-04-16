using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAdmin : MonoBehaviour
{
    private PlayerInput playerinput;
    private PlayerInput.OnFootActions onfoot;
    private MovementPlayer movementplayer;
    private PlayerSens sens;
    // Start is called before the first frame update
    void Awake()
    {
        playerinput = new PlayerInput();
        onfoot = playerinput.OnFoot;
        movementplayer = GetComponent<MovementPlayer>();
        sens = GetComponent<PlayerSens>();
        onfoot.Jump.performed += ctx => movementplayer.Jump();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movementplayer.movements(onfoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        sens.Lookaround(onfoot.Sens.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onfoot.Enable();
    }
    private void OnDisable()
    {
        onfoot.Disable();
    }
}

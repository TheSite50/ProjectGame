using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
	[HideInInspector] public Vector2 move;
	[HideInInspector] public Vector2 look;
	[HideInInspector] public bool jump;
	[HideInInspector] public bool sprint;
	[HideInInspector] public bool shoot;
	[HideInInspector] public bool reload;

	[HideInInspector] public bool analogMovement;

	[HideInInspector] public bool cursorLocked = true;
	[HideInInspector] public bool cursorInputForLook = true;
	
	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector2>());
	}

	public void OnLook(InputValue value)
	{
		if (cursorInputForLook)
		{
			LookInput(value.Get<Vector2>());
		}
	}

	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}
    public void OnShoot(InputValue value)
	{
		//Debug.Log(value.isPressed);
		shoot = value.isPressed;
	}
	public void OnSprint(InputValue value)
	{
		SprintInput(value.isPressed);
	}

	public void MoveInput(Vector2 newMoveDirection)
	{
		move = newMoveDirection;
	}

	public void LookInput(Vector2 newLookDirection)
	{
		look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }
	public void ShootInput(bool newShootState)
	{
		shoot = newShootState;
	}

	public void SprintInput(bool newSprintState)
	{
		sprint = newSprintState;
	}
	public void ReloadInput(bool newReloadState)
	{
		reload = newReloadState;
	}

	/*
	[SerializeField] PlayerInput controls;
	[HideInInspector] public Vector2 whereIsMoving;
	[HideInInspector] public Vector2 whereIsLooking;

	[HideInInspector] public bool isShooting;
	[HideInInspector] public bool isSprinting;
	[HideInInspector] public bool isStomping;
	private void Awake()
    {
		controls = gameObject.AddComponent<PlayerInput>();
    }

    private void OnEnable()
    {
		
    }
    private void OnDisable()
    {
		
    }
	public void Move(InputAction.CallbackContext ctx)
	{
        //Debug.Log(ctx.ReadValue<Vector2>());
        if (ctx.started)
        {
            Debug.Log(ctx.ReadValue<Vector2>());
            move = ctx.ReadValue<Vector2>();
        }
		if (ctx.canceled)
		{
			move = Vector2.zero;
		}
        /*if (ctx.started)
		{
			Debug.Log("started");
		}
		if (ctx.performed)
		{
			Debug.Log("performed");
		}
		if (ctx.canceled)
		{
			Debug.Log("cancelled");
		}
    }

	public void Look(InputAction.CallbackContext ctx)
	{
		if (ctx.started)
		{
			look = ctx.ReadValue<Vector2>();
		}
	}
	public void Stomp(InputAction.CallbackContext ctx)
	{
		if (ctx.started)
		{
			isStomping = controls.actions["Stomp"].ReadValue<bool>();
		}
	}
	public void Sprint(InputAction.CallbackContext ctx)
	{
		if (ctx.started)
		{
			isSprinting = controls.actions["Sprint"].ReadValue<bool>();
		}
	}
	public void Shoot(InputAction.CallbackContext ctx)
	{
		if (ctx.started)
		{
			isShooting = true;
		}
		if (ctx.canceled)
		{
			isShooting = false;
		}

	}
	*/


}

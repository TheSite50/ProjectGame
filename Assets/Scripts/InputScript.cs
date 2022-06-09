using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
	public Vector2 move;
	public Vector2 look;
	public bool jump;
	public bool sprint;
	public bool shoot;

	public bool analogMovement;

	public bool cursorLocked = true;
	public bool cursorInputForLook = true;

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
		ShootInput(value.isPressed);
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
	/*
	[SerializeField] MyInputActions idkwhatitis;
	[SerializeField] InputAction controls;
    private void Awake()
    {
		idkwhatitis = new MyInputActions();
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

	*/

}

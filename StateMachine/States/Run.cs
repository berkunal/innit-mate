using Godot;
using System;

class Run : State
{
	override public void physicsProcess(float _delta)
	{
		// +1 means right, -1 means left
		if (Input.IsActionPressed("move_left") && !Input.IsActionPressed("move_right"))
		{
			player.DirectionOfMoving = -1;
		}
		else if (!Input.IsActionPressed("move_left") && Input.IsActionPressed("move_right"))
		{
			player.DirectionOfMoving = 1;
		}

		if ((Input.IsActionPressed("jump")))
		{
			player.Velocity.y += player.JumpSpeed;
		}

		// Update the velocity vector if user wants to move 
		player.Velocity.x += player.DirectionOfMoving * player.Speed * _delta;
		player.Velocity.x = Mathf.Clamp(player.Velocity.x, -(player.MaxSpeed), player.MaxSpeed);

		// Apply gravity to the velocity vector
		player.Velocity.y += player.Gravity * _delta;

		// Move the instance
		player.Velocity = player.MoveAndSlide(player.Velocity, Vector2.Up);

		if (!Input.IsActionPressed("move_right") && !Input.IsActionPressed("move_left"))
		{
			parentStateMachine.transition("Idle");
		}

		if (!player.IsOnFloor())
		{
			parentStateMachine.transition("Air");
		}
	}

	public override void handleInput(InputEvent @event)
	{
		if (@event.IsActionPressed("jump"))
		{
			parentStateMachine.transition("Air");
		}
	}
}

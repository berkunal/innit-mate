using Godot;
using System;

class Air : State
{

	override public void physicsProcess(float _delta)
	{
		player.DirectionOfMoving = 0;
		// +1 means right, -1 means left
		if (Input.IsActionPressed("move_left") && !Input.IsActionPressed("move_right"))
		{
			player.DirectionOfMoving = -1;
		}
		else if (!Input.IsActionPressed("move_left") && Input.IsActionPressed("move_right"))
		{
			player.DirectionOfMoving = 1;
		}

		// Update the velocity vector if user wants to move
		if (player.DirectionOfMoving != 0)
		{
			player.Velocity.x += player.DirectionOfMoving * player.Speed * _delta;
			player.Velocity.x = Mathf.Clamp(player.Velocity.x, -(player.MaxSpeed), player.MaxSpeed);
		}

		// Apply gravity to the velocity vector
		player.Velocity.y += player.Gravity * _delta;

		// Move the instance
		player.Velocity = player.MoveAndSlide(player.Velocity, Vector2.Up);

		if (player.IsOnFloor() && (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right")))
		{
			parentStateMachine.transition("Run");
		}

		else if (player.IsOnFloor())
		{
			parentStateMachine.transition("Idle");
		}

	}

	public override void handleInput(InputEvent @event)
	{

	}
}

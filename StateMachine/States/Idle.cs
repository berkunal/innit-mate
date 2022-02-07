using Godot;
using System;

class Idle : State
{
	override public void physicsProcess(float _delta)
	{
		player.DirectionOfMoving = 0;
		// Make the player stop moving with friction
		player.Velocity.x = Mathf.Lerp(player.Velocity.x, 0, player.Friction);

		if ((Input.IsActionPressed("jump")))
		{
			player.Velocity.y += player.JumpSpeed;
		}

		// Apply gravity to the velocity vector
		player.Velocity.y += player.Gravity * _delta;

		// Even though the player is idle, this expression will help understand what direction is up according to the character
		player.Velocity = player.MoveAndSlide(player.Velocity, Vector2.Up);

		if (!player.IsOnFloor())
		{
			parentStateMachine.transition("Air");
		}
	}

	public override void handleInput(InputEvent @event)
	{
		if (@event.IsActionPressed("move_right") || @event.IsActionPressed("move_left"))
		{
			parentStateMachine.transition("Run");
		}
	}
}

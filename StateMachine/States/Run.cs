using Godot;
using System;

class Run : State
{

	int directionOfmoving;
	
	override public void physicsProcess(float _delta)
	{
		if (Input.IsKeyPressed((int)KeyList.A) && !Input.IsKeyPressed((int)KeyList.D))
		{
			directionOfmoving = -1;
		}
		else if (!Input.IsKeyPressed((int)KeyList.A) && Input.IsKeyPressed((int)KeyList.D))
		{
			directionOfmoving = 1;
		}
		
		// Update the velocity vector if user wants to move 
		player.Velocity.x += directionOfmoving * player.Speed * _delta;
		player.Velocity.x = Mathf.Clamp(player.Velocity.x, -(player.MaxSpeed), player.MaxSpeed);
	}

	public override void handleInput(InputEvent @event)
	{

		if (!@event.IsActionPressed("move_right") && !@event.IsActionPressed("move_left"))
		{
			parentStateMachine.transition("Idle");
		}

		if (@event.IsActionPressed("jump"))
		{
			parentStateMachine.transition("Air");
		}
	}
}

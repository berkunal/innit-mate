using Godot;
using System;

class Idle : State
{
	override public void physicsProcess(float _delta)
	{

	}

	public override void handleInput(InputEvent @event)
	{	
		if (@event.IsActionPressed("move_right") || @event.IsActionPressed("move_left"))
		{
			parentStateMachine.transition("Run");
		}

		if (@event.IsActionPressed("jump"))
		{
			parentStateMachine.transition("Air");
		}
	}
}

using Godot;
using System;

class Air : State
{

	override public void physicsProcess(float _delta)
	{

	}

	public override void handleInput(InputEvent @event)
	{
		if (parentStateMachine.GetParent<KinematicBody2D>().IsOnFloor())
		{
			if (!@event.IsActionPressed("move_right") && !@event.IsActionPressed("move_left"))
			{
				parentStateMachine.transition("Idle");
			}

			else
			{
				parentStateMachine.transition("Run");
			}
			
		}
		
		if (parentStateMachine.GetParent<KinematicBody2D>().IsOnWall())
		{
			parentStateMachine.transition("WallSlide");
		}
	}
}

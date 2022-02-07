using Godot;
using System;

abstract class State : Node2D
{
	protected StateMachine parentStateMachine;
	protected Player player;

	public override void _Ready()
	{
		this.parentStateMachine = GetParent<StateMachine>();
		this.player = (Player) Owner;
	}
	public abstract void physicsProcess(float delta);

	public abstract void handleInput(InputEvent @event);
	
}

using Godot;
using System;

public class MainScene : Node2D
{
	private Label fpsCounter;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		fpsCounter = GetNode<Label>("FPSCounter");
		fpsCounter.Show();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		fpsCounter.Text = String.Format("{0} FPS", Engine.GetFramesPerSecond());
	}
}

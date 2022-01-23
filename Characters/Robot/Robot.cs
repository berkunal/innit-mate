using Godot;
using System;

public class Robot : KinematicBody2D
{
	private Vector2 velocity;
	private int speed = 700;
	private int maxSpeed = 500;
	private int gravity = 1000;
	private float friction = 0.5f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.velocity = new Vector2(0, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		// Direction of moving:
		// 0 for standing. 1 for right. -1 for left
		int directionOfmoving = 0;
		if (Input.IsKeyPressed((int)KeyList.A) && !Input.IsKeyPressed((int)KeyList.D))
		{
			directionOfmoving = -1;
		}
		else if (!Input.IsKeyPressed((int)KeyList.A) && Input.IsKeyPressed((int)KeyList.D))
		{
			directionOfmoving = 1;
		}

		// Update the velocity vector if user wants to move 
		if (directionOfmoving != 0)
		{
			velocity.x += directionOfmoving * speed * delta;
			velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
		}

		// Slow down the instance if it is on the floor
		if (IsOnFloor())
		{
			velocity.x = Mathf.Lerp(velocity.x, 0, friction);
			GD.Print(velocity.x);
		}

		// Apply gravity to the velocity vector
		velocity.y += gravity * delta;

		// Move the instance
		velocity = MoveAndSlide(velocity);
	}
}

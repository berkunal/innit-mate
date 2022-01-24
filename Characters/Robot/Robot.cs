using Godot;
using System;

public class Robot : KinematicBody2D
{
	private Vector2 velocity = new Vector2();
	private int speed = 700;
	private int jumpSpeed = -400;
	private int maxSpeed = 1000;
	private int gravity = 1000;
	private float friction = 0.08f;
	private bool jumping = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
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

			if (Input.IsKeyPressed((int)KeyList.Space) || Input.IsKeyPressed((int)KeyList.W))
			{
				velocity.y += jumpSpeed;
			}
		}

		// Apply gravity to the velocity vector
		velocity.y += gravity * delta;

		// Move the instance
		velocity = MoveAndSlide(velocity, Vector2.Up);
	}
}

using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 velocity = new Vector2();
    private int speed = 700;
    private int jumpSpeed = -400;
    private int maxSpeed = 1000;
    private int gravity = 1000;
    private float friction = 0.08f;
    private bool jumping = false;
    private Label speedValue;
    private Label jumpSpeedValue;
    private Label maxSpeedValue;
    private Label gravityValue;
    private Label frictionValue;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        speedValue = GetNode<Label>("/root/MainScene/DeveloperControl/DevInfoContainer/PlayerValues/SpeedControls/SpeedValue");
        jumpSpeedValue = GetNode<Label>("/root/MainScene/DeveloperControl/DevInfoContainer/PlayerValues/JumpSpeedControls/JumpSpeedValue");
        maxSpeedValue = GetNode<Label>("/root/MainScene/DeveloperControl/DevInfoContainer/PlayerValues/MaxSpeedControls/MaxSpeedValue");
        gravityValue = GetNode<Label>("/root/MainScene/DeveloperControl/DevInfoContainer/PlayerValues/GravityControls/GravityValue");
        frictionValue = GetNode<Label>("/root/MainScene/DeveloperControl/DevInfoContainer/PlayerValues/FrictionControls/FrictionValue");
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

        // Slow down the instance if it is on the floor and not moving
        if (IsOnFloor() && directionOfmoving == 0)
        {
            velocity.x = Mathf.Lerp(velocity.x, 0, friction);
        }

        if (IsOnFloor() && (Input.IsKeyPressed((int)KeyList.Space) || Input.IsKeyPressed((int)KeyList.W)))
        {
            velocity.y += jumpSpeed;
        }

        // Apply gravity to the velocity vector
        velocity.y += gravity * delta;

        // Move the instance
        velocity = MoveAndSlide(velocity, Vector2.Up);
    }

    // Triggers when the Player exits out of the screen
    private void _on_VisibilityNotifier2D_screen_exited()
    {
        this.Position = new Vector2(136, 84);
    }

    private void _on_SpeedSlider_value_changed(float value)
    {
        this.speed = (int)value;
        this.speedValue.Text = this.speed.ToString();
    }


    private void _on_JumpSpeedSlider_value_changed(float value)
    {
        this.jumpSpeed = (int)value;
        this.jumpSpeedValue.Text = this.jumpSpeed.ToString();
    }


    private void _on_MaxSpeedSlider_value_changed(float value)
    {
        this.maxSpeed = (int)value;
        this.maxSpeedValue.Text = this.maxSpeed.ToString();
    }


    private void _on_GravitySlider_value_changed(float value)
    {
        this.gravity = (int)value;
        this.gravityValue.Text = this.gravity.ToString();
    }


    private void _on_FrictionSlider_value_changed(float value)
    {
        value /= 100; // Convert from 8 to 0.08 for example
        this.friction = value;
        this.frictionValue.Text = this.friction.ToString();
    }
}

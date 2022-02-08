using Godot;
using System;

public class Player : KinematicBody2D
{
    public Vector2 Velocity = new Vector2();
    public int Speed { get; set; } = 700;
    public int JumpSpeed { get; set; } = -400;
    public int MaxSpeed { get; set; } = 1000;
    public int Gravity { get; set; } = 1000;
    public float Friction { get; set; } = 0.08f;
    public int DirectionOfMoving { get; set; } = 0;
    public bool IsJumping { get; set; } = false;
    private Label speedValue;
    private Label jumpSpeedValue;
    private Label maxSpeedValue;
    private Label gravityValue;
    private Label frictionValue;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        speedValue = GetNode<Label>("/root/MainScene/Debug/DeveloperControl/DevInfoContainer/PlayerValues/SpeedControls/SpeedValue");
        jumpSpeedValue = GetNode<Label>("/root/MainScene/Debug/DeveloperControl/DevInfoContainer/PlayerValues/JumpSpeedControls/JumpSpeedValue");
        maxSpeedValue = GetNode<Label>("/root/MainScene/Debug/DeveloperControl/DevInfoContainer/PlayerValues/MaxSpeedControls/MaxSpeedValue");
        gravityValue = GetNode<Label>("/root/MainScene/Debug/DeveloperControl/DevInfoContainer/PlayerValues/GravityControls/GravityValue");
        frictionValue = GetNode<Label>("/root/MainScene/Debug/DeveloperControl/DevInfoContainer/PlayerValues/FrictionControls/FrictionValue");
    }

    // Triggers when the Player exits out of the screen
    private void _on_VisibilityNotifier2D_screen_exited()
    {
        this.Position = new Vector2(136, 84);
    }

    private void _on_SpeedSlider_value_changed(float value)
    {
        this.Speed = (int)value;
        this.speedValue.Text = this.Speed.ToString();
    }

    private void _on_JumpSpeedSlider_value_changed(float value)
    {
        this.JumpSpeed = (int)value;
        this.jumpSpeedValue.Text = this.JumpSpeed.ToString();
    }


    private void _on_MaxSpeedSlider_value_changed(float value)
    {
        this.MaxSpeed = (int)value;
        this.maxSpeedValue.Text = this.MaxSpeed.ToString();
    }


    private void _on_GravitySlider_value_changed(float value)
    {
        this.Gravity = (int)value;
        this.gravityValue.Text = this.Gravity.ToString();
    }


    private void _on_FrictionSlider_value_changed(float value)
    {
        value /= 100; // Convert from 8 to 0.08 for example
        this.Friction = value;
        this.frictionValue.Text = this.Friction.ToString();
    }
}

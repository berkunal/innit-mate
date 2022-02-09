using Godot;
using System;

class Air : State
{
    public override void entry()
    {
        if (player.IsJumping)
        {
            Vector2 tempVector = player.Velocity;
            tempVector.y += player.JumpSpeed;
            player.Velocity = tempVector;

            player.IsJumping = false;
        }
    }

    override public void physicsProcess(float _delta)
    {
        if (player.IsOnFloor())
        {
            parentStateMachine.transition("Idle");
            return;
        }

        player.DirectionOfMoving = 0;
        if (Input.IsActionPressed("move_left") && !Input.IsActionPressed("move_right"))
        {
            player.DirectionOfMoving = -1;
        }
        else if (!Input.IsActionPressed("move_left") && Input.IsActionPressed("move_right"))
        {
            player.DirectionOfMoving = 1;
        }

        Vector2 tempVector = player.Velocity;

        if (player.DirectionOfMoving != 0)
        {
            tempVector.x += player.DirectionOfMoving * player.Speed * _delta;
            tempVector.x = Mathf.Clamp(tempVector.x, -(player.MaxSpeed), player.MaxSpeed);
        }

        tempVector.y += player.Gravity * _delta;

        player.Velocity = player.MoveAndSlide(tempVector, Vector2.Up);
    }

    public override void handleInput(InputEvent @event) { }
}

using Godot;
using System;

class Run : State
{
    public override void entry() { }

    override public void physicsProcess(float _delta)
    {
        if (!player.IsOnFloor())
        {
            parentStateMachine.transition("Air");
            return;
        }

        // Update the velocity vector
        player.Velocity.x += player.DirectionOfMoving * player.Speed * _delta;
        player.Velocity.x = Mathf.Clamp(player.Velocity.x, -(player.MaxSpeed), player.MaxSpeed);

        player.Velocity.y += player.Gravity * _delta;

        // Move the instance
        player.Velocity = player.MoveAndSlide(player.Velocity, Vector2.Up);
    }

    public override void handleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("move_left") && !@event.IsActionPressed("move_right"))
            player.DirectionOfMoving = -1;
        else if (@event.IsActionPressed("move_right") && !@event.IsActionPressed("move_left"))
            player.DirectionOfMoving = 1;
        else
        {
            player.DirectionOfMoving = 0;
            parentStateMachine.transition("Idle");
        }

        if (@event.IsActionPressed("jump"))
        {
            player.IsJumping = true;
            parentStateMachine.transition("Air");
        }
    }
}

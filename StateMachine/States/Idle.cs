using Godot;
using System;

class Idle : State
{
    public override void entry()
    {
        if (Input.IsActionPressed("move_left") && !Input.IsActionPressed("move_right"))
        {
            player.DirectionOfMoving = -1;
            parentStateMachine.transition("Run");
        }
        else if (!Input.IsActionPressed("move_left") && Input.IsActionPressed("move_right"))
        {
            player.DirectionOfMoving = 1;
            parentStateMachine.transition("Run");
        }
    }

    override public void physicsProcess(float _delta)
    {
        player.DirectionOfMoving = 0;

        player.Velocity.x = Mathf.Lerp(player.Velocity.x, 0, player.Friction);
        player.Velocity.y += player.Gravity * _delta;
        player.Velocity = player.MoveAndSlide(player.Velocity, Vector2.Up);

        if (!player.IsOnFloor())
            parentStateMachine.transition("Air");

    }

    public override void handleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("jump"))
        {
            player.IsJumping = true;
            parentStateMachine.transition("Air");
        }

        if (@event.IsActionPressed("move_right"))
        {
            player.DirectionOfMoving = 1;
            parentStateMachine.transition("Run");
        }

        else if (@event.IsActionPressed("move_left"))
        {
            player.DirectionOfMoving = -1;
            parentStateMachine.transition("Run");
        }

    }
}

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

        Vector2 tempVector = player.Velocity;
        tempVector.x = Mathf.Lerp(tempVector.x, 0, player.Friction);
        tempVector.y += player.Gravity * _delta;
        player.Velocity = player.MoveAndSlide(tempVector, Vector2.Up);

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

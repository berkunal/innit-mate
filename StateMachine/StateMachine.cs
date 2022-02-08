using Godot;
using System;

class StateMachine : Node2D
{
    private State currentState;

    public override void _Input(InputEvent @event)
    {
        currentState.handleInput(@event);
    }

    public override void _PhysicsProcess(float delta)
    {
        currentState.physicsProcess(delta);
    }

    public override void _Ready()
    {
        var childStateList = GetChildren();
        if (childStateList.Count == 0)
            return;

        currentState = (State)childStateList[0];
    }

    public void transition(String state)
    {
        if (HasNode(state))
        {
            State newState = GetNode<State>(state);
            this.currentState = newState;
            this.currentState.entry();
            Owner.GetNode<Label>("CurrentState").Text = state;
        }
    }
}

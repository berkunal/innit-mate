using Godot;
using System;

class StateMachine : Node2D
{
    private State currentState;

    public override void _Input(InputEvent @event)
    {
        this.currentState.handleInput(@event);
    }

    public override void _PhysicsProcess(float delta)
    {
        this.currentState.physicsProcess(delta);
    }

    public override void _Ready()
    {
        var childStateList = GetChildren();
        if (childStateList.Count == 0)
            return;

        this.currentState = (State)childStateList[0];
    }

    public void transition(String state)
    {
        if (HasNode(state))
        {
            if (currentState is Air && state == "Idle")
            {
                Owner.GetNode<AudioStreamPlayer2D>("SFX").Stream = (AudioStream)ResourceLoader.Load("res://Assets/Sounds/FX/bang.wav");
                Owner.GetNode<AudioStreamPlayer2D>("SFX").Play();
            }

            Owner.GetNode<Label>("CurrentState").Text = state;
            this.currentState = GetNode<State>(state);
            this.currentState.entry();
        }
    }
}

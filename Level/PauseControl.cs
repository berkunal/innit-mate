using Godot;
using System;

public class PauseControl : Control
{
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("pause"))
        {
            bool newPausedState = !GetTree().Paused;
            GetTree().Paused = newPausedState;
            Visible = newPausedState;
        }
    }

    private void _on_ResumeButton_pressed()
    {
        GetTree().Paused = false;
        Visible = false;
    }

    private void _on_OptionsButton_pressed()
    {
        // TODO: Open Options/Settings page when implemented
    }


    private void _on_ExitToMenuButton_pressed()
    {
        GetTree().Paused = false;
        Visible = false;
        GetTree().ChangeScene("res://TitleMenu/StartScene.tscn");
    }


    private void _on_ExitToDesktopButton_pressed()
    {
        GetTree().Quit();
    }
}

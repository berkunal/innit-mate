using Godot;
using System;

public class StartScene : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    private void _on_PlayGameButton_pressed()
    {
        GetTree().ChangeScene("res://Level/MainScene.tscn");
    }


    private void _on_ExitGameButton_pressed()
    {
        GetTree().Quit();
    }

}

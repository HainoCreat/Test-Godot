using Godot;
using System;

public partial class MenuMain : Node
{
	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}
	
	private void _on_start_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Levels/start.tscn");
	}
}

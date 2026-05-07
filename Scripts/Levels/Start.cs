using Godot;
using System;

public partial class Start : Node2D
{
	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/ui/menus/menu_main.tscn");
	}
}

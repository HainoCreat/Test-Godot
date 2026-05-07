using Godot;
using System;

public partial class MenuMain : Node
{
	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}

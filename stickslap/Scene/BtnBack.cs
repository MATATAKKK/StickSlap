using Godot;
using System;

public partial class BtnBack : Button
{
		public override void _Ready()
	{
		Pressed += () =>
		{
			GetTree().ChangeSceneToFile("res://Scene/MainMenu.tscn");
		};
	}
}

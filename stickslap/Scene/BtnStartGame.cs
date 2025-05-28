using Godot;
using System;

public partial class BtnStartGame : Button
{
		public override void _Ready()
	{
		Pressed += () =>
		{
			GetTree().ChangeSceneToFile("res://Scene/Map.tscn");
		};
	}
}

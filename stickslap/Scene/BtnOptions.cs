using Godot;
using System;

public partial class BtnOptions : Button
{
	public override void _Ready()
	{
		Pressed += () =>
		{
			GetTree().ChangeSceneToFile("res://Scene/Options.tscn");
		};
	}
}

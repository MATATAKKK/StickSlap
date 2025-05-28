using Godot;
using System;

public partial class BtnQuit : Button
{
		public override void _Ready()
	{
		Pressed += () =>
		{
			GetTree().Quit();
		};
	}
}

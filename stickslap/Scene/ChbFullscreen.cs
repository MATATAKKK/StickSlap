using Godot;
using System;

public partial class ChbFullscreen : CheckButton
{
		public override void _Ready()
	{
		// Set initial state
		ButtonPressed = DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen;
		Toggled += OnToggled;
	}

	private void OnToggled(bool pressed)
	{
		DisplayServer.WindowSetMode(pressed ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed);
	}
}

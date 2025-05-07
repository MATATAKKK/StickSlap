using Godot;
using System;

public partial class Punch : Weapon
{

	Player Player = new Player();
	private AnimatedSprite2D _sprite;
	public override void _Ready()
	{
		base._Ready();
		_sprite = (AnimatedSprite2D)GetChild(0);
		bps = 1;
		fireRate = 1 / bps;
	}
	public override void _Process(double delta)
	{
		//base._Process(delta);
		if (Player.DetectArms() == false)
		{
			Console.WriteLine("gaw");
			if (Input.IsActionJustPressed("leftClick") && timeUntilFire > fireRate)
			{
				Console.WriteLine("fjkod");
				_sprite.Play("Punch");
			}
			else
			{
				timeUntilFire += (float)delta;
			}
		}
	}
}

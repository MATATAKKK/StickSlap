using Godot;
using System;

public partial class Glock : Weapon
{
	private AnimatedSprite2D _Sprite;
	public override void _Ready()
	{
		
		base._Ready();
		bulletSpeed = 3000F;
		_Sprite = (AnimatedSprite2D)GetChild(0);
		bps = 10; //bullet par second
		fireRate = 1/bps; //bps = 5 ,fireRate = 0.2 seconde
	}
	public override void _Process(double delta)
	{
		//base._Process(delta);


		if (Input.IsActionJustPressed("leftClick") && timeUntilFire > fireRate)//si cliquer et que  
		{

			RigidBody2D Bullet = bulletTcn.Instantiate<RigidBody2D>();
			Bullet.Rotation = GlobalRotation ;
			Bullet.GlobalPosition = GlobalPosition;
			Bullet.LinearVelocity = Bullet.Transform.X * bulletSpeed ;

			GetTree().Root.AddChild(Bullet);

			timeUntilFire = 0f;
			_Sprite.Play("Shoot");
		}
		else
		{
			timeUntilFire += (float)delta;
		}
	}
}

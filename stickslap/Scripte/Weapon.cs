using Godot;
using System;

public abstract partial class Weapon : CharacterBody2D
{
	[Export] public PackedScene bulletTcn;
	public float bulletSpeed = 600f;
	public float bps = 5;
	public float bulletDamage = 30f;
	public float fireRate;
	public float timeUntilFire = 0f;

	public override void _Ready()
	{
		fireRate = 1/bps;
		base._Ready();
	}


	public abstract void Use();
	
   

}

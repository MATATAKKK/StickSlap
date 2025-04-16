using Godot;
using System;

public partial class Gun : Node2D
{
    [Export] PackedScene bulletTcn;
    [Export] float bulletSpeed = 600f;
    [Export] float bps = 5;
    [Export] float bulletDamage = 30f;

    float fireRate;

    float timeUntilFire = 0f;
    public override void _Ready()
    {
        fireRate = 1/bps;
        base._Ready();
    }
    public override void _Process(double delta)
    {
        base._Process(delta);


        if (Input.IsActionJustPressed("leftClick") && timeUntilFire > fireRate)//si cliquer et que  
        {
            RigidBody2D Bullet = bulletTcn.Instantiate<RigidBody2D>();
            Bullet.Rotation = GlobalRotation;
            Bullet.GlobalPosition = GlobalPosition;
            Bullet.LinearVelocity = Bullet.Transform.X * bulletSpeed;

            GetTree().Root.AddChild(Bullet);
            timeUntilFire = 0f;
        }
        else {
            timeUntilFire += (float)delta;
        }
    }
}

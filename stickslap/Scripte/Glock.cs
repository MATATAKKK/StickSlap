using Godot;
using System;
using System.Drawing;

public partial class Glock : Weapon
{
    private AnimatedSprite2D _Sprite;
    private Vector2 _Size = new Vector2(32, 0);
    public override void _Ready()
    {

        base._Ready();
        bulletSpeed = 3000F;
        _Sprite = (AnimatedSprite2D)GetChild(0);
        bps = 10; //bullet par second
        fireRate = 1 / bps; //bps = 5 ,fireRate = 0.2 seconde
    }
    public override void _Process(double delta)
    {
        //base._Process(delta);
        if (Input.IsActionJustPressed("leftClick") && timeUntilFire > fireRate)
        {
            RigidBody2D bullet = bulletTcn.Instantiate<RigidBody2D>();


            AnimatedSprite2D parent = (AnimatedSprite2D)GetParent();
            

            if (parent.FlipH)
            {
                bullet.LinearVelocity = bullet.Transform.X * - bulletSpeed;

                bullet.GlobalPosition = GlobalPosition - _Size;
            }
            else if (!parent.FlipH)
            {
                bullet.LinearVelocity = bullet.Transform.X * bulletSpeed;

                bullet.GlobalPosition = GlobalPosition;
            }


            GetTree().Root.AddChild(bullet);

            timeUntilFire = 0f;
        }
        else
        {
            timeUntilFire += (float)delta;
        }

    }
}
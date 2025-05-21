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


            Node2D parent = (Node2D)GetParent();

            CharacterBody2D parentParent = (CharacterBody2D)parent.GetParent();

            AnimatedSprite2D parentAnimatedSprite2D = (AnimatedSprite2D)parentParent.GetChild(1);




            

            if (parentAnimatedSprite2D.FlipH)
            {
                bullet.LinearVelocity = bullet.Transform.X * - bulletSpeed;

                bullet.GlobalPosition = GlobalPosition - _Size;
            }
            else if (!parentAnimatedSprite2D.FlipH)
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
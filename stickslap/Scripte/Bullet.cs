using Godot;
using System;

public partial class Bullet : Area2D
{
    [Export]
    public int Speed = 400;

    [Export]
    public int Damage = 10;

    private Vector2 _velocity;

    public override void _Ready()
    {
        // Initialize the bullet's velocity
        _velocity = new Vector2(Speed, 0).Rotated(Rotation);
    }

    public override void _Process(double delta)
    {
        // Move the bullet
        Position += _velocity * (float)delta;
    }

    // private void OnAreaEntered(Area2D area)
    // {
    ////Check if the bullet hit an enemy
    // if (area is Enemy enemy)
    // {
    // enemy.TakeDamage(Damage);
    // QueueFree(); // Remove the bullet after hitting
    // }
    // }
    // private void OnBodyEntered(Node body)
    // {
    ////Check if the bullet hit a wall or other object
    // if (body is Wall)
    // {
    // QueueFree(); // Remove the bullet after hitting
    // }
    // }
}
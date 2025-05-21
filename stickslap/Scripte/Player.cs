using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 400;

    private float _jumpforce = 740f;

    [Export] public Node2D Arm;
    [Export] public float ArmLength = 20f;


    /// <summary>
    /// Propriété qui sert a faire la décelération quand on saute et qui prends _jumpforce comme base
    /// </summary>
    private float _currentJumpforce;

    /// <summary>
    /// Propriété pour savoir si le personnage est en train de sauter
    /// </summary>
    private bool _isJumping = false;

    private bool _onChangingMap = false;
    public double gravity { get; set; } = 9.81;
    private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    public float Gravity { get => _gravity; set { _gravity = value; } }

    private AnimatedSprite2D _sprite;
    private AnimatedSprite2D _weapon;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _sprite = (AnimatedSprite2D)GetChild(1);
        _currentJumpforce = _jumpforce;
        _weapon = (AnimatedSprite2D)_sprite.GetChild(0).GetChild(0);
        //_bullet = (Node2D)_sprite.GetChild(1);

        base._Ready();
    }

    public Vector2 GetInput()
    {
        return Input.GetVector("left", "right", "jump", "down");
    }



    public override void _PhysicsProcess(double delta)
    {
        Vector2 vector = Velocity;
        Vector2 inputDirection = GetInput();

        float tmp = 0;

        if (!IsOnFloor() && Velocity.Y >= 0)
        {
            _currentJumpforce = _jumpforce;
            _isJumping = false;
            tmp = (Gravity * (float)delta);
            vector.Y = tmp * 14;
        }
        else if (IsOnFloor() && Input.IsActionJustPressed("jump") || _isJumping)
        {
            vector.Y = _currentJumpforce * -1;
            _currentJumpforce -= _jumpforce * 5 / 100;
            _isJumping = true;
        }

        //EN TESTE

        //var parent = this.GetParent();
        //if (parent is GameManager gameManager)
        //{
        //    if (!_onChangingMap)
        //    {
        //        int result = gameManager.IsPlayerBorderMap(this.Position);
        //        GD.Print(result);
        //        if (result == 1)
        //        {
        //            //GD.Print(gameManager.sizeMap.X);

        //            gameManager.LoadNextChunk();
        //            gameManager.SpawnPlayerOnOrigin();

        //        }
        //        else if (result == -1)//si reviens en arriere
        //        {

        //        }
        //        //_onChangingMap = true;
        //    }



        //}




        vector.X = inputDirection.X * Speed;
        Velocity = vector;


        ChangeAnimation();

        MoveAndSlide();



    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void ChangeAnimation()
    {



        float VelocityX = Velocity.X;
        float VelocityY = Velocity.Y;



        //    switch (true)
        //    {
        //        case true when VelocityY > 0:

        //            //if (_sprite.Animation == "Fall" || _sprite.Animation == "Falling")
        //            //{
        //            //    if(_sprite.Frame == _sprite.SpriteFrames.GetFrameCount("Fall"))
        //            //        _sprite.Play("Falling");
        //            //    break;
        //            //}

        //            //_sprite.Play("Falling");

        //            if (VelocityX > 0)
        //                _sprite.FlipH = false;
        //            else if (VelocityX < 0)
        //                _sprite.FlipH = true;
        //            break;

        //        case true when (VelocityX > 0 && VelocityY == 0):
        //            _sprite.Play("Run");
        //            _sprite.FlipH = false;
        //            break;

        //        case true when (VelocityX < 0 && VelocityY == 0):
        //            _sprite.Play("Run");
        //            _sprite.FlipH = true;
        //            break;

        //        default:
        //            _sprite.Play("Idle");
        //            break;
        //    }

        //}
        switch (true)
        {
            case true when VelocityY > 0:

                //if (_sprite.Animation == "Fall" || _sprite.Animation == "Falling")
                //{
                //    if(_sprite.Frame == _sprite.SpriteFrames.GetFrameCount("Fall"))
                //        _sprite.Play("Falling");
                //    break;
                //}



                if (VelocityX > 0)
                {
                    _sprite.FlipH = false;
                    if (_weapon.FlipH)
                    {
                        _weapon.FlipH = false;
                        _weapon.Position = new Vector2(_weapon.Position.X + 4, _weapon.Position.Y);
                        //_bullet.Position = new Vector2(11, _bullet.Position.Y);
                    }

                }
                else if (VelocityX < 0)
                {
                    _sprite.FlipH = true;
                    if (!_weapon.FlipH)
                    {
                        _weapon.FlipH = true;
                        _weapon.Position = new Vector2(_weapon.Position.X - 4, _weapon.Position.Y);
                        //_bullet.Position = new Vector2(-11, _bullet.Position.Y);
                    }
                    _weapon.FlipH = true;
                }
                break;

            case true when (VelocityX > 0 && VelocityY == 0):
                _sprite.Play("Run");
                _sprite.FlipH = false;
                if (_weapon.FlipH)
                {
                    _weapon.FlipH = false;
                    _weapon.Position = new Vector2(_weapon.Position.X + 50, _weapon.Position.Y);
                    //_bullet.Position = new Vector2(11, _bullet.Position.Y);
                }
                break;

            case true when (VelocityX < 0 && VelocityY == 0):
                _sprite.Play("Run");
                _sprite.FlipH = true;
                if (!_weapon.FlipH)
                {
                    _weapon.FlipH = true;
                    _weapon.Position = new Vector2(_weapon.Position.X - 50, _weapon.Position.Y);
                    //_bullet.Position = new Vector2(-11, _bullet.Position.Y);
                }
                _weapon.FlipH = true;
                break;

            default:
                _sprite.Play("Idle");
                break;
        }
    }


}



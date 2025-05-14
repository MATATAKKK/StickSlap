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

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprite = (AnimatedSprite2D)GetChild(0);
		_currentJumpforce = _jumpforce;

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

	private enum WeaponType
	{
		ArmesBlanches, // coeff 0.8
		Leger,         // coeff 0.7
		Moyen,         // coeff 0.5
		Lourdes,       // coeff 0.3
		Magiques       // coeff 0.6
	}

	/// <summary>
	/// À appeler quand le joueur subit une attaque.
	/// </summary>
	/// <param name="incomingDamage">Dégâts bruts de l’attaque.</param>
	/// <param name="type">Type d’arme utilisée.</param>
	public void ReceiveDamage(int incomingDamage, WeaponType type)
	{
		int reduced = CalculateReducedDamage(incomingDamage, type);
		_currentHealth -= reduced;

		GD.Print($"[{type}] Attaque: {incomingDamage} ➔ {reduced} reçus. Santé: {_currentHealth}/{MaxHealth}");

		// Jouer animation de hit ou de blocage si besoin
		if (_animPlayer != null)
		{
			var anim = reduced < incomingDamage ? "block_hit" : "hit";
			_animPlayer.Play(anim);
		}

		if (_currentHealth <= 0)
			Die();
	}

	private int CalculateReducedDamage(int dmg, WeaponType type)
	{
		float coeff = type switch
		{
			WeaponType.ArmesBlanches => 0.8f,
			WeaponType.Leger         => 0.7f,
			WeaponType.Moyen         => 0.5f,
			WeaponType.Lourdes       => 0.3f,
			WeaponType.Magiques      => 0.6f,
			_                        => 1f
		};
		return Mathf.CeilToInt(dmg * coeff);
	}

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


		//ChangeAnimation();

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



		switch (true)
		{
			case true when VelocityY > 0:

				//if (_sprite.Animation == "Fall" || _sprite.Animation == "Falling")
				//{
				//    if(_sprite.Frame == _sprite.SpriteFrames.GetFrameCount("Fall"))
				//        _sprite.Play("Falling");
				//    break;
				//}

				//_sprite.Play("Falling");

				if (VelocityX > 0)
					_sprite.FlipH = false;
				else if (VelocityX < 0)
					_sprite.FlipH = true;
				break;

			case true when (VelocityX > 0 && VelocityY == 0):
				//_sprite.Play("Walk");
				_sprite.FlipH = false;
				break;

			case true when (VelocityX < 0 && VelocityY == 0):
				//_sprite.Play("Walk");
				_sprite.FlipH = true;
				break;

			default:
				//_sprite.Play("Idle");
				break;
		}

	}

}

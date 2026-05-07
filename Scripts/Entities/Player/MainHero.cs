using Godot;
using System;

public partial class MainHero : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	
	private AnimatedSprite2D _animatedSprite;
	
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (_animatedSprite == null)
		{
			GD.PrintErr("AnimatedSprite2D не подключен как дочерний узел.");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		
		UpdateAnimations(direction.X, IsOnFloor());
	}
		
	private void UpdateAnimations(float horizontalDirection, bool isOnFloor)
	{
		if (_animatedSprite == null) 
		{
			return;
		}

		if (!isOnFloor)
		{
			_animatedSprite.Play("Jump");
		}
		else if (Mathf.Abs(horizontalDirection) > 0.01f)
		{
			_animatedSprite.Play("Run");
			_animatedSprite.FlipH = horizontalDirection < 0;
		}
		else
		{
			if (_animatedSprite.SpriteFrames.HasAnimation("Idle"))
			{
				_animatedSprite.Play("Idle");
			}
			else
			{
				_animatedSprite.Stop(); 
			}
		}
	}
}

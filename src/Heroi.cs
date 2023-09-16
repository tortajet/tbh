using Godot;
using Mechxmas.Extensions;
using System;

public partial class Heroi : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	

	public override void _PhysicsProcess(double delta)
	{					
		Velocity = Velocity
            .HandleGravity(this, (float)delta)
            .HandleInput(this, Speed);

		MoveAndSlide();
	}
}

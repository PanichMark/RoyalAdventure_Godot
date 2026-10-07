using Godot;

public partial class PlayerMovementController : CharacterBody3D
{
	[Export] public float Speed = 5.0f;
	[Export] public float Acceleration = 10.0f;
	[Export] public float JumpVelocity = 4.5f;
	[Export] public float Gravity = 9.8f;

	private Vector3 _velocity;

	public override void _PhysicsProcess(double delta)
	{
		Vector3 direction = Vector3.Zero;

		if (Input.IsKeyPressed(Key.A)) direction.X -= 1.0f;
		if (Input.IsKeyPressed(Key.D)) direction.X += 1.0f;
		if (Input.IsKeyPressed(Key.W)) direction.Z -= 1.0f;
		if (Input.IsKeyPressed(Key.S)) direction.Z += 1.0f;

		if (direction != Vector3.Zero) direction = direction.Normalized();

		if (!IsOnFloor()) _velocity.Y -= Gravity * (float)delta;
		else if (Input.IsKeyPressed(Key.Space)) _velocity.Y = JumpVelocity;

		_velocity.X = Mathf.Lerp(_velocity.X, direction.X * Speed, Acceleration * (float)delta);
		_velocity.Z = Mathf.Lerp(_velocity.Z, direction.Z * Speed, Acceleration * (float)delta);

		Velocity = _velocity;
		MoveAndSlide();
	}
}

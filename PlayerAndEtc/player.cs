using Godot;

namespace Resources
{
	public class player : KinematicBody2D
	{
		// Declare member variables here. Examples:
		// private int a = 2;
		// private string b = "text";

		// Called when the node enters the scene tree for the first time.
		const float gravity = 1000.0f;
		[Export] public int speed = 20;
		public Vector2 velocity = new Vector2();
		public bool onfloor = false;
		public bool is_walk = false;
		public override void _Ready()
		{
		}
		private bool GetInput(float delta)
		{
			//velocity = new Vector2();
			velocity.y += delta * gravity;
			bool ifpressed = false;
			if (IsOnFloor())
			{
				if (Input.IsActionPressed("ui_right"))
				{

					velocity.x += 5 * speed;
					ifpressed = true;
				}
				if (Input.IsActionPressed("ui_left"))
				{
					velocity.x -= 5 * speed;
					ifpressed = true;
					//	velocity.y += 1 * speed;
				}
				if (Input.IsActionPressed("ui_up"))
					velocity.y = -20 * speed;
			}
			return ifpressed;

			//velocity = velocity.Normalized() * speed;
		}
		public void ControlOut(Controller input)
		{
			if (onfloor)
			{
				switch (input)
				{
					case Controller.Right:
						{
							velocity.x += 5 * speed;
							is_walk = true;
							break;
						}
					case Controller.Left:
						{
							velocity.x -= 5 * speed;
							is_walk = true;
							break;
						}
					case Controller.Up:
						{
							velocity.y = -20 * speed;
							break;
						}
					case Controller.Empty:
						{
							break;
						}

				}
			}

		}
		public override void _PhysicsProcess(float delta)
		{
			var collisionInfo = MoveAndCollide(velocity * delta);
			MoveAndSlide(velocity, Vector2.Up);
			if (IsOnWall())
			{
				//GD.Print("Clash");
				velocity.x = -velocity.x / 2;
				//velocity = velocity.Bounce(collisionInfo.Normal) / 2;
			}
			is_walk = GetInput(delta: delta);
			onfloor = IsOnFloor();
			if (onfloor && !is_walk)
			{
				velocity.x = velocity.x * 9 / 10;
			}

		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}




using Godot;
//using System;
namespace Resources
{
	public class butter : KinematicBody2D
	{
		// Declare member variables here. Examples:
		// private int a = 2;
		// private string b = "text";

		// Called when the node enters the scene tree for the first time.
		public Vector2 vectory = new Vector2(200, 0);
		public override void _Ready()
		{

		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(float delta)
		{
			MoveAndSlide(vectory);
			var collisionInfo = MoveAndCollide(vectory * delta);
			if (collisionInfo != null)
			{
				QueueFree();
			}

		}
	}
}

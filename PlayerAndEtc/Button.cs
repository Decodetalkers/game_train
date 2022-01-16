using Godot;
//using System;
namespace Resources
{
	public class Button : Node2D
	{
		// Declare member variables here. Examples:
		// private int a = 2;
		// private string b = "text";
		// Called when the node enters the scene tree for the first time.
		[Signal]
		public delegate void SignalUp();
		[Signal]
		public delegate void SignalLeft();
		[Signal]
		public delegate void SignalRight();
		private bool up = false;
		private bool left = false;
		private bool right = false;
		public override void _Ready()
		{
			GetNode("left").Connect("button_down", this, nameof(_left_button_down));
			GetNode("left").Connect("button_up", this, nameof(_left_button_up));
			GetNode("up").Connect("button_down", this, nameof(_up_button_down));
			GetNode("up").Connect("button_up", this, nameof(_up_button_up));
			GetNode("right").Connect("button_down", this, nameof(_right_button_down));
			GetNode("right").Connect("button_up", this, nameof(_right_button_up));
		}
		public void _left_button_down()
		{
			left = true;
		}
		public void _left_button_up()
		{
			left = false;
		}
		public void _up_button_down()
		{
			up = true;

		}
		public void _up_button_up()
		{
			up = false;
		}
		public void _right_button_down()
		{
			right = true;
		}
		public void _right_button_up()
		{
			right = false;
		}
		public override void _Process(float delta)
		{
			if (left)
				EmitSignal(nameof(SignalLeft));
			if (up)
				EmitSignal(nameof(SignalUp));
			if (right)
				EmitSignal(nameof(SignalRight));
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}

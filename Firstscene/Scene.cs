using Godot;
//using System;
namespace FirstScene
{
	public class Scene : Node2D
	{
		// Declare member variables here. Examples:
		// private int a = 2;
		// private string b = "text";

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			GetNode("Button").Connect("SignalLeft", this, nameof(_button_left));
			GetNode("Button").Connect("SignalRight", this, nameof(_button_right));
			GetNode("Button").Connect("SignalUp", this, nameof(_button_up));
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(float delta)
		{
			if (Input.IsActionJustPressed("shoot"))
			{
				var scene = GD.Load<PackedScene>("res://PlayerAndEtc/butter.tscn");
				var instance = (Resources.butter)scene.Instance();
				var position = GetNode<Resources.player>("Player").Position;
				instance.Position = new Vector2(80, 0) + position;
				AddChild(instance);
			}
		}
		public void _button_left()
		{
			GD.Print("left");
			GetNode<Resources.player>("Player").ControlOut(Resources.Controller.Left);

		}
		public void _button_right()
		{
			GD.Print("right");
			GetNode<Resources.player>("Player").ControlOut(Resources.Controller.Right);
		}
		public void _button_up()
		{
			GetNode<Resources.player>("Player").ControlOut(Resources.Controller.Up);
			GD.Print("up");
		}
	}
}

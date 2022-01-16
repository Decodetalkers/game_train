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
	}
}

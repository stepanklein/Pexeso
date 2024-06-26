using Godot;
using Pexeso.Core;
using System;

public partial class new_script : Node
{
	private string test;
	public string Test { get =>  test; set => test = value; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process( double delta)
	{
		var game = new GemeManager();
	}
}

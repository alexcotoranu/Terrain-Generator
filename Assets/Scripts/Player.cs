using Godot;
using System;

public class Player : KinematicBody
{
    [Export]
    public int moveSpeed = 250;
    public override void _PhysicsProcess(float delta)
    {
        var motion = new Vector3();
        // Vector2 motion = new Vector3();
        motion.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        motion.z = -Input.GetActionStrength("move_forward") + Input.GetActionStrength("move_backward");
        motion.y = Input.GetActionStrength("jump");

        // var myNode = GetNode("sdsd") as KinematicBody;
        // var myNode = GetNode<KinematicBody>("sdsd");

        // KinematicBody child = this.GetNode<KinematicBody>("sdsd_is_a_child")
        // var child = this.GetNode<KinematicBody>("sdsd_is_a_child");
        // child.GlobalPosition = new Vector3(0,0,0);

        //var packedScene = GD.Load("path/to/scene_file) // to create PackedScene object
        //PackedScene packedScene = GD.Load("path/to/scene_file)
        //packedScene.Instance() // creates instance

        uint randomNumber = GD.Randi() % 4;
        float AMOUNT = 0.01f;

        if (randomNumber == 0)
        {
            this.Translation += new Vector3(0, 0, -AMOUNT);
        }
        if (randomNumber == 1)
        {
            this.Translation += new Vector3(0, 0, AMOUNT);
        }
        if (randomNumber == 2)
        {
            this.Translation += new Vector3(-AMOUNT, 0, 0);
        }
        if (randomNumber == 3)
        {
            this.Translation += new Vector3(AMOUNT, 0, 0);
        }

        MoveAndCollide(motion.Normalized() * moveSpeed * delta);

        //base._PhysicsProcess(delta);
    }
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

using Godot;
using System;

[Tool]
public class TerrainType : Resource
{
    [Export] public String name { get; set; } = "Terrain Type Name";
    [Export] public float height { get; set; } = 0;
    [Export] public Color colour { get; set; } = default(Color);
}
using Godot;
using System;

public class CustomNode2D : Node2D
{
    private Texture _texture;
    public Texture Texture
    {
        get
        {
            return _texture;
        }

        set
        {
            _texture = value;
            Update();
        }
    }

    public override void _Draw()
    {
        // DrawTextureRect(_texture,)
        DrawTexture(_texture, new Vector2());
    }
}
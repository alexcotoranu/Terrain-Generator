using Godot;
using System;

[Tool]
public class MapDisplay : MeshInstance
{
    /// public Renderer textureRenderer;

    public SpatialMaterial spatialMaterial;

    public void DrawTexture(ImageTexture imageTexture)
    {
        /// textureRenderer.sharedMaterial.mainTexture = texture;
        /// textureRenderer.transform.localScale = new Vector3(width, 1, height);
        var height = imageTexture.GetHeight();
        var width = imageTexture.GetWidth();

        spatialMaterial = (SpatialMaterial)this.MaterialOverride;
        spatialMaterial.AlbedoTexture = imageTexture;
        spatialMaterial.FlagsAlbedoTexForceSrgb = true;
        spatialMaterial.FlagsUnshaded = true;
        spatialMaterial.AlbedoTexture.Flags = (uint)Godot.Texture.FlagsEnum.MirroredRepeat;
        this.Scale = new Vector3(width, 1, height);
    }
}

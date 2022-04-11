// public SpatialMaterial spatialMaterialz;
// public Material material;

// public Mesh meshToBeTextured;
// public VisualServer textureRenderer;
// public Mesh mesh;
// public SpatialMaterial spatialMaterial = new SpatialMaterial();

//public override void _Ready()
//{
///TEXTURE TEST
// this.Mesh.SurfaceSetMaterial(0, spatialMaterial);
// spatialMaterial.AlbedoColor = Color.Color8(255, 255, 128, 1);
// this.MaterialOverride = spatialMaterial;
// material = this.GetSurfaceMaterial(0);

// NoiseTexture noiseTexturez = new NoiseTexture();
// noiseTexturez.Width = 512;
// noiseTexturez.Height = 512;
// noiseTexturez.Noise = new OpenSimplexNoise();
// var img = noiseTexturez.Noise.GetImage(512, 512);
// var imgData = noiseTexturez.Noise.GetImage(512, 512).GetData();

// ImageTexture imageTexturez = new ImageTexture();
// imageTexturez.Create(512, 512, Godot.Image.Format.Rgb8, 2);
// imageTexturez.CreateFromImage(img, 2);

// spatialMaterialz = (SpatialMaterial)this.MaterialOverride;
// spatialMaterialz.AlbedoTexture = imageTexturez;

// var texturez = spatialMaterialz.AlbedoTexture.GetData();
// GD.Print(noiseTexturez.Noise.GetImage(512, 512).GetData());
// GD.Print(imageTexturez.GetData());

/// SCALING TEST
// Vector3 planeSize = new Vector3(512, 1, 512);
// // this.Scale = planeSize;
// GD.Print(this.Mesh.GetAabb());

//}


// Godot.ImageTexture.CreateFromImage(Godot.Image,System.UInt32);
// imageTexture.SetData(colorMap)
// spatialMaterial.DetailAlbedo = imageTexture;

// spatialMaterial.DetailAlbedo = noiseTexture;
// spatialMaterial.AlbedoTexture = noiseTexture;
// spatialMaterial.AlbedoColor = Color.Color8(255, 255, 128, 1);

// spatialMaterial.AlbedoColor = colorMap;

////download texture from graphics card and modify it
// Sprite map = GetNode("/root/Node2D/Sprite") as Sprite;
// var image = map.Texture.GetData();
// image.Lock();

// for (int w = 0; w <= map.Texture.GetWidth(); w++)
// {
//     for (int h = 0; h <= map.Texture.GetHeight(); h++)
//     {
//         image.SetPixel(w, h, Color.Color8(244, 253, 21, 50));
//     }
// }

// image.Unlock();

// var img = Image.new()
//     img.create(img_width, img_height, false, Image.FORMAT_RGBA8)
//     img.lock()
//     img.set_pixelv(Vector2(x, y), color) # Works
//     img.unlock()
//     img.set_pixelv(Vector2(x, y), color) # Does not have an effect


////upload texture back to graphics card
// var tex = new ImageTexture();
// tex.CreateFromImage(image, map.Texture.Flags);
// map.Texture = tex;

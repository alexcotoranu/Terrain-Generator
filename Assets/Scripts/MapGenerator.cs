using Godot;
using System;

[Tool]
public class MapGenerator : Spatial
{
    public enum DrawMode { NoiseMap, ColourMap };

    [Export]
    public DrawMode _drawMode
    {
        get => drawMode;
        set
        {
            drawMode = value;
            TryAutoUpdate();
        }
    }
    private DrawMode drawMode;

    // public Texture _texture
    // {
    //     get => texture;
    //     set
    //     {
    //         texture = value;
    //         Update();
    //     }
    // }
    //  private Texture texture;


    [Export(PropertyHint.Range, "1,1000")]
    public int _mapWidth
    {
        get => mapWidth;
        set
        {
            mapWidth = value;
            TryAutoUpdate();
        }
    }
    private int mapWidth;

    [Export(PropertyHint.Range, "1,1000")]
    public int _mapHeight
    {
        get => mapHeight;
        set
        {
            mapHeight = value;
            TryAutoUpdate();
        }
    }
    private int mapHeight;

    [Export]
    public float _noiseScale
    {
        get => noiseScale;
        set
        {
            noiseScale = value;
            TryAutoUpdate();
        }
    }
    private float noiseScale;

    [Export(PropertyHint.Range, "0,9")]
    public int _octaves
    {
        get => octaves;
        set
        {
            octaves = value;
            TryAutoUpdate();
        }
    }
    private int octaves;

    [Export(PropertyHint.Range, "0,1")]
    public float _persistance
    {
        get => persistance;
        set
        {
            persistance = value;
            TryAutoUpdate();
        }
    }
    private float persistance;

    [Export(PropertyHint.Range, "1,1000")]
    public float _lacunarity
    {
        get => lacunarity;
        set
        {
            lacunarity = value;
            TryAutoUpdate();
        }
    }
    private float lacunarity;

    [Export]
    public int _seed
    {
        get => seed;
        set
        {
            seed = value;
            TryAutoUpdate();
        }
    }
    private int seed;

    [Export]
    public Vector2 _offset
    {
        get => offset;
        set
        {
            offset = value;
            TryAutoUpdate();
        }
    }
    private Vector2 offset;


    [Export]
    public bool autoUpdate;

    private bool updateMap = false;

    [Export]
    public bool _updateMap
    {
        get => updateMap;
        set
        {
            if (value == true)
            {
                GenerateMap();
            }
        }
    }

    [Export]
    public Resource[] _regions
    {
        get => regions;
        set
        {
            Array.Resize(ref regions, value.Length);
            regions = value;
            for (int i = 0; i < regions.Length; i++)
            {
                if (regions[i] == null)
                {
                    // Terrain newTerrain = new Terrain();
                    // newTerrain.ResourceName = "New Terrain" + i.ToString();
                    regions[i] = new Resource();
                    regions[i].ResourceName = "New Terrain" + i.ToString();
                    ResourceSaver.Save("res://Assets/Resources/NewTerrain" + i.ToString() + ".tres", regions[i]);
                    ulong objId = regions[i].GetInstanceId(); //because of displacement issue: https://github.com/godotengine/godot/issues/31994
                    regions[i].SetScript(ResourceLoader.Load("res://Assets/Scripts/Resources/TerrainType.cs"));
                    regions[i] = (Resource)GD.InstanceFromId(objId); //because of displacement issue: https://github.com/godotengine/godot/issues/31994
                    regions[i].ResourcePath = "res://Assets/Resources/NewTerrain" + i.ToString() + ".tres";
                }
            }
            TryAutoUpdate();
        }
    }

    private Resource[] regions;

    public void TryAutoUpdate()
    {
        if (autoUpdate)
        {
            GenerateMap();
        }
    }

    public void GenerateMap()
    {
        // GD.Print("Generate map");
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    // ulong objId = regions[i].GetInstanceId();
                    // Terrain TempTerrain = (Terrain)GD.InstanceFromId(objId);

                    // GD.Print(regions[i].ResourcePath);
                    TerrainType LoadedRegion = (TerrainType)ResourceLoader.Load(regions[i].ResourcePath);

                    if (currentHeight <= LoadedRegion.height)
                    {
                        colourMap[y * mapWidth + x] = LoadedRegion.colour;
                        // Console.WriteLine(string.Join("],[", colourMap));
                        break;
                    }
                }
            }
        }

        // MapDisplay display = FindObjectOfType<MapDisplay> ();
        MapDisplay display = GetNode<MapDisplay>("MapDisplay");
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }

    }

    // void OnValidate()
    // {
    //     if (_mapWidth < 1)
    //     {
    //         mapWidth = 1;
    //     }
    //     if (_mapHeight < 1)
    //     {
    //         mapHeight = 1;
    //     }
    // }
}
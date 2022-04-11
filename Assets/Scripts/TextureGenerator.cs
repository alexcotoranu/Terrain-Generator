using Godot;
using System;

[Tool]
public static class TextureGenerator
{
    public static ImageTexture TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        // var file = new File();
        // file.Open("res://Temp/log.txt", File.ModeFlags.Write);
        // file.StoreVar(colourMap.ToString());
        // file.Close();

        ImageTexture imageTexture = new ImageTexture();

        var colourByteArray = new byte[width * height * 4];
        var byteCount = 0;
        for (int i = 0; i < colourMap.Length; i++)
        {
            for (int rgba = 0; rgba < 4; rgba++)
            {
                var colourToSet = colourMap[i][rgba];
                var colourByte = BitConverter.GetBytes(colourToSet);

                colourByteArray[byteCount] = colourByte[rgba];

                byteCount += 1;
                // Console.WriteLine("--> colorByteArray[" + (i + rgba).ToString() + "]");
                // Console.WriteLine(string.Join("],[", colourByteArray[i + rgba]));

            }
        }

        Image image = new Image();
        image.CreateFromData(width, height, false, Godot.Image.Format.Rgba8, colourByteArray);

        imageTexture.CreateFromImage(image);
        return imageTexture;
    }

    public static ImageTexture TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Color black = Color.Color8(0, 0, 0, 1);
        Color white = Color.Color8(255, 255, 255, 1);

        ImageTexture imageTexture = new ImageTexture();

        Color[] colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colourMap[y * width + x] = black.LinearInterpolate(white, heightMap[x, y]);
            }
        }

        // var colourByteArray = new byte[heightMap.Length * 4];

        // for (int y = 0; y < height; y++)
        // {
        //     for (int x = 0; x < width; x++)
        //     {
        //         for (int c = 0; c < 4; c++)
        //         {
        //             colourByteArray[y * width + x] = (Byte)(colourMap[y * width + x][c] * 255);
        //         }
        //     }
        // }

        var colourByteArray = new byte[width * height * 4];
        var byteCount = 0;
        for (int i = 0; i < colourMap.Length; i++)
        {
            for (int rgba = 0; rgba < 4; rgba++)
            {
                var colourToSet = colourMap[i][rgba];
                // var colourByte = Convert.ToByte(colourToSet);
                var colourByte = BitConverter.GetBytes(colourToSet);

                colourByteArray[byteCount] = colourByte[rgba];
                byteCount += 1;
                // Console.WriteLine("--> colorByteArray[" + (i + rgba).ToString() + "]");
                // Console.WriteLine(string.Join("],[", colourByteArray[i + rgba]));

            }
        }

        Buffer.BlockCopy(heightMap, 0, colourByteArray, 0, colourByteArray.Length);

        // Console.WriteLine(string.Join("],[", colourMap));
        // Console.WriteLine(string.Join("],[", colourMap[0][2]));
        // Console.WriteLine(string.Join("],[", heightMap[1, 1]));

        Image image = new Image();
        image.CreateFromData(width, height, false, Godot.Image.Format.Rf, colourByteArray);
        // image.SavePng("res://Temp/temp.png");
        imageTexture.CreateFromImage(image);

        return imageTexture;
        // return TextureFromColourMap(colourMap, width, height);
    }
}
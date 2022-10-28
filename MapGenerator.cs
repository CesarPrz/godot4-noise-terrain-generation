using Godot;
using System;
using System.Collections.Generic;

public partial class MapGenerator : TileMap
{
	[Export]
	public int width = 250;
	[Export]
	public int height = 250;
	public FastNoiseLite fastNoiseLite = new();


	public void generate_world()
	{
		// A random number generator which we will use for the noise seed
		RandomNumberGenerator rng = new();
		// The list of tiles we want to use with the noise. Order matters !
		List<Vector2i> tilesList = new();

		tilesList.Add(TileDictionary.WATER);
		tilesList.Add(TileDictionary.SAND);
		tilesList.Add(TileDictionary.GRASSIER_GRASS);
		tilesList.Add(TileDictionary.GRASS);
		tilesList.Add(TileDictionary.ROCK);
		tilesList.Add(TileDictionary.ROCKIER_ROCK);

		rng.Randomize();
		fastNoiseLite.Seed = rng.RandiRange(0, 500);

		// Try out other parameters from [NoiseTypeEnum] for cool variants !
		fastNoiseLite.NoiseType = FastNoiseLite.NoiseTypeEnum.Simplex;
		// The number of layers we want to generate on the noise. Each tile will have its own layer.
		fastNoiseLite.FractalOctaves = tilesList.Count;

		fastNoiseLite.FractalGain = 0;

		// We iterate along the width and height of the map, and 
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				float absNoise = Math.Abs(fastNoiseLite.GetNoise2d(x, y));

				int tileToPlace = (int)Math.Floor((absNoise * tilesList.Count));
				SetCell(0, new(x, y), 0, tilesList[tileToPlace]);

			}
		}


	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		generate_world();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

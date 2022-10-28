using Godot;

public class TileDictionary
{
    public static Vector2i WATER = new(0, 0);
    public static Vector2i SAND = new(2, 0);
    public static Vector2i GRASS = new(0, 2);
    public static Vector2i GRASSIER_GRASS = new(2, 4);
    public static Vector2i ROCK = new(2, 2);
    public static Vector2i ROCKIER_ROCK = new(0, 4);
}

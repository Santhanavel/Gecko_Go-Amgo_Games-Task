using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public WormData[] worms;
}

[System.Serializable]
public class WormData
{
    public Color color;
    public Vector2[] path;
}

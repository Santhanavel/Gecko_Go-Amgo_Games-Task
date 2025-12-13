using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GameObject wormPrefab;
    public LevelData level;
    void Start()
    {
        foreach (WormData worm in level.worms)
        {
            Create(worm.color, worm.path);
        }
    }

    void Create(Color color, Vector2[] path)
    {
        GameObject worm = Instantiate(wormPrefab, transform);
        worm.transform.position = path[0];

        var lr = worm.GetComponentInChildren<LineRenderer>();
        lr.positionCount = path.Length;
        for (int i = 0; i < path.Length; i++)
            lr.SetPosition(i, path[i]);

        lr.startColor = color;
        lr.endColor = color;

        worm.GetComponentInChildren<SpriteRenderer>().color = color;
    }
}

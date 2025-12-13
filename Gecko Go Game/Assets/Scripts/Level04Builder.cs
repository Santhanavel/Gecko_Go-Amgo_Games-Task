using UnityEngine;

public class Level04Builder : MonoBehaviour
{
    public GameObject wormPrefab;
    void Start()
    {
        Create(Color.yellow, YellowPath());
        Create(new Color(0.4f, 0.2f, 0.1f), BrownPath());
        Create(Color.magenta, PurplePath());
        Create(Color.blue, BluePath());
        Create(Color.cyan, CyanPath());
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

    Vector2[] YellowPath() => new[] {
        new Vector2(-4.2f,3.8f), new Vector2(4.2f,3.8f),
        new Vector2(4.2f,-3.8f), new Vector2(-4.2f,-3.8f),
        new Vector2(-4.2f,2f), new Vector2(1.5f,2f)
    };

    Vector2[] BrownPath() => new[] {
        new Vector2(-3f,2.8f), new Vector2(2.8f,2.8f),
        new Vector2(2.8f,-1f)
    };

    Vector2[] PurplePath() => new[] {
        new Vector2(-0.8f,2f), new Vector2(1.8f,2f)
    };

    Vector2[] BluePath() => new[] {
        new Vector2(-1.5f,-0.5f), new Vector2(0.5f,-0.5f),
        new Vector2(0.5f,0.8f)
    };

    Vector2[] CyanPath() => new[] {
        new Vector2(-2.8f,-2.5f), new Vector2(-2.8f,-0.5f),
        new Vector2(2.8f,-0.5f), new Vector2(2.8f,-2f)
    };
}
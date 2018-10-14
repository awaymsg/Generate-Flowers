using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalDrawer : MonoBehaviour {

    public float Size;
    public Material PetalMaterial;
    public int Randomseed;
    public int Geometry;
    public Color[] PrettyColors;

    Mesh mesh;
    MeshRenderer rendererer;
    float MoveZ;
    Vector3[] vertices;
    int[] triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        rendererer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        MakeMeshData();
        DrawPetal();
        SetColor(Randomseed);
    }

    void MakeMeshData()
    {
        var rand = new System.Random(Randomseed);
        double randnum = rand.NextDouble();
        MoveZ = (float)(rand.NextDouble());
        Size = (float)rand.NextDouble() * 0.8f + 0.5f;
        float wideth = (float)rand.NextDouble() * 0.3f + 0.2f;
        if (randnum < 0.33)
        {
            vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(0, 1, 0) * Size, new Vector3(1, 1, -0.5f) * Size };
            triangles = new int[] { 0, 1, 2 };
        } else if (randnum >= 0.33f && randnum < 0.66f)
        {
            vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(-wideth, 0.5f, 0) * Size,
                new Vector3(wideth, 0.5f, -0.5f) * Size, new Vector3(0, 1, MoveZ) };
            triangles = new int[] { 0, 1, 2, 2, 1, 3 };
        } else if (randnum >= 0.66f)
        {
            vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(-wideth, 0.5f, 0) * Size,
                new Vector3(wideth, 0.5f, -0.5f) * Size };
            triangles = new int[] { 0, 1, 2 };
        }
    }

    void DrawPetal()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    public void SetColor(int randomseed)
    {
        var rand = new System.Random(randomseed);
        double randnum = rand.NextDouble();
        float whiteoffset = (float)rand.NextDouble() / 3;
        float blackoffset = (float)rand.NextDouble() / 3;
        Debug.Log(randnum);
        Material PetalColor = new Material(PetalMaterial);
        rendererer.material = PetalColor;
        if (randnum < 0.125f)
        {
            PetalColor.color = PrettyColors[0] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.125f && randnum < 0.25f)
        {
            PetalColor.color = PrettyColors[1] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.25f && randnum < 0.375f)
        {
            PetalColor.color = PrettyColors[2] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.375f && randnum < 0.5f)
        {
            PetalColor.color = PrettyColors[3] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.5f && randnum < 0.625f)
        {
            PetalColor.color = PrettyColors[4] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.625f && randnum < 0.75f)
        {
            PetalColor.color = PrettyColors[5] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.75f && randnum < 0.875f)
        {
            PetalColor.color = PrettyColors[6] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.875f)
        {
            PetalColor.color = PrettyColors[7] + Color.white * whiteoffset + Color.black * blackoffset;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

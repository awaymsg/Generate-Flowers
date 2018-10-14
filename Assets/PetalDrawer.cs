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
        vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(0, 1, 0) * Size, new Vector3(1, 1, -0.5f) * Size};
        triangles = new int[] { 0, 1, 2 };
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
        float whiteoffset = (float)rand.NextDouble() / 5;
        float blackoffset = (float)rand.NextDouble() / 5;
        Debug.Log(randnum);
        Material PetalColor = new Material(PetalMaterial);
        rendererer.material = PetalColor;
        if (randnum < 0.15f)
        {
            PetalColor.color = PrettyColors[0] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.15f && randnum < 0.3f)
        {
            PetalColor.color = PrettyColors[1] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.3f && randnum < 0.45f)
        {
            PetalColor.color = PrettyColors[2] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.45f && randnum < 0.6f)
        {
            PetalColor.color = PrettyColors[3] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.6f && randnum < 0.75f)
        {
            PetalColor.color = PrettyColors[4] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.75f && randnum < 0.9f)
        {
            PetalColor.color = PrettyColors[5] + Color.white * whiteoffset + Color.black * blackoffset;
        }
        else if (randnum >= 0.9f)
        {
            PetalColor.color = PrettyColors[6] + Color.white * whiteoffset + Color.black * blackoffset;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

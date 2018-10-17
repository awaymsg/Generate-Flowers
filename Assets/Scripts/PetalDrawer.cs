﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalDrawer : MonoBehaviour {

    public float Size;
    public Material PetalMaterial;
    public int Randomseed;
    public int Geometry;
    public Color[] PrettyColors;

    Mesh Mesh;
    MeshRenderer Rendererer;
    Color FlowerColor;
    FlowerStats theflower;
    float MoveZ;
    float MaxSize;
    float XFactor;
    float YFactor;
    float ZFactor;
    float Lifespan;
    Vector3[] Vertices;
    int[] Triangles;

    public enum FlowerType { triFlower, bulbFlower, roundFlower }
    enum LifeCycle { bulbgrow, flowering, fruiting, dying }
    LifeCycle lifec;
    FlowerType flower;

    void Awake()
    {
        Size = 0.05f;
        XFactor = 0;
        YFactor = 0;
        ZFactor = 0.5f;
        Lifespan = 5f;
        lifec = LifeCycle.bulbgrow;
        Mesh = GetComponent<MeshFilter>().mesh;
        Rendererer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        var rand = new System.Random(Randomseed);
        MaxSize = (float)rand.NextDouble() * 0.8f + 0.5f;
        MakeMeshData();
        DrawPetal();
        //MakeInvertMesh(Vertices, Triangles);
        SetColor(Randomseed);
    }

    void MakeMeshData()
    {
        var rand = new System.Random(Randomseed);
        double randnum = rand.NextDouble();
        MoveZ = (float)(rand.NextDouble());
        float wideth = (float)rand.NextDouble() * 0.3f + 0.2f;
        if (randnum < 0.33)
        {
            flower = FlowerType.triFlower;
            Vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(0, 1 * YFactor, 0 - ZFactor) * Size, new Vector3(1 * XFactor, 1 * YFactor, -0.2f -ZFactor) * Size,
                new Vector3(0, 0, 0) * Size, new Vector3(0, 1 * YFactor, 0 - ZFactor) * Size, new Vector3(1 * XFactor, 1 * YFactor, -0.2f - ZFactor) * Size };
            Triangles = new int[] { 0, 1, 2, 3, 5, 4 };
        } else if (randnum >= 0.33f && randnum < 0.66f)
        {
            flower = FlowerType.bulbFlower;
            Vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size,
                new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size, new Vector3(0, 1 * YFactor, MoveZ - ZFactor) * Size,
                new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size,
                new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size, new Vector3(0, 1 * YFactor, MoveZ - ZFactor) * Size };
            Triangles = new int[] { 0, 1, 2, 2, 1, 3, 3, 5, 4, 4, 6, 3 };
        } else if (randnum >= 0.66f)
        {
            flower = FlowerType.roundFlower;
            Vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size, new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size,
                new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size, new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size };
            Triangles = new int[] { 0, 1, 2, 3, 5, 4 };
        }
    }

    void DrawPetal()
    {
        Mesh.Clear();
        Mesh.vertices = Vertices;
        Mesh.triangles = Triangles;
        Mesh.RecalculateNormals();
    }

    void SetColor(int randomseed)
    {
        var rand = new System.Random(randomseed);
        double randnum = rand.NextDouble();
        float whiteoffset = (float)rand.NextDouble() / 3;
        float blackoffset = (float)rand.NextDouble() / 3;
        //Debug.Log(randnum);
        Material PetalColor = new Material(PetalMaterial);
        Rendererer.material = PetalColor;
        if (randnum < 0.125f)
        {
            PetalColor.color = PrettyColors[0] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.125f && randnum < 0.25f)
        {
            PetalColor.color = PrettyColors[1] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.25f && randnum < 0.375f)
        {
            PetalColor.color = PrettyColors[2] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.375f && randnum < 0.5f)
        {
            PetalColor.color = PrettyColors[3] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.5f && randnum < 0.625f)
        {
            PetalColor.color = PrettyColors[4] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.625f && randnum < 0.75f)
        {
            PetalColor.color = PrettyColors[5] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.75f && randnum < 0.875f)
        {
            PetalColor.color = PrettyColors[6] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.875f)
        {
            PetalColor.color = PrettyColors[7] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        FlowerColor = PetalColor.color;
    }

    void MakeInvertMesh (Vector3[] vertices, int[] triangles)
    {
        int v = vertices.Length;
        int t = triangles.Length;
        Vector3[] normalz = Mesh.normals;
        //Debug.Log(v);
        //Debug.Log(t);
    }

    // Update is called once per frame
    void Update () {
        if (Size < MaxSize && lifec == LifeCycle.bulbgrow)
        {
            Size += 0.2f * Time.deltaTime;
        } else if (Size >= MaxSize && lifec == LifeCycle.bulbgrow)
        {
            lifec = LifeCycle.flowering;
            Debug.Log("flowering");
        }
        if (lifec == LifeCycle.flowering)
        {
            if (XFactor <= 1)
                XFactor += 0.1f * Time.deltaTime;
            if (YFactor <= 1)
                YFactor += 0.1f * Time.deltaTime;
            if (ZFactor >= 0)
                ZFactor -= 0.1f * Time.deltaTime;
        }
        if (XFactor >= 1 && YFactor >= 1 && ZFactor <= 0)
            Lifespan -= Time.deltaTime;
        if (Lifespan < 0)
        {
            lifec = LifeCycle.fruiting;
            transform.parent.GetComponent<CenterPointScript>().Size = MaxSize * 0.25f;
            transform.parent.GetComponent<CenterPointScript>().FruitingChange = true;
        }
        if (lifec == LifeCycle.fruiting)
        {
            if (XFactor >= 0)
                XFactor -= 0.2f * Time.deltaTime;
            if (YFactor >= -1)
                YFactor -= 0.2f * Time.deltaTime;
            if (ZFactor >= -1)
                ZFactor -= 0.1f * Time.deltaTime;
        }
        if (lifec == LifeCycle.dying && Size <= 0.05f)
            Destroy(transform.parent.gameObject);
        MakeMeshData();
        DrawPetal();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalDrawer : MonoBehaviour {

    public float Size;
    public bool IsNew = true;
    public Material PetalMaterial;
    public int Randomseed;
    public int Geometry;
    public Color[] PrettyColors;

    Mesh Mesh;
    MeshRenderer Rendererer;
    Color FlowerColor;
    FlowerStats flowerstats = new FlowerStats();
    float MoveZ;
    float xSize;
    float MaxSize;
    float XFactor;
    float YFactor;
    float ZFactor;
    float Lifespan;
    float AudioRand;
    int SeedNum;
    Vector3[] Vertices;
    int[] Triangles;

    public enum LifeCycle { bulbgrow, flowering, fruiting, dying }
    public LifeCycle lifec;

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
        if (IsNew)
        {
            MaxSize = (float)rand.NextDouble() * 0.8f + 0.5f;
            flowerstats.size = MaxSize;
            GetFlowerType();
            DrawPetal();
            //MakeInvertMesh(Vertices, Triangles);
            MakeRandomColor(Randomseed);
        }
        AudioRand = (float)rand.NextDouble();
        MakeMeshData(flowerstats.flowertype);
        SetColor();
    }

    public void GetFlowerStats (FlowerStats flowerstatz)
    {
        IsNew = false;
        flowerstats = flowerstatz;
    }

    void GetFlowerType()
    {
        var rand = new System.Random(Randomseed);
        double randnum = rand.NextDouble();
        if (randnum < 0.33)
        {
            flowerstats.flowertype = FlowerStats.FlowerType.triFlower;
        }
        else if (randnum >= 0.33f && randnum < 0.66f)
        {
            flowerstats.flowertype = FlowerStats.FlowerType.bulbFlower;
        }
        else if (randnum >= 0.66f)
        {
            flowerstats.flowertype = FlowerStats.FlowerType.roundFlower;
        }
    }

    void MakeMeshData(FlowerStats.FlowerType flowertype)
    {
        var rand = new System.Random(Randomseed);
        MoveZ = (float)(rand.NextDouble());
        float wideth = (float)rand.NextDouble() * 0.3f + 0.2f;
        if (flowertype == FlowerStats.FlowerType.triFlower)
        {
            Vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(0, 1 * YFactor, 0 - ZFactor) * Size, new Vector3(1 * XFactor, 1 * YFactor, -0.2f -ZFactor) * Size,
                new Vector3(0, 0, 0) * Size, new Vector3(0, 1 * YFactor, 0 - ZFactor) * Size, new Vector3(1 * XFactor, 1 * YFactor, -0.2f - ZFactor) * Size };
            Triangles = new int[] { 0, 1, 2, 3, 5, 4 };
        } else if (flowertype == FlowerStats.FlowerType.bulbFlower)
        {
            Vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size,
                new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size, new Vector3(0, 1 * YFactor, MoveZ - ZFactor) * Size,
                new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size,
                new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size, new Vector3(0, 1 * YFactor, MoveZ - ZFactor) * Size };
            Triangles = new int[] { 0, 1, 2, 2, 1, 3, 3, 5, 4, 4, 6, 3 };
        } else if (flowertype == FlowerStats.FlowerType.roundFlower)
        {
            Vertices = new Vector3[] { new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size, new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size,
                new Vector3(0, 0, 0) * Size, new Vector3(-wideth * XFactor, 0.5f * YFactor, 0 - ZFactor) * Size, new Vector3(wideth * XFactor, 0.5f * YFactor, -0.2f - ZFactor) * Size };
            Triangles = new int[] { 0, 1, 2, 3, 5, 4 };
        }
        //theflower.flowertype = flower;
    }

    void DrawPetal()
    {
        Mesh.Clear();
        Mesh.vertices = Vertices;
        Mesh.triangles = Triangles;
        Mesh.RecalculateNormals();
    }

    void MakeRandomColor(int randomseed)
    {
        var rand = new System.Random(randomseed);
        double randnum = rand.NextDouble();
        float whiteoffset = (float)rand.NextDouble() / 3;
        float blackoffset = (float)rand.NextDouble() / 3;
        //Debug.Log(randnum);
        if (randnum < 0.125f)
        {
            flowerstats.flowercolor = PrettyColors[0] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.125f && randnum < 0.25f)
        {
            flowerstats.flowercolor = PrettyColors[1] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.25f && randnum < 0.375f)
        {
            flowerstats.flowercolor = PrettyColors[2] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.375f && randnum < 0.5f)
        {
            flowerstats.flowercolor = PrettyColors[3] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.5f && randnum < 0.625f)
        {
            flowerstats.flowercolor = PrettyColors[4] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.625f && randnum < 0.75f)
        {
            flowerstats.flowercolor = PrettyColors[5] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.75f && randnum < 0.875f)
        {
            flowerstats.flowercolor = PrettyColors[6] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.875f)
        {
            flowerstats.flowercolor = PrettyColors[7] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
    }

    void SetColor()
    {
        Material PetalColor = new Material(PetalMaterial);
        Rendererer.material = PetalColor;
        PetalColor.color = flowerstats.flowercolor;
    }

    void MakeInvertMesh (Vector3[] vertices, int[] triangles)
    {
        int v = vertices.Length;
        int t = triangles.Length;
        Vector3[] normalz = Mesh.normals;
        //Debug.Log(v);
        //Debug.Log(t);
    }

    int GenerateSeedNum ()
    {
        return Random.Range(0, 3);
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
                ZFactor -= 0.1f * Time.deltaTime * ZFactor;
            Size = AudioEffector(AudioRand) * 3 + 1;
        }
        if (XFactor >= 1 && YFactor >= 1 && ZFactor <= 0.1)
            Lifespan -= Time.deltaTime;
        if (Lifespan < 0 && lifec == LifeCycle.flowering)
        {
            lifec = LifeCycle.fruiting;
            transform.parent.GetComponent<CenterPointScript>().SeedNum = GenerateSeedNum();
            transform.parent.GetComponent<CenterPointScript>().GetFlowerStats(flowerstats);
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
        if (lifec == LifeCycle.dying)
        {
            Debug.Log("ShrinkNDestroy");
            ShrinkNDestroy();
        }
        MakeMeshData(flowerstats.flowertype);
        DrawPetal();
        //Debug.Log(theflower);
	}

    public void ShrinkNDestroy()
    {
        Debug.Log("shrinkndestorying");
        //while (Size > 0.02f)
        //{
            Size -= 0.5f * Time.deltaTime;
        //}
        if (Size < 0.03f)
        {
            Destroy(gameObject);
        }
        //yield return new WaitForSeconds(0f);
    }

    float AudioEffector(float randnum)
    {
        float audiovalue = 0;
        if (randnum < 0.125f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[0];
        }
        else if (randnum >= 0.125f && randnum < 0.25f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[1];
        }
        else if (randnum >= 0.25f && randnum < 0.375f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[2];
        }
        else if (randnum >= 0.375f && randnum < 0.5f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[3];
        }
        else if (randnum >= 0.5f && randnum < 0.625f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[4];
        }
        else if (randnum >= 0.625f && randnum < 0.75f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[5];
        }
        else if (randnum >= 0.75f && randnum < 0.875f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[6];
        }
        else if (randnum >= 0.875f)
        {
            audiovalue = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioAnalyzer>().bandbuffer[7];
        }
        return audiovalue;
    }
}

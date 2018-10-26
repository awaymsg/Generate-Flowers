using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorollaGenerator : MonoBehaviour {

    [SerializeField] GameObject CenterPoint;
    [SerializeField] GameObject Petal;
    List<GameObject> Flowers = new List<GameObject>();
    public Color[] PrettyColors;
    bool StopGeneration;
    bool PositionOK;
    int PetalNum;

	// Use this for initialization
	void Start () {
        StopGeneration = false;
        StartCoroutine(GenerateCorolla(50));
	}

    IEnumerator GenerateCorolla(int corollanum)
    {
        int MaxFlower = 10;
        int i = 0;
        while (!StopGeneration)
        {
            PositionOK = false;
            PetalNum = Random.Range(4, 10);
            StartCoroutine(GeneratePetal(PetalNum, null, null));
            yield return new WaitForSeconds(0.3f);
            i++;
            if (i == MaxFlower)
            {
                StopGeneration = true;
            }
        }
    }

    public IEnumerator GeneratePetal(int petalnum, GameObject centerpoint, FlowerStats flower)
    {
        if (centerpoint == null)
        {
            Vector3 position = new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 9f), Random.Range(-2f, 5f));
            centerpoint = Instantiate(CenterPoint, position, Quaternion.identity);
            Flowers.Add(centerpoint);
            if (flower == null)
            {
                flower = CreateFlowerStats();
            }
            while (!PositionOK)
            {
                CheckFlowerPosition();
                Debug.Log(PositionOK);
            }
        }
        int rand = Random.Range(0, 5000);
        float anglestep = 360f / petalnum;
        float angle = 0;
        for (int i = 0; i < petalnum; i++)
        {
            GameObject petal = Instantiate(Petal, centerpoint.transform.position, Quaternion.Euler(0, 0, angle), centerpoint.transform);
            petal.GetComponent<PetalDrawer>().Randomseed = rand;
            angle += anglestep;
            if (flower != null)
            {
                if (centerpoint.GetComponent<AFlower>() == null)
                {
                    if (flower.flowertype == FlowerStats.FlowerType.triFlower)
                    {
                        centerpoint.AddComponent<TriFlower>();
                    } else if (flower.flowertype == FlowerStats.FlowerType.bulbFlower)
                    {
                        centerpoint.AddComponent<BulbFlower>();
                    } else if (flower.flowertype == FlowerStats.FlowerType.roundFlower)
                    {
                        centerpoint.AddComponent<RoundFlower>();
                    }
                }
                petal.GetComponent<PetalDrawer>().GetFlowerStats(flower);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    FlowerStats.FlowerType MakeFlowerType(float randnum)
    {
        if (randnum < 0.33)
        {
            return FlowerStats.FlowerType.triFlower;
        }
        else if (randnum >= 0.33f && randnum < 0.66f)
        {
            return FlowerStats.FlowerType.bulbFlower;
        }
        else
        {
            return FlowerStats.FlowerType.roundFlower;
        }
    }

    Color MakeColor(float randnum)
    {
        float whiteoffset = Random.value * 0.33f;
        float blackoffset = Random.value * 0.33f;
        randnum = Random.value;
        if (randnum < 0.125f)
        {
            return PrettyColors[0] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.125f && randnum < 0.25f)
        {
            return PrettyColors[1] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.25f && randnum < 0.375f)
        {
            return PrettyColors[2] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.375f && randnum < 0.5f)
        {
            return PrettyColors[3] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.5f && randnum < 0.625f)
        {
            return PrettyColors[4] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.625f && randnum < 0.75f)
        {
            return PrettyColors[5] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else if (randnum >= 0.75f && randnum < 0.875f)
        {
            return PrettyColors[6] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
        else
        {
            return PrettyColors[7] + Color.white * whiteoffset; //+ Color.black * blackoffset;
        }
    }

    FlowerStats CreateFlowerStats ()
    {
        FlowerStats flowerstatz = new FlowerStats();
        flowerstatz.flowertype = MakeFlowerType(Random.value);
        flowerstatz.flowercolor = MakeColor(Random.value);
        float MaxSize = Random.value * 0.8f + 0.5f;
        flowerstatz.size = MaxSize;
        return flowerstatz;
    }

    void CheckFlowerPosition()
    {
        //int positionchange = 0;
        PositionOK = false;
        Debug.Log(Flowers.Count);
        if (Flowers.Count > 1)
        {
            for (int i = 0; i < (Flowers.Count - 1); i++)
            {
                while (Vector3.Distance(Flowers[Flowers.Count - 1].transform.position, Flowers[i].transform.position) < 3f)
                {
                    Flowers[Flowers.Count - 1].transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 9f), Random.Range(-2f, 5f));
                }
            }
        }
        PositionOK = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGeneration = true;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorollaGenerator : MonoBehaviour {

    public GameObject CenterPoint;
    public GameObject Petal;
    List<GameObject> Flowers = new List<GameObject>();
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
        GameObject corolla = new GameObject();
        if (centerpoint == null)
        {
            Vector3 position = new Vector3(Random.Range(-5, 5), Random.Range(5, 9), Random.Range(-5, 5));
            corolla = Instantiate(CenterPoint, position, Quaternion.identity);
            Flowers.Add(corolla);
            while (!PositionOK)
            {
                CheckFlowerPosition();
                Debug.Log(PositionOK);
            }
        } else
        {
            corolla = centerpoint;
        }
        int rand = (int)(Random.value * 500);
        float anglestep = 360f / petalnum;
        float angle = 0;
        for (int i = 0; i < petalnum; i++)
        {
            GameObject petal = Instantiate(Petal, corolla.transform.position, Quaternion.Euler(0, 0, angle), corolla.transform);
            petal.GetComponent<PetalDrawer>().Randomseed = rand;
            angle += anglestep;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void CheckFlowerPosition()
    {
        int positionchange = 0;
        Debug.Log(Flowers.Count);
        if (Flowers.Count > 1)
        {
            PositionOK = false;
            for (int i = 0; i < (Flowers.Count - 1); i++)
            {
                if (Flowers[Flowers.Count - 1].transform.position.x - Flowers[i].transform.position.x < 1f && Flowers[Flowers.Count - 1].transform.position.x - Flowers[i].transform.position.x > -1f)
                {
                    positionchange++;
                }
                //if (Flowers[Flowers.Count - 1].transform.position.y - Flowers[i].transform.position.y < 1f && Flowers[Flowers.Count - 1].transform.position.y - Flowers[i].transform.position.y > -1f)
                //{
                //    positionchange++;
                //}
                //if (Flowers[Flowers.Count - 1].transform.position.z - Flowers[i].transform.position.z < 1f && Flowers[Flowers.Count - 1].transform.position.z - Flowers[i].transform.position.z > -1f)
                //{
                //    positionchange++;
                //}
            }
        }
        if (positionchange == 0)
        {
            PositionOK = true;
        }
        else
        {
            Flowers[Flowers.Count-1].transform.position = new Vector3(Random.Range(-8, 8), Random.Range(6, 8), Random.Range(-5, 5));
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGeneration = true;
        }
	}
}

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
        if (centerpoint == null)
        {
            Vector3 position = new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 9f), Random.Range(-2f, 5f));
            centerpoint = Instantiate(CenterPoint, position, Quaternion.identity);
            Flowers.Add(centerpoint);
            while (!PositionOK)
            {
                CheckFlowerPosition();
                Debug.Log(PositionOK);
            }
        }
        int rand = (int)(Random.value * 500);
        float anglestep = 360f / petalnum;
        float angle = 0;
        for (int i = 0; i < petalnum; i++)
        {
            GameObject petal = Instantiate(Petal, centerpoint.transform.position, Quaternion.Euler(0, 0, angle), centerpoint.transform);
            petal.GetComponent<PetalDrawer>().Randomseed = rand;
            angle += anglestep;
            yield return new WaitForSeconds(0.05f);
        }
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

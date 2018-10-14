using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorollaGenerator : MonoBehaviour {

    public GameObject CenterPoint;
    public GameObject Petal;
    int PetalNum;

	// Use this for initialization
	void Start () {
        StartCoroutine(GenerateCorolla(50));
	}

    IEnumerator GenerateCorolla(int corollanum)
    {
        for (int i = 0; i < corollanum; i++)
        {
            PetalNum = Mathf.RoundToInt(Random.value * 10 + 3);
            StartCoroutine(GeneratePetal(PetalNum));
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator GeneratePetal(int petalnum)
    {
        Vector3 position = new Vector3(Random.Range(-10, 10), Random.Range(1, 10), Random.Range(-10, 10));
        GameObject corolla = Instantiate(CenterPoint, position, Quaternion.identity);
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
	
	// Update is called once per frame
	void Update () {
		
	}
}

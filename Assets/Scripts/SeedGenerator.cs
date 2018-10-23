using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour {
    [SerializeField] GameObject Seed;

    // Use this for initialization
    public void GenerateSeed(GameObject centerpoint, FlowerStats flowerstatz, int seednum)
    {
        if (seednum > 0)
        {
            GameObject seed = Instantiate(Seed, centerpoint.transform.position, Quaternion.identity, centerpoint.transform);
            seed.GetComponent<SeedScript>().GetSeedParentStats(flowerstatz);
            Debug.Log(seednum);
            if (seednum > 1)
            {
                for (int i = 1; i < seednum; i++)
                {
                    GameObject newflower = Instantiate(centerpoint, centerpoint.transform.position, Quaternion.identity);
                    for (int j = newflower.transform.childCount - 1; j >= 0; j--)
                    {
                        Destroy(newflower.transform.GetChild(j).gameObject);
                    }
                    seed = Instantiate(Seed, newflower.transform.position, Quaternion.identity, newflower.transform);
                    seed.GetComponent<SeedScript>().GetSeedParentStats(flowerstatz);
                }
            }
        } else
        {
            PetalDrawer[] petals;
            petals = centerpoint.GetComponentsInChildren<PetalDrawer>();
            foreach (PetalDrawer petal in petals)
            {
                //Debug.Log("trying to call petaldrawer");
                if (petal != null)
                {
                    petal.lifec = PetalDrawer.LifeCycle.dying;
                }
            }
        }
    }

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

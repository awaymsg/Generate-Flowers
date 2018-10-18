using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour {
    public GameObject Seed;

    // Use this for initialization
    public void GenerateSeed(Transform centerpoint, FlowerStats flowerstatz)
    {
        GameObject seed = Instantiate(Seed, centerpoint.position, Quaternion.identity, centerpoint);
        seed.GetComponent<SeedScript>().GetSeedParentStats(flowerstatz);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour {
    float Size;
    Color FlowerColor;
    Rigidbody ParentBody;
    bool SeedDispersed;
    FlowerStats flowerstats = new FlowerStats();
    // Use this for initialization
    private void Awake()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        SeedDispersed = false;
        ParentBody = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    void Start () {
        //Debug.Log(Size);
        Size = flowerstats.size * 0.25f;
        //Debug.Log(flowerstats.flowercolor);
    }

    public void GetSeedParentStats(FlowerStats flowerstatz)
    {
        flowerstats = flowerstatz;
        //Debug.Log(flower);
    }
	
	// Update is called once per frame
	void Update () {
        GrowSeed();
	}

    void GrowSeed()
    {
        if (transform.localScale.x < Size)
        {
            transform.localScale += new Vector3(1, 1, 1) * 0.05f * Time.deltaTime;
        }
        else
        {
            if (!SeedDispersed)
            {
                DisperseSeed();
                SeedDispersed = true;
            }
        }
    }
    
    void DisperseSeed()
    {
        ParentBody.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 5f);
        ParentBody.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 0.25f);
    }
}

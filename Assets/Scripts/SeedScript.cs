using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour {
    float Size;
    float DormantTime;
    Color FlowerColor;
    Rigidbody ParentBody;
    bool SeedDispersed;
    bool GrowNew;
    FlowerStats flowerstats = new FlowerStats();

    // Use this for initialization
    private void Awake()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        SeedDispersed = false;
        GrowNew = false;
        ParentBody = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    void Start () {
        //Debug.Log(Size);
        Size = flowerstats.size * 0.25f;
        DormantTime = Random.Range(8f, 15f);
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
        DormantTime -= Time.deltaTime;
        if (DormantTime < 0 && !GrowNew)
        {
            PetalDrawer[] petals;
            petals = transform.parent.gameObject.GetComponentsInChildren<PetalDrawer>();
            foreach (PetalDrawer petal in petals)
            {
                //Debug.Log("trying to call petaldrawer");
                if (petal != null)
                {
                    StartCoroutine(petal.ShrinkNDestroy());
                }
            }
            int PetalNum = Random.Range(4, 10);
            Debug.Log(PetalNum + " " + gameObject.name);
            StartCoroutine(GameObject.FindGameObjectWithTag("CorollaGenerator").GetComponent<CorollaGenerator>().GeneratePetal(PetalNum, transform.parent.gameObject, flowerstats));
            GrowNew = true;
        }
        if (GrowNew)
            ShrinkSeed();
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

    void ShrinkSeed()
    {
        transform.parent.gameObject.GetComponent<CenterPointScript>().IsFruiting = false;
        transform.localScale -= new Vector3(1, 1, 1) * 0.2f * Time.deltaTime;
        if (transform.localScale.x < 0.03f)
        {
            transform.parent.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //transform.parent.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Destroy(gameObject);
        }
    }
    
    void DisperseSeed()
    {
        ParentBody.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 5f);
        ParentBody.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 0.25f);
    }
}

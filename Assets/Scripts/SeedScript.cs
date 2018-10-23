using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        CheckPosition();
        if (ParentBody.velocity.magnitude > 2f)
        {
            ParentBody.velocity = ParentBody.velocity * 0.9f;
        }
        if (DormantTime < 2 && !GrowNew)
        {
            KillPetals();
            if (DormantTime < 0)
            {
                int PetalNum = Random.Range(4, 10);
                Debug.Log(PetalNum + " " + gameObject.name);
                StartCoroutine(GameObject.FindGameObjectWithTag("CorollaGenerator").GetComponent<CorollaGenerator>().GeneratePetal(PetalNum, transform.parent.gameObject, flowerstats));
                GrowNew = true;
            }
        }
        if (GrowNew)
            ShrinkSeed();
	}

    void KillPetals()
    {
        PetalDrawer[] petals;
        petals = transform.parent.gameObject.GetComponentsInChildren<PetalDrawer>();
        foreach (PetalDrawer petal in petals)
        {
            //Debug.Log("trying to call petaldrawer");
            if (petal != null)
            {
                petal.lifec = PetalDrawer.LifeCycle.dying;
            }
        }
    }

    void CheckPosition()
    {
        GameObject[] flowers = GameObject.FindGameObjectsWithTag("Centerpoint");
        List<GameObject> flowerlist = flowers.ToList();
        flowerlist.Remove(gameObject);
        foreach (GameObject flower in flowerlist)
        {
            if (Vector3.Distance(transform.parent.position, flower.transform.position) < 3f)
            {
                ParentBody.AddForce((transform.parent.position - flower.transform.position) * Time.deltaTime);
            }
        }
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
            ParentBody.velocity = Vector3.zero;
            ParentBody.angularVelocity = Vector3.zero;
            Destroy(gameObject);
        }
    }
    
    void DisperseSeed()
    {
        ParentBody.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 5f);
        ParentBody.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 0.25f);
    }
}

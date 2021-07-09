using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProducerScript : MonoBehaviour
{

    public string art;
    public string searchFor;
    private int needWood = 5;
    private int treeNumber;
    public bool hasJobOffer;
    public bool hasWorker;
    public WorkerScript worker;
    List<RessourcesScript> ressourcesList = new List<RessourcesScript>();
    


    // Start is called before the first frame update
    void Start()
    {
        ressourcesList.AddRange(FindObjectsOfType<RessourcesScript>());
    }

    // Update is called once per frame
    void Update()
    {
        sequence();
    }

    public bool checkIfHasJob()
    {
        if(needWood > 0)
        {
            hasJobOffer = true;
            return true;
        }
        return false;
    }

    public void cutTree()
    {       
        Vector3 vector = (ressourcesList[treeNumber].transform.position - worker.transform.position).normalized;
        worker.goToAim(vector);
    }

    public void goBack()
    {
        Vector3 vector = (transform.position - worker.transform.position).normalized;
       worker.goToAim(vector);

    }


    public bool findMyTarget()
    {
     
        for(int i = 0;i< ressourcesList.Count;i++)
        {
            if (worker.job == "woodcutter" && ressourcesList[i] != null && ressourcesList[i].art == "tree")
            {
                 treeNumber = i;
                 return true;
            }
            if (worker.job == "stonecutter" && ressourcesList[i] != null && ressourcesList[i].art == "stone")
            {
                treeNumber = i;
                return true;
            }
        }
        return false;
    }

    public void sequence()
    {

        if (checkIfHasJob()) { 
        if(findMyTarget() && worker.inventory == 0)
            {
                cutTree();
            }
            else if(worker.inventory > 0)
            {
                goBack();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Worker" && worker.inventory > 0)
        {
            worker.inventory--;
            needWood--;
        }
    }

    public void convertWorker()
    {
        if(gameObject.name == "woodcutter")
        {
            worker.job = "woodcutter";
        }
        if(gameObject.name == "mine")
        {
            worker.job = "miner";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Producer : MonoBehaviour
{
    public List<Ressources> ressourceList;
    public int listID;
    private int gatheredRes;
    public JobCreator myJobCreator;
    public Worker myWorker;
    public Ressources myRessource;

    public int hasRessources;
    public bool hasRess;
    public int reservedRessources;
    public int openRessources;

    private bool needWorker = true;
    private bool hasJob = true;
    public float distance;

    private Storage myStorage;
    public GameObject myRes;

    public bool search = false;
    public string art = "Forester";

    
    // Start is called before the first frame update
    void Start()
    {

        if(art == "Forester")
        {
            myJobCreator = FindObjectOfType<JobCreator>();
            myStorage = GetComponentInChildren<Storage>();
            checkRessourcesInRange();
        }
        myJobCreator.addToProducerList(this);
    }



    void Update()
    {
        if(openRessources > 0)
        {
            hasRess = true;
        }
        work();
        if(ressourceList.Count == 0)
        {
            checkRessourcesInRange();
        }
        if(needWorker)
        {
            searchForWorker();
        }
    }



    void gotoTree()
    {
        while(hasJob)
        { 
        distance = Vector3.Distance(myRessource.transform.position, myWorker.transform.position);
        }
        if (distance < 0.3f)
        {
            Debug.Log("Kill tree!");
            Destroy(myRessource);
            hasJob = false;
        }
    }

    void searchForWorker()
    {
        for(int i=0;i< myJobCreator.freeWorkerList.Count;i++)
        {
            if(!myJobCreator.freeWorkerList[i].hasJobinBuilding && !myJobCreator.freeWorkerList[i].hasAnotherJob)
            {
                myWorker = myJobCreator.freeWorkerList[i];
                myWorker.hasJobinBuilding = true;
                needWorker = false;
                break;
            }
        }
    }

    void searchForRessources()
    {
        for (int i = 0; i < ressourceList.Count; i++)
        {
            myRessource = ressourceList[i];
            listID = i;
            break;
        }
    }

    void goToAim()
    {
        if(myRessource!=null && myWorker.inventory == 0)
        {
            myWorker.goToTarget(myRessource.transform.position);
            if (Vector3.Distance(myRessource.transform.position, myWorker.transform.position) < 0.6f)
            {
                myRessource.treeFall();
                ressourceList.RemoveAt(listID);
                myWorker.inventory++;
                myRessource = null;
            }
        }
        if(myWorker.inventory > 0)
        {
            myWorker.goToTarget(transform.position);
            if (Vector3.Distance(myWorker.transform.position, transform.position) < 1.4f)
            {
                myWorker.inventory--;
                hasRessources++;
                openRessources++;
                //myStorage.storeRes();
                searchForRessources();
            }
        }
    }

    void work()
    {
        if (myWorker == null)
        {
            searchForWorker();
        }
        if(myRessource == null)
        {
            searchForRessources();
        }
        goToAim();
    }

    void checkRessourcesInRange()
    {

        List<Ressources> ressList = new List<Ressources>();
        ressList.AddRange(FindObjectsOfType<Ressources>());
        Debug.Log(ressList.Count);
        foreach (Ressources res in ressList )
        {
            if(Vector3.Distance(res.gameObject.transform.position,transform.position)<5f)
            {
                ressourceList.Add(res);
            }
        }
        ressList.Clear();

        search = false;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobCreator : MonoBehaviour
{

    //1.Find Building with a Job to do // Find free Worker // Find Ressources
    // Start is called before the first frame update
    public List<Building> buildinglist;
    public Building myBuilding;
    public List<Producer> producerList;
    public Producer myProducer;
    public List<Worker> freeWorkerList;
    public Worker myWorker;
    public bool hasFreeWorker = false;
    private bool foundWorker = false;

    public List<OrderScript> myOrders;
    private bool hasOrders;




    void Update()
    {
        orderCheck();
        createJob();
    }

    void orderCheck()
    {
        if(myOrders.Count > 0)
        {
            hasOrders = true;
        }else
        {
            hasOrders = false;
        }
    }

    void createJob()
    {
        if(hasOrders)
        {
            for (int j = 0; j < myOrders.Count; j++)
            {
                if(myOrders[j].needMaterial>0)
                { 
                for (int i = 0; i < producerList.Count; i++)
                {
                        if (producerList[i].hasRess && hasFreeWorker) 
                        {
                            myWorker = null;

                            if(hasFreeWorker)
                            {
                                findWorker();
                                Debug.Log("creating jobs" + myWorker.name + producerList[i].name);
                                myWorker.setJob(producerList[i], myOrders[j].building);
                                producerList[i].reservedRessources++;
                                producerList[i].openRessources--;
                                myOrders[j].needMaterial--;
                                myOrders[j].building.orderedRessources++;
                                break;
                                
                            }
                        }

                    }
                }
            }
        }

    }


    void findWorker()
    {
        for(int i = 0;i< freeWorkerList.Count;i++)
        {
            if(!freeWorkerList[i].hasJobinBuilding && !freeWorkerList[i].hasAnotherJob)
            {
                myWorker = freeWorkerList[i];
                Debug.Log("Found worker!");
                foundWorker = true;
                break;
            }
        }
    }

    public void addToProducerList(Producer _producer)
    {
        producerList.Add(_producer);
    }

    public void addtoWorkerList(Worker _worker)
    {
        freeWorkerList.Add(_worker);
    }
}

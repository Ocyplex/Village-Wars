using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Worker : MonoBehaviour
{

    public bool hasJobinBuilding = false;
    public bool hasAnotherJob = false;
    public JobCreator myJobCreator;
    public NavMeshAgent agent;
    public int inventory;
    public Producer myProducer;
    public Building myBuilding;


    void Start()
    {

        myJobCreator = FindObjectOfType<JobCreator>();
        agent = GetComponent<NavMeshAgent>();
        myJobCreator.addtoWorkerList(this);
    }

    private void Update()
    {   
        if(hasAnotherJob)
        {
            pickUpRes(myProducer,myBuilding);
        }
        giveStatus();
        
    }


    void addToWorkerList()
    {
        myJobCreator.freeWorkerList.Add(this);
    }

    public void goToTarget(Vector3 pos)
    {
        agent.SetDestination(pos);
    }

    void pickUpRes(Producer pickUpPoint,Building targetPoint)
    {
        if(inventory<1)
        {
            agent.SetDestination(pickUpPoint.transform.position);
            if (Vector3.Distance(pickUpPoint.transform.position, transform.position)<1.3f)
            {
                myProducer.hasRessources--;
                myProducer.reservedRessources--;
                inventory++;
            }
        }
        if(inventory>0)
        {
            agent.SetDestination(targetPoint.transform.position);
            if (Vector3.Distance(targetPoint.transform.position, transform.position) < 1.3f)
            {
                inventory--;
                targetPoint.hasRessources++;
                Debug.Log("Brought ressource!");
                hasAnotherJob = false;
                forgetJob();
            }
        }
    }

    public void setJob(Producer _myProducer, Building _myBuilding)
    {
        myBuilding = _myBuilding;
        myProducer = _myProducer;
        hasAnotherJob = true;
    }

    void forgetJob()
    {
        myBuilding = null;
        myProducer = null;
    }

    void giveStatus()
    {
        if(!hasAnotherJob && !hasJobinBuilding)
        {
            myJobCreator.hasFreeWorker = true;
        }
    }

}

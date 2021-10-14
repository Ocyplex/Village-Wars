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
    public GameMaster gm;
    public RessourcesScript[] ressourcesArray;
    public bool ressourceListIsFull;
    

    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        ressourcesArray = new RessourcesScript[5];
        
    }

    void Update()
    {
        sequence();
        if (!checkIfListIsFull())
        {
            fillRessourcesArray();
        }
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
        Vector3 vector = (ressourcesArray[treeNumber].transform.position - worker.transform.position).normalized;
        worker.goToAim(vector, ressourcesArray[treeNumber]);
    }

    public void goBack()
    {
        Vector3 vector = (transform.position - worker.transform.position).normalized;
       worker.goToAim(vector,null);

    }


    public bool findMyTarget()
    {
     
        for(int i = 0;i<ressourcesArray.Length;i++)
        {
            if (worker.job == "woodcutter" && ressourcesArray[i] != null && ressourcesArray[i].art == "tree")
            {
                 treeNumber = i;
                 return true;
            }
            if (worker.job == "stonecutter" && ressourcesArray[i] != null && ressourcesArray[i].art == "stone")
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

    public void fillRessourcesArray()
    {
        
        for(int i = 0; i <  ressourcesArray.Length; i++)
        {
            while(ressourcesArray[i] != null)
            {
            i++;
            }
            Debug.Log("Jo");
            for(int j = 0; j < gm.allRessources.Count ; j++)
            { 
            if(!gm.allRessources[j].isInList && gm.allRessources[j].art == searchFor)
                {

                    ressourcesArray[i] = gm.allRessources[j];
                    ressourcesArray[i].isInList = true;
                    gm.allRessources.RemoveAt(j);
                    Debug.Log("Removed from GM!");
                    break;
                }
            }
        }
    }

    public bool checkIfListIsFull()
    {
        if(ressourcesArray[0] != null && ressourcesArray[1] != null && ressourcesArray[2] != null && ressourcesArray[3] != null && ressourcesArray[4] != null)
        {
            return true;
        }else
        {
            return false;
        }
    }
}

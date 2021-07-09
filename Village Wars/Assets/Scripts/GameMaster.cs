using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    
    List<BuildingProducerScript> allBuildings = new List<BuildingProducerScript>();
    List<WorkerScript> allWorker = new List<WorkerScript>();

    // Start is called before the first frame update
    private void Awake()
    {
        allBuildings.AddRange(FindObjectsOfType<BuildingProducerScript>());
        allWorker.AddRange(FindObjectsOfType<WorkerScript>());
    }

    void Start()
    {
        allBuildings.AddRange(FindObjectsOfType<BuildingProducerScript>());
        allWorker.AddRange(FindObjectsOfType<WorkerScript>());
    }

    // Update is called once per frame
    void Update()
    {
        assignWork();
    }

    public void assignWork()
    {
        for(int i = 0; i < allBuildings.Count; i++)
        {

            if (allBuildings[i].hasJobOffer && !allBuildings[i].hasWorker)
            {
                for (int j = 0; j < allWorker.Count; j++)
                {
                    if(allWorker[j].hasjob==false)
                    { 
                        allWorker[j].takeJob(allBuildings[i]);                       
                        break;
                    }
                       
                }
            }
           
        }
    }

}

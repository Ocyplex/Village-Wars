using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerScript : MonoBehaviour
{


    public float speed;
    public bool hasjob = false;
    public BuildingProducerScript Workplace;
    private RessourcesScript myItem;
    public int inventory;
    public string job;
    public string searchFor;


    void Start()
    {
        speed = 5f;
    }

    void Update()
    {

    }


    public void checkIfHasJob()
    {
        if (Workplace != null)
        {
            hasjob = true;
        }
    }

    public void goToAim(Vector3 AimVektor, RessourcesScript myItem)
    {
        transform.Translate(AimVektor * speed * Time.deltaTime);
        this.myItem = myItem;
    }

    private void OnCollisionEnter(Collision collision)
    {     
        if (collision.gameObject.GetComponent<RessourcesScript>().art == searchFor && inventory == 0 && collision.gameObject.GetComponent<RessourcesScript>() == myItem)
        {
            //collision.gameObject.GetComponent<RessourcesScript>().gm.cleanLists();
            Destroy(collision.gameObject);
            inventory++;
        }
    }

    public void takeJob(BuildingProducerScript building)
    {
        this.Workplace = building;
        this.job = building.art;
        building.hasWorker = true;
        building.worker = this;
        searchFor = building.searchFor;
        hasjob = true;
    }

}

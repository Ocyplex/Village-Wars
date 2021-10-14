using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string art;
    public bool hasneed;

    public int hasRessources;
    public int needRessources;

    public int orderedRessources;

    private OrderScript myOrder;
    public JobCreator myJobCreator;
    public bool orderNow = false;


    // Start is called before the first frame update
    void Start()
    {
        myOrder = FindObjectOfType<OrderScript>();
        myJobCreator = FindObjectOfType<JobCreator>();
        addBuildingtoList();
    }

    // Update is called once per frame
    void Update()
    {

        if(orderNow)
        {
            createTest(needRessources);
            orderNow = false;
        }
    }


    void addBuildingtoList()
    {
        myJobCreator.buildinglist.Add(this);
    }


    public void createTest(int _needRessources)
    {
        myOrder.createOrder(this, _needRessources,"stone");
        Debug.Log("Building Creates Order");
        needRessources = 0;
    }
}

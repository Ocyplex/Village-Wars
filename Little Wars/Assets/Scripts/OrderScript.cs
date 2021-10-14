using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderScript : MonoBehaviour
{
    public JobCreator jobCreator;
    public Building building;
    public int needMaterial;
    public string art;

    private void Start()
    {
        jobCreator = GetComponent<JobCreator>();
    }

    public void createOrder(Building _building, int _needMaterial, string _art)
    {
        building = _building;
        needMaterial = _needMaterial;
        art = _art;

        jobCreator.myOrders.Add(this);
        Debug.Log(_building.name + " order " + _needMaterial + "ressources");
    }
}

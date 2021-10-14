using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BuildScript : MonoBehaviour
{


    public Button pathButton;
    public Button buildingButton;

    public GameObject path;
    public GameObject myObject;
    private float MyY;
    private RaycastHit myHit;
    public GameObject building;
    private Camera cam;
    private LvlCreator lvlCreator;
    public NavMeshAgent agent;

    private void Start()
    {
        if (cam = FindObjectOfType<Camera>())
        {
            Debug.Log("Found camera!");
        }
        lvlCreator = FindObjectOfType<LvlCreator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
               BuildObject();
        }

        if(Input.GetMouseButtonDown(0))
        {
            GoToPoint();
        }
    }

    void BuildObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(!hit.transform.gameObject.GetComponent<UsedField>().isUsed)
            { 
                Instantiate(myObject, new Vector3(hit.transform.position.x, hit.transform.position.y + MyY, hit.transform.position.z), Quaternion.identity);
                lvlCreator.buildSurface();
            }
        }

    }

    public void UsePath()
    {

        myObject = path;
        MyY = 0.55f;
    }
    public void UseBuilding()
    {
        myObject = building;
        MyY = 1.50f;
    }

    void GoToPoint()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}

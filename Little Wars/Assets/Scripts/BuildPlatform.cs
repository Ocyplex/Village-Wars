using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlatform : MonoBehaviour
{
    public GameObject myGo;


    public Vector3[] myPillars;
    private int pillarCount = 4;
    private int nearest;

    public Player testPlayer;

    private void Start()
    {
        testPlayer = FindObjectOfType<Player>();
        createPillarPos(); 
    }


    public void detectPosition(Player _player, RaycastHit hit, Pillar _myPillar)
    {
        float next;
        next = Vector3.Distance(myPillars[0], hit.point);
        nearest = 0;
        for (int i = 0; i < pillarCount; i++)
        {
            if (Vector3.Distance(myPillars[i], hit.point) < next)
            {
                nearest = i;
                next = Vector3.Distance(myPillars[i], hit.point);
                Debug.Log("nearest is " + nearest);
            }
            if (i == pillarCount-1)
            {           
                if (!checkCollide(nearest))
                {
                    Instantiate(_myPillar, myPillars[nearest], Quaternion.identity);
                }
            }
        }
    }

    public bool checkCollide(int _nearest)
    {
        RaycastHit hits;
        float distanceTest = 0.71f;
        Vector3 test = new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z);        //Create point in the middle of platform
        Vector3 dir = test - myPillars[_nearest];                                                               //Direction (Midplatform to pillar)
        Debug.DrawRay(test, -dir, Color.blue,4f);
        if (Physics.Raycast(test, -dir, out hits,distanceTest))
        {
            Debug.Log("Place is used by " + hits.transform.gameObject.name);

            //testPlayer.testRessource = hits.transform.GetComponent<Ressources>();
            return true;
        }
        else
        {
            Debug.Log("Creating Object");
            return false;
        }
    }


    private void createPillarPos()
    {
        myPillars = new Vector3[pillarCount];
        myPillars[0] = new Vector3(transform.position.x - 0.5f, transform.position.y+ 0.5f, transform.position.z + 0.5f);
        myPillars[1] = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z + 0.5f);
        myPillars[2] = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z - 0.5f);
        myPillars[3] = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, transform.position.z - 0.5f);
        //spawn();
    }
    //only for test
    private void spawn()
    {
        for (int i = 0; i < pillarCount; i++)
        {
            Instantiate(myGo, myPillars[i], Quaternion.identity);
        }
    }
}

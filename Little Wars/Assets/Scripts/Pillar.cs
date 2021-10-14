using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{

    public Wall[] myWalls;
    private Vector3[] wallVec;
    private int wallCount = 4;
    private int nearest;

    private void Start()
    {
        wallPos();
    }

    public void testPostion(RaycastHit hit_, Wall wall_)
    {
        float next;
        next = Vector3.Distance(wallVec[0], hit_.point);
        nearest = 0;
        for (int i = 0; i < wallCount; i++)
        {
            if (Vector3.Distance(wallVec[i], hit_.point) < next)
            {
                nearest = i;
                next = Vector3.Distance(wallVec[i], hit_.point);
                Debug.Log("nearest wall is " + nearest);
            }
            if (i == wallCount - 1 && !checkWallCollide(wallVec[nearest]))
            {

                if(nearest == 0 || nearest == 2)
                {
                    Instantiate(wall_, wallVec[nearest], Quaternion.Euler(0f, 90f, 0f));
                }
                else
                {
                    Instantiate(wall_, wallVec[nearest], Quaternion.identity);
                }
            }
        }
    }

    public void wallPos()
    {
        wallVec = new Vector3[wallCount];
        wallVec[0] = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        wallVec[1] = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        wallVec[2] = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        wallVec[3] = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
    }

    bool checkWallCollide(Vector3 wallVec_)
    {
        RaycastHit hits;
        float distanceTest = 0.2f;
        Vector3 testVec = new Vector3(wallVec_.x + 0.1f, wallVec_.y, wallVec_.z + 0.1f);
        Vector3 dir = testVec - wallVec_;
        Debug.DrawRay(testVec, -dir, Color.blue, 4f);
        if (Physics.Raycast(testVec, -dir, out hits, distanceTest))
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

}

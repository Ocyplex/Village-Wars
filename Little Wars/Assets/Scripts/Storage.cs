using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private GameObject myRes;
    private int space = 9;

    private void Start()
    {
        myRes = GetComponentInParent<Producer>().myRes;
    }

    public void storeRes()
    {
        for (int i = GetComponentInParent<Producer>().hasRessources; i < space; i++)
        {
            Instantiate(myRes, new Vector3(transform.position.x + (0.7f * GetComponentInParent<Producer>().hasRessources), transform.position.y,transform.position.z), Quaternion.identity);
            break;
        }
        
    }

    void deleteRes()
    {

    }
}

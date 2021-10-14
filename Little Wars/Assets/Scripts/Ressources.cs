using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{

    public int id;
    private Rigidbody myRb;


    // Start is called before the first frame update
    void Start()
    {
        id = 0;
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void treeFall()
    {
        Debug.Log("Tree fall");
        myRb.useGravity = true;
        myRb.isKinematic = false;
        Destroy(this.gameObject, 2);
    }
}

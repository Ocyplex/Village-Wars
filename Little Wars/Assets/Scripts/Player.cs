using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController myController;
    private float speed = 7f;

    private bool buildMode = false;
    private int b;
    public BuildPlatform buildPlatform;
    public Pillar myPillar;
    public Wall myWall;
    public UsedField myUsedField;
    public Camera myCam;
    public Ressources testRessource;

    private UIScript myUI;


    void Start()
    {
        myController = FindObjectOfType<CharacterController>();
        myUI = FindObjectOfType<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        myController.Move(move * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.B))
        {
            b++;
            if(b==1)
            {
                buildMode = true;
                myUI.activeBuild(buildMode);
            }
            if(b==2)
            {
                buildMode = false;
                myUI.activeBuild(buildMode);
                b = 0;
            }
        }


        if (buildMode && Input.GetButtonDown("Fire1"))
        { 
                RaycastHit hit;
                Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(myCam.transform.position, ray.direction, out hit);
                Debug.DrawRay(myCam.transform.position, ray.direction * 10, Color.red, 5f);

                Debug.Log("My hit object" + hit.transform.gameObject.name);

                if (hit.transform.gameObject.name == "WoodPlatform(Clone)")
                {
                    Debug.Log("Try to build Pillar");
                    buildPlatform = hit.transform.GetComponent<BuildPlatform>();
                    buildPlatform.detectPosition(this, hit, myPillar);
                }

                if (hit.transform.gameObject.name == "Pillar1(Clone)")
                {
                    Debug.Log("Try to build Wall");
                    myPillar = hit.transform.GetComponent<Pillar>();
                    myPillar.testPostion(hit, myWall);
                }

                if(!hit.transform.GetComponent<UsedField>().isUsed)
                {
                    Debug.Log("Try to build Platform");
                    myUsedField = hit.transform.GetComponent<UsedField>();
                    myUsedField.createPlatform(buildPlatform);
                }
        }
        if (buildMode && Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(myCam.transform.position, ray.direction, out hit);
            Debug.DrawRay(myCam.transform.position, ray.direction * 10, Color.red, 5f);
            Destroy(hit.transform.gameObject);
        }
    }




    void build()
    {

    }


}

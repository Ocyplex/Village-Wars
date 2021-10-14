using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LvlCreator : MonoBehaviour
{
    public GameObject[] grasGround = new GameObject[2];
    public GameObject[] stoneGround = new GameObject[2];
    public GameObject[] clayGround = new GameObject[2];


    public GameObject stone;
    public GameObject tree;

    private int sizeX = 10;
    private int sizeY = 10;
    private int rand;
    private int sizeMap = 20;

    public NavMeshSurface surface;

    public Canvas canvas;

    void Start()
    {
        createMap();
        canvas.gameObject.active = true;
    }


    void createMap()
    {
        int x = 0;
        int y = 0;
        for (int i = 0; i < sizeMap; i += 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, i);
            for (int j = 0; j < sizeMap; j+=10)
            {
                transform.position = new Vector3(j, transform.position.y, transform.position.z);

                rand = Random.Range(0, 10);
                if (rand <= 2)
                {
                    createStoneTerrain();
                }
                else if(rand >= 3 && rand < 9)
                {
                    createForestTerrain();
                }
                else if(rand == 9)
                {
                    createClayField();
                }
                x = x + 10;
            }
        }
    }

    public void buildSurface()
    {
        surface.BuildNavMesh();
    }

    public void createStoneTerrain()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                rand = Random.Range(0, 3);
                Instantiate(stoneGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                rand = Random.Range(0, 5);
                if(rand < 1)
                {
                    Instantiate(stone, new Vector3(transform.position.x + i, transform.position.y + 0.75f, transform.position.z + j), Quaternion.identity);
                }
            }
        }
    }


    public void createForestTerrain()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                rand = Random.Range(0, 2);
                Instantiate(grasGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                rand = Random.Range(0, 5);
                if (rand < 1)
                {
                    Instantiate(tree, new Vector3(transform.position.x + i, transform.position.y + 0.75f, transform.position.z + j), Quaternion.identity);
                }
            }
        }
    }
    public void createClayField()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                rand = Random.Range(0, 10);
                if (rand < 3)
                {
                    Instantiate(clayGround[0], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                }
                else
                {
                    Instantiate(clayGround[1], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                    rand = Random.Range(0, 5);
                    if (rand == 0)
                    {
                        Instantiate(tree, new Vector3(transform.position.x + i, transform.position.y + 0.75f, transform.position.z + j), Quaternion.identity);
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedField : MonoBehaviour
{
    public bool isUsed = false;
    public bool nearBuilding = false;

    public void createPlatform(BuildPlatform buildPlatform_)
    {
        Instantiate(buildPlatform_, new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
        isUsed = true;
    }
}

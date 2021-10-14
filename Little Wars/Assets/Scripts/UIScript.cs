using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour
{

    private Text buildMode;

    void Start()
    {
        buildMode = FindObjectOfType<Text>();
        buildMode.text = "BuildMode: disabled";
    }

    public void activeBuild(bool status)
    {
        if(status)
        {
            buildMode.text = "BuildMode: active";
        }
        else
        {
            buildMode.text = "BuildMode: disabled";
        }
    }

}

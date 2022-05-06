using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColour : MonoBehaviour
{
    public Material purple, blue, green;
    MeshRenderer meshrend;
    ColourChange colourScript;
    GameObject colorchangeOBJ;
    void Start()
    {
        meshrend = GetComponent<MeshRenderer>();
        colorchangeOBJ = GameObject.Find("ColourManager");
        colourScript = colorchangeOBJ.GetComponent<ColourChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colourScript.colourNumber == 1)
        {
            meshrend.material = blue;
        }
        else if (colourScript.colourNumber == 2)
        {
            meshrend.material = purple;
        }
        else if (colourScript.colourNumber == 3)
        {
            meshrend.material = green;
        }
    }
}

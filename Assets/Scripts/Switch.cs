using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Switch : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        if(Input.GetKey("f"))
        {
            SceneManager.LoadScene(sceneID);
        }
        
    }
}
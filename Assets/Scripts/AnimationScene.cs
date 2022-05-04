using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScene : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene2");
    }
}
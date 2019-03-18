using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadTheScene", 2f);
    }

    public void LoadAScene(string scenename)
    {
        SceneManager.LoadScene("fitness");
    }

    void LoadTheScene()
    {
        LoadAScene("fitness");
    }
}

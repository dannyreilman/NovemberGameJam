using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {
    private bool load = false;
    public int sceneToLoad;

    void Update()
    {
        this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(!load)
        {
            load = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

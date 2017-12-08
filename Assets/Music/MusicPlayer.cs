using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private bool started = false;

    public AudioSource battleTheme;

    void Update()
    {
        if(playerController.instance.isDead())
        {
            if(!started)
            {
                started = true;
                StartCoroutine(SlowDownPitch());   
            }
        }
        else
        {
            started = false;
            battleTheme.pitch = 1;
        }
    }

    private IEnumerator SlowDownPitch()
    {
        while(playerController.instance.isDead())
        {
            battleTheme.pitch =  Mathf.Max(0, battleTheme.pitch - .04f);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}

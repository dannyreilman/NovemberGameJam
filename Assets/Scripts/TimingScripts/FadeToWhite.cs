using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToWhite : Callable {
    public int sceneToLoad;
    public GameObject fader;

    public override void Call()
    {
        Animator anim = fader.GetComponent<Animator>();
        anim.SetTrigger("Fade");
        StartCoroutine(LoadAfterPause());
    }

    public IEnumerator LoadAfterPause()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}

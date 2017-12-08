using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour {

	public int nextindex;

	public AudioSource goSound;

	void Update(){
   		this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        StartCoroutine(nextUp(nextindex));
        goSound.Play();
    }

	IEnumerator nextUp(int target)
	{
		yield return new WaitForSeconds(0.5f);
        //3 is menu
		SceneManager.LoadScene(target);
	}
}

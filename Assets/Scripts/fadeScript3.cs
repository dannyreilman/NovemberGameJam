using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeScript3 : MonoBehaviour {

    // the image you want to fade, assign in inspector
    public Image img1;
	public Text txt1;
	public Image img2;
	public Text txt2;   
	public Image img3;
	public Text txt3;
    public Image ship;
    public Button play;
    public Button settings;
    public Button quit;

    public AudioSource goSound;

  
    void Update(){
   		this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick()
    {
        goSound.Play();
        StartCoroutine(FadeImage(true));
        StartCoroutine("exitGame");
    }
 
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            AmbienceFade.instance.Fade();
            play.GetComponent<AudioSource>().enabled = false;
            settings.GetComponent<AudioSource>().enabled = false;
            quit.GetComponent<AudioSource>().enabled = false;
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img1.color = new Color(1, 1, 1, i);
				txt1.color = new Color(1, 1, 1, i);
				img2.color = new Color(1, 1, 1, i);
				txt2.color = new Color(1, 1, 1, i);
				img3.color = new Color(1, 1, 1, i);
				txt3.color = new Color(1, 1, 1, i);
                ship.color = new Color(1, 1, 1, i);
                play.interactable = false; 
                settings.interactable = false;
                quit.interactable = false;
                yield return null;
            }
        }
	}
    IEnumerator exitGame()
    {
        yield return new WaitForSeconds(1.0f);
        Application.Quit();
    }
}

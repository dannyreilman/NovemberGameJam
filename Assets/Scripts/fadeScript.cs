using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeScript : MonoBehaviour {

    // the image you want to fade, assign in inspector
    public Image img1;
	public Text txt1;
	public Image img2;
	public Text txt2;   
	public Image img3;
	public Text txt3;
	public rotator rt;
    public Button play;
    public Button settings;
    public Button quit;

    public AudioSource goSound;
 
    void Awake(){

            play.GetComponent<AudioSource>().enabled = true;
            settings.GetComponent<AudioSource>().enabled = true;
            quit.GetComponent<AudioSource>().enabled = true;
            Time.timeScale = 1;
    }

    void Update(){
   		this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        StartCoroutine(FadeImage(true));
        goSound.Play();

        rt.clicked = true;
    }
 
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            AmbienceFade.instance.Fade(0.2f);
            play.GetComponent<AudioSource>().enabled = false;
            settings.GetComponent<AudioSource>().enabled = false;
            quit.GetComponent<AudioSource>().enabled = false;
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime/2)
            {
                // set color with i as alpha
                img1.color = new Color(1, 1, 1, i);
				txt1.color = new Color(1, 1, 1, i);
				img2.color = new Color(1, 1, 1, i);
				txt2.color = new Color(1, 1, 1, i);
				img3.color = new Color(1, 1, 1, i);
				txt3.color = new Color(1, 1, 1, i);
                play.interactable = false; 
                settings.interactable = false;
                quit.interactable = false;
                yield return null;
            }
        }
	}
}

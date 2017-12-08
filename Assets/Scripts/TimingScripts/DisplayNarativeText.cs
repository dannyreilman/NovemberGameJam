using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNarativeText : MonoBehaviour {
    public string[] text;
    public float duration;
    public float transition;

    public Callable endFunction;
    private Animator anim;

    private Text textObject;


	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        textObject = GetComponent<Text>();
        StartCoroutine(DisplayText());

	}

    private IEnumerator DisplayText()
    {
        int currentText = 0;
        while (currentText < text.Length)
        {
            textObject.text = text[currentText];
            anim.SetTrigger("in");

            yield return new WaitForSecondsRealtime(duration);
            //Fade out
            anim.SetTrigger("out");
            yield return new WaitForSecondsRealtime(transition);
            ++currentText;
        }
        if(endFunction != null)
            endFunction.Call();
    }
}

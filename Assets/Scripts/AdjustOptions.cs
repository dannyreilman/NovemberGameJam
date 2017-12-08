using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustOptions : MonoBehaviour {
    public GameObject proceedButton;

	// Update is called once per frame
	void Update () {
		if(proceedButton!=null && !proceedButton.Equals(null))
        {
            proceedButton.SetActive(winOrLose.won);
        }
    }
}

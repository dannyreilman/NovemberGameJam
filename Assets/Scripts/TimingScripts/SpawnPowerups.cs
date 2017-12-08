using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour {

    float minDelay = 0.05f;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FloodPowerups());
        StartCoroutine(CutMin());
	}

    private IEnumerator CutMin()
    {
        yield return new WaitForSeconds(7);
        minDelay = 0.01f;
    }

    private IEnumerator FloodPowerups()
    {
        float delay = 1f;
        while (true)
        {
            RandomDropper.instance.Drop(new Vector3(Random.Range(-8f, 8f), transform.position.y));

            yield return new WaitForSeconds(delay);
            delay = Mathf.Max(delay / 1.5f, minDelay);
        }
    }
}

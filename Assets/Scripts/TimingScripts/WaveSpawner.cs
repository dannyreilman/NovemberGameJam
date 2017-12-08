using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public float initialWait;
    public float inbetweenWait;
    private int currentWave;

    public Wave[] waves;


    static float updatePeriod = 0.25f;

	// Use this for initialization
	void Start () {
        if (waves.Length > 0)
        {
            currentWave = 0;
            StartCoroutine(WaitAndStart());
        }
	}

    private IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(initialWait);
        StartCoroutine(DoWaves());
    }

    private IEnumerator DoWaves()
    {
        while (currentWave < waves.Length)
        { 
            List<GameObject> currentEnemies = new List<GameObject>();
            foreach (GameObject e in waves[currentWave].enemies)
            {
                currentEnemies.Add(Instantiate(e, transform));
                yield return new WaitForSeconds(waves[currentWave].interEnemyDelay);
            }

            float totalTimeWaited = 0;
            bool someAlive = true;

            while (totalTimeWaited < waves[currentWave].duration && someAlive)
            {
                yield return new WaitForSeconds(updatePeriod);
                totalTimeWaited += updatePeriod;
                someAlive = false;
                foreach (GameObject left in currentEnemies)
                {
                    if (left != null && !left.Equals(null))
                    {
                        someAlive = true;
                    }
                }
            }

            foreach (GameObject e in currentEnemies)
            {
                if (e != null && !e.Equals(null) && e.GetComponent<SwoopingEntranceExit>() != null)
                {
                    e.GetComponent<SwoopingEntranceExit>().Bail();
                }
            }
            ++currentWave;
        }
    }
}

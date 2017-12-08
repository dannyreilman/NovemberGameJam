using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicMovement : MonoBehaviour {
    private playerController pc;

    public Movepoint[] points;
    public Callable endSequence;

    private int currentEvent;
    private Vector2 velocity;

    // Use this for initialization
    void Start () {
        pc = GetComponent<playerController>();
        if (points.Length > 0)
        {
            playerController.cinematic = true;
            Time.timeScale = 0;
            currentEvent = 0;
            StartCoroutine(DoEvents());
        }
    }

    private IEnumerator DoEvents()
    {
        while (currentEvent < points.Length)
        {
            yield return new WaitForSecondsRealtime(points[currentEvent].delayBefore);
            Vector3 target = new Vector3(points[currentEvent].target.x, points[currentEvent].target.y);
            Vector3 initPos = transform.position;
            float initTime = Time.unscaledTime;
            Vector3 velocity = Vector3.zero;
            while((target - transform.position).magnitude > 0.1f)
            {
                float currentTime = Time.unscaledTime;
                transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, points[currentEvent].movementTime, Mathf.Infinity, Time.unscaledDeltaTime);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(points[currentEvent].delayAfter);
            ++currentEvent;
        }

        Time.timeScale = 1;
        if(endSequence != null && !endSequence.Equals(null))
        {
            endSequence.Call();
        }

        playerController.cinematic = false;
    }
}

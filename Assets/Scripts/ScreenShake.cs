using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    public static ScreenShake instance;
    public float amount;
	// Use this for initialization
	void Start () {
        if (instance == null || instance.Equals(null))
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Shake()
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 basePosition = transform.position;
        Vector2 direction = Quaternion.Euler(0,0,Random.Range(0,360)) * Vector2.right;
        direction *= amount;
        Vector3 movedPosition = transform.position + new Vector3(direction.x, direction.y, 0);
        transform.position = movedPosition;
        yield return new WaitForSecondsRealtime(0.05f);
        transform.position = basePosition;
    }
}

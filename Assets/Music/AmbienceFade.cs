using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceFade : MonoBehaviour {
    public static AmbienceFade instance = null;
    public Animator anim;
    void Start()
    {
        if(instance == null || instance.Equals(null))
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Fade(float speed = 1)
    {
        anim.SetTrigger("Fade");
        anim.speed = speed;
    }
}

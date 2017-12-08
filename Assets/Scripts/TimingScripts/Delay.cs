using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : Callable {
    public float delay;
    public Callable next;

	public override void Call()
    {
        StartCoroutine(WaitAndGo());
    }

    private IEnumerator WaitAndGo()
    {
        yield return new WaitForSeconds(delay);
        next.Call();
    }
}

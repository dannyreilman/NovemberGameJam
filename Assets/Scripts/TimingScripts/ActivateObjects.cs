using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects : Callable
{
    public GameObject[] objects;
    public override void Call()
    {
        foreach(GameObject o in objects)
        {
            if(o != null && !o.Equals(null))
                o.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjects : Callable
{
    public GameObject[] objects;
    public override void Call()
    {
        foreach(GameObject o in objects)
        {
            o.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Calls a callable and then another callable
public class Link : Callable
{
    public Callable[] list;

	public override void Call()
    {
       foreach(Callable c in list)
        {
            c.Call();
        }
	}
}

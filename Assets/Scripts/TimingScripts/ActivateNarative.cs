using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNarative : Callable {
    public DisplayNarativeText next; 

    public override void  Call()
    {
        next.enabled = true;
    }
}

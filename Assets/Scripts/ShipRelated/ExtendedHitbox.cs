using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedHitbox : MonoBehaviour {
    [HideInInspector]
    public ModuleController center;

    void OnTriggerEnter2D(Collider2D col)
    {
        center.Impact(col);
    }
}

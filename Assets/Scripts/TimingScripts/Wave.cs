using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A type for easy level design
[System.Serializable]
public class Wave
{
    public float duration;
    public GameObject[] enemies;
    public float interEnemyDelay;
}

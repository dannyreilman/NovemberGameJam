using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDropper : MonoBehaviour
{
    public static RandomDropper instance;
    public GameObject[] drops;

    void Awake()
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

    public void Drop(Vector3 position)
    {
        if (Random.Range(0, 4) == 0)
        {
            Instantiate(drops[Random.Range(0, drops.Length)], position, Quaternion.identity);
        }
    }
}

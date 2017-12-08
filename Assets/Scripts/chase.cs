using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{

    private Transform t;
    public float moveSpeed = 1, rotationSpeed = 0.5f;
    //int MaxDist = 50;
    //int MinDist = 1;

    void Start()
    {
        GameObject p = GameObject.Find("player");
        t = p.transform;

    }
    void Update()
    {
        transform.LookAt(t);


           transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(t.position - transform.position), rotationSpeed * Time.deltaTime);
       // transform.position += transform.forward * moveSpeed * Time.deltaTime;



    }
}
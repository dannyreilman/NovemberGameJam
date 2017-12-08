﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntrance : MonoBehaviour {
    public Vector3 target;
    private EnemyMovement standardState;
    private bool swoopingIn;
    private bool swoopingOut;

    private float currentSpeed;
    static float minSpeed = 2f;
    static float approachFactor = 2f;
    static float escapeFactor = 100f;

    
    // Use this for initialization
    void Start () {
        standardState = GetComponent<EnemyMovement>();
        standardState.enabled = false;
        swoopingIn = true;
        swoopingOut = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (swoopingIn)
        {
            float speed = Mathf.Max(minSpeed, (transform.position - target).magnitude * approachFactor);
            Vector3 direction = (target - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            if ((target - transform.position).magnitude < 0.1f)
            {
                swoopingIn = false;
                standardState.enabled = true;
            }
        }

        if (swoopingOut)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.Translate(direction * currentSpeed * Time.deltaTime);

            if ((target - transform.position).magnitude < 0.1f)
            {
                Destroy(gameObject);
            }
            currentSpeed += 5f * Time.deltaTime;
        }
    }

    public void Bail()
    {
        currentSpeed = 0;
        swoopingOut = true;
        standardState.enabled = false;
        float goalx = 0;
        if(transform.position.x < 0)
        {
            goalx = -25;
        }
        else
        {
            goalx = 25;
        }
        target = new Vector3(goalx, transform.position.y + 10, 0);
    }
}
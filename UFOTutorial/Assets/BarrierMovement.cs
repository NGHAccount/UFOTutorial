﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMovement : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;

    private float startTime;
    private float journeyLength;

    void Start(){
        startTime = Time.time;
        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }

    
    void Update(){
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector2.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));
        
    }
}

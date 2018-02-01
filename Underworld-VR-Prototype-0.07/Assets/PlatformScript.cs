﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    private GameManager gameManager;
    private GameObject playerController;

    public float scaleCurrent;
    public float scaleOriginal;

    public bool moving;
    public bool scaling;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public float maxSpeed;

    public float distanceTotal;
    public float distanceCurrent;


    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("PlayerController");

        scaleOriginal = transform.localScale.x;
        scaleCurrent = transform.localScale.x;
        distanceTotal = Vector3.Distance(transform.position, Vector3.zero);
        maxSpeed = 0;
    }
	
	// Update is called once per frame
	void Update () {

        distanceCurrent = Vector3.Distance(transform.position, Vector3.zero);
        var distancePercent = (distanceTotal - distanceCurrent) / distanceTotal;

        if (gameManager.playerMoveToStadium && moving)
        {
            if (distancePercent < .9f)
            {
                maxSpeed = Mathf.Lerp(maxSpeed, 10, Time.deltaTime / 5);
            } else
            {
                maxSpeed = Mathf.Lerp(maxSpeed, 10 * (1.5f - distancePercent), Time.deltaTime);
            }
            transform.position = Vector3.SmoothDamp(transform.position, Vector3.zero, ref velocity, smoothTime, maxSpeed);
            playerController.transform.position = Vector3.SmoothDamp(playerController.transform.position, Vector3.zero, ref velocity, smoothTime, maxSpeed);

            if (distanceCurrent < .001f)
            {
                moving = false;
                gameManager.playerReachedStadium = true;
            }
        }

        if (gameManager.playerReachedStadium && scaling)
        {
            // Scaling based on distance
            //var distancePercent = (distanceTotal - distanceCurrent) / distanceTotal;
            //scaleCurrent = Mathf.Lerp(scaleCurrent, scaleOriginal + ((1 - scaleOriginal) * distancePercent), Time.deltaTime * 2f);
            //scaleCurrent = Mathf.Lerp(scaleCurrent, 1, Time.deltaTime);
            // Simple scaling i.e., scale when at the top of the stadium
            scaleCurrent = Mathf.Lerp(scaleCurrent, 1, Time.deltaTime * 1.5f);
            transform.localScale = new Vector3(scaleCurrent, scaleCurrent, scaleCurrent);

            if ((scaleCurrent / 1) > .999f)
            {
                scaling = false;
            }

        }
		
	}
}
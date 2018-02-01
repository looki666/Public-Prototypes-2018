﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumEnable : MonoBehaviour {

    public float scaleCurrent;
    public float scaleOriginal;

    public bool flash;
    public bool scaling;

    public GameObject abovePlatform;

    public bool isStadium;
    public bool isPlatformTriangles;

    public GameObject[] platformTriangles;

    // Use this for initialization
    void Start () {
        scaleOriginal = abovePlatform.transform.localScale.y;
    }

    private void OnEnable()
    {
        if (isStadium)
        {
            scaleCurrent = .4f;
            StartCoroutine(StadiumFlash());
        }

        if (isPlatformTriangles)
        {
            scaleCurrent = 0;
            StartCoroutine(PlatformTraingleFlash());
        }
        scaling = false;
    }

    // Update is called once per frame
    void Update () {

        if (!scaling)
        {
            scaleCurrent = Mathf.Lerp(scaleCurrent, scaleOriginal, Time.deltaTime);
            abovePlatform.transform.localScale = new Vector3(abovePlatform.transform.localScale.x, scaleCurrent, abovePlatform.transform.localScale.z);
        }
        
        

        if ((scaleCurrent / scaleOriginal) > .98f)
        {
            scaling = false;
        }
		
	}

    IEnumerator StadiumFlash()
    {
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.25f);
        abovePlatform.SetActive(false);
        yield return new WaitForSeconds(.25f);
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.1f);
        abovePlatform.SetActive(false);
        yield return new WaitForSeconds(.1f);
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.01f);
        abovePlatform.SetActive(false);
        yield return new WaitForSeconds(.01f);
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.01f);
        abovePlatform.SetActive(false);
        yield return new WaitForSeconds(.01f);
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.005f);
        abovePlatform.SetActive(false);
        yield return new WaitForSeconds(.005f);
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.005f);
        abovePlatform.SetActive(false);
        yield return new WaitForSeconds(.005f);
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.0005f);
        abovePlatform.SetActive(false);
        yield return new WaitForSeconds(.0005f);
        abovePlatform.SetActive(true);
        yield return new WaitForSeconds(.0005f);
    }

    IEnumerator PlatformTraingleFlash()
    {
        for (int i = 0; i < 4; i++)
        {
            platformTriangles[i].SetActive(false);
        }

        platformTriangles[0].SetActive(true);
        yield return new WaitForSeconds(.5f);
        platformTriangles[1].SetActive(true);
        yield return new WaitForSeconds(.5f);
        platformTriangles[2].SetActive(true);
        yield return new WaitForSeconds(.5f);

        platformTriangles[1].SetActive(false);
        yield return new WaitForSeconds(.05f);
        platformTriangles[1].SetActive(true);
        yield return new WaitForSeconds(.05f);

        platformTriangles[3].SetActive(true);
        yield return new WaitForSeconds(.1f);

        platformTriangles[2].SetActive(false);
        yield return new WaitForSeconds(.02f);
        platformTriangles[2].SetActive(true);
        yield return new WaitForSeconds(.02f);
        platformTriangles[2].SetActive(false);
        yield return new WaitForSeconds(.01f);
        platformTriangles[2].SetActive(true);
        yield return new WaitForSeconds(.01f);

        platformTriangles[0].SetActive(true);
        yield return new WaitForSeconds(.01f);
        platformTriangles[0].SetActive(false);
        yield return new WaitForSeconds(.01f);
        platformTriangles[0].SetActive(true);
        yield return new WaitForSeconds(.01f);
        platformTriangles[0].SetActive(false);
        yield return new WaitForSeconds(.01f);
        platformTriangles[0].SetActive(true);
        yield return new WaitForSeconds(.005f);
        platformTriangles[0].SetActive(false);
        yield return new WaitForSeconds(.005f);
        platformTriangles[0].SetActive(true);
        yield return new WaitForSeconds(.005f);
        platformTriangles[0].SetActive(false);
        yield return new WaitForSeconds(.005f);
        platformTriangles[0].SetActive(true);
        yield return new WaitForSeconds(.005f);
        platformTriangles[0].SetActive(false);
        yield return new WaitForSeconds(.005f);
        platformTriangles[0].SetActive(true);
        yield return new WaitForSeconds(.005f);

        platformTriangles[3].SetActive(false);
        yield return new WaitForSeconds(.02f);
        platformTriangles[3].SetActive(true);
        yield return new WaitForSeconds(.02f);
        platformTriangles[3].SetActive(false);
        yield return new WaitForSeconds(.01f);
        platformTriangles[3].SetActive(true);
        yield return new WaitForSeconds(.01f);
    }
}
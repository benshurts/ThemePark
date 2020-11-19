﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour {
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    public Camera mainCam;
	
    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)){
            touchStart = mainCam.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("touch");
        }
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }else if(Input.GetMouseButton(0)){
            Vector3 direction = touchStart - mainCam.ScreenToWorldPoint(Input.mousePosition);
            mainCam.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment){
        mainCam.orthographicSize = Mathf.Clamp(mainCam.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public float movingSpeed = 0.1f;
    public float firstFingerPos;
    public float fingerPos;
    public float directionX;
    public float directionD;
    public float backGroundPosition;
    public GameObject backGround;

    void Update()
    {
        backGroundPosition = backGround.transform.position.x;
        if (Input.GetMouseButtonDown(0))
        {
            firstFingerPos = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            fingerPos = Input.mousePosition.x;
            directionX = firstFingerPos - fingerPos;
            directionD = backGround.transform.position.x - directionX * movingSpeed * Time.deltaTime;
            backGround.transform.position = new Vector3(Mathf.Clamp(directionD, -1620f, 2700f), backGround.transform.position.y, backGround.transform.position.z);
            firstFingerPos = fingerPos;
        }
    }
}

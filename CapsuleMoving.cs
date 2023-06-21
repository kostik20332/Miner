using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleMoving : MonoBehaviour
{
    private float speed = 25f;
    private float speedOfFilling = 0.02f;
    private bool moving = true;
    public Image elickLevel;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moving)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        else
        {
            elickLevel.fillAmount += speedOfFilling;
            if(elickLevel.fillAmount >= 1f)
            {
                moving = true;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Container")
        {
            Destroy(gameObject);
            ElickInCapsuls.capsulsInContainersAmount[0]++;
        }
        else if (other.gameObject.tag == "Provider")
        {
            moving = false;
        }
    }
}

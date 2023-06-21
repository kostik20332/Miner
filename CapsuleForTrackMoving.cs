using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleForTrackMoving : MonoBehaviour
{
    private float speed = 50f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Track" && gameObject.tag == "First")
        {
            ElickInCapsuls.capsuleInTrackAmount++;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Track" && gameObject.tag == "Last")
        {
            ElickInCapsuls.trackAnimating = false;
            ElickInCapsuls.trackMovingDirection = -1;
            ElickInCapsuls.capsuleInTrackAmount++;
            Destroy(gameObject);
        }
    }
}

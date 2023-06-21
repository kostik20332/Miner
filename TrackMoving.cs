using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMoving : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == "RightColliderForTrack")
        //{
        //    ElickInCapsuls.trackMovingDirection = -1;
        //}
        //else if (other.gameObject.tag == "LeftColliderForTrack")
        //{
        //    ElickInCapsuls.trackMovingDirection = 1;
        //}

        if (other.gameObject.tag == "RightColliderForTrack" || other.gameObject.tag == "LeftColliderForTrack")
        {
            ElickInCapsuls.trackMovingDirection = 0;
            ElickInCapsuls.trackDirectionIsRight = !ElickInCapsuls.trackDirectionIsRight;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMoving : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DownCol")
        {
            ElickInCapsuls.liftAllowToMove = false;
            if (ElickInCapsuls.capsulsInContainersAmount[0] >= 10)
            {

                ElickInCapsuls.liftPositionForAnimating = 0;
                ElickInCapsuls.liftAnimating = true;
            }
        }
        else if (other.gameObject.tag == "MidCol")
        {
            if (ElickInCapsuls.capsulsInContainersAmount[1] >= 10)
            {
                if(ElickInCapsuls.liftMovingDirection == 1)
                {
                    ElickInCapsuls.liftAllowToMove = false;
                    ElickInCapsuls.liftPositionForAnimating = 1;
                    ElickInCapsuls.liftAnimating = true;
                }
            }
        }
        else if (other.gameObject.tag == "TrackCol")
        {
            ElickInCapsuls.liftAllowToMove = false;
            ElickInCapsuls.liftPositionForAnimating = 3;
            ElickInCapsuls.liftAnimating = true;
        }
    }
}

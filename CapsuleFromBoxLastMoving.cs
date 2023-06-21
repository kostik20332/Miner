using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleFromBoxLastMoving : MonoBehaviour
{
    private float speed = 50f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lift")
        {
            ElickInCapsuls.capsuleDestroiedAmount++;
            ElickInCapsuls.capsulsInLiftAmount++;
            ElickInCapsuls.liftAllowToMove = true;
            ElickInCapsuls.liftMovingDirection = 1;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "BoxAfterLift")
        {
            ElickInCapsuls.capsuleDestroiedAmount++;
            ElickInCapsuls.capsuleAfterLiftAmount++;
            ElickInCapsuls.liftAllowToMove = true;
            ElickInCapsuls.liftMovingDirection = -1;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReachedOilDeleting : MonoBehaviour
{
    public TMP_Text elick;
    public double elickAmount;

    void Update()
    {
        elickAmount = ElicMining.elickAmount;
        transform.position += new Vector3(0.3f, 0f, 0f);
        elick.text = " " + elickAmount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Center")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElickStorage : MonoBehaviour
{
    public Image elickLevel;
    
    void Awake()
    {
        elickLevel.fillAmount = 0f;
    }
}

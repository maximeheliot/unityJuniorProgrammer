using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private static int Count = 0;

    private void Start()
    {
        Count = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Count += 1;
        Destroy(other.gameObject);
        CounterText.text = "Count : " + Count;
    }
}

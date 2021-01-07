using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(DestroyCoin(other.gameObject));
    }

    IEnumerator DestroyCoin(GameObject coin)
    {
        yield return new WaitForSeconds(2);
        Destroy(coin);
    }
}

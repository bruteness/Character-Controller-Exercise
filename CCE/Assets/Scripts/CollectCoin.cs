using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public float spinSpeed;
    public AudioClip coinPickup;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinPickup, transform.position);
            Destroy(gameObject);
        }
    }
}

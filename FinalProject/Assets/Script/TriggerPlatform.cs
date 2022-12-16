using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    private GameObject hidey;
    void Start() {
        hidey = GameObject.Find("hidey");
        hidey.gameObject.SetActive(false);
    }
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("Player")) {
            hidey.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit (Collider other) {
        if (other.CompareTag ("Player")) {
            hidey.gameObject.SetActive(false);
        }
    }
}

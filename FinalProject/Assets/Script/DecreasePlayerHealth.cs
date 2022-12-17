using System.Collections;
using UnityEngine;

public class DecreasePlayerHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;

    void Start()
    {

    }
   
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
        }
    }
}

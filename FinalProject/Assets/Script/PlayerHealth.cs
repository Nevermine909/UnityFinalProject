using System.Collections;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int health = 1;

    public int getPlayerHealth()
    {
        return health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }
}

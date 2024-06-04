using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : MonoBehaviour
{
    [SerializeField] private int health = 1;
    public void TakeDamage() 
    {
        if (health > 0) health--;
        if (health == 0) Die();
    }
    public void Die() 
    {
        Destroy(this.gameObject);
    }
    
}

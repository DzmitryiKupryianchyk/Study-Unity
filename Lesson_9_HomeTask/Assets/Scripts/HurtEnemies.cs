using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurtEnemies : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstackle"))
        {
            other.GetComponent<RecieveDamage>().TakeDamage();
        } 
    }
    private void OnTriggerStay2D(Collider2D other)
    {
    }
    private void OnTriggerExit2D(Collider2D other)
    {
    }
}

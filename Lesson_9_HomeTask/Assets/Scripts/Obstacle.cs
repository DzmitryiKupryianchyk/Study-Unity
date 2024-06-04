using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damageDegree;
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        character = collision.gameObject.GetComponent<Character>(); 
        if (character != null)
        {
            character.GetDamage(damageDegree);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
    }
}

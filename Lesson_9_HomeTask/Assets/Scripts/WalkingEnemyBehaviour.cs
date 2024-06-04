using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float walkingDistance = 5.0f;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public Rigidbody2D RB { get { return rb = rb ?? GetComponent<Rigidbody2D>(); } }
    public SpriteRenderer SpriteRenderer { get { return spriteRenderer = spriteRenderer ?? GetComponent<SpriteRenderer>(); } }
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        RB.transform.position = Vector3.MoveTowards(RB.transform.position, RB.transform.position + direction, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Obstackle"))
        {
            //direction = direction == Vector2.right ? Vector2.left : Vector2.right;
            if (direction == Vector3.right)
            {
                direction = Vector3.left;
                SpriteRenderer.flipX = false;
            }
            else 
            { 
                direction = Vector3.right;
                SpriteRenderer.flipX = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }
}

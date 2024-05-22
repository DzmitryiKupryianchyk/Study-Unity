using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    public CharacterControl character;
    public float h;
    public float v;
    // Start is called before the first frame update
    public Animator Animator { get { return animator = animator ?? GetComponent<Animator>(); } }
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (v > 0)
        {
            Animator.SetBool("isWalking", true);
            character.speed = 1.6f;
        }
        else Animator.SetBool("isWalking", false);
        if (v < 0)
        {
            Animator.SetBool("isWalkingBack", true);
            character.speed = 0.8f;
        }
        else Animator.SetBool("isWalkingBack", false);
        if (h < 0 & v == 0)
        {
            Animator.SetBool("isWalkingLeft", true);
            character.speed = 0.8f;
        }
        else Animator.SetBool("isWalkingLeft", false);
        if (h > 0 & v == 0)
        {
            Animator.SetBool("isWalkingRight", true);
            character.speed = 0.8f;
        }
        else Animator.SetBool("isWalkingRight", false);
    }
}

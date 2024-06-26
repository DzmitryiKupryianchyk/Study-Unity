using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class CharacterScript : MonoBehaviour
{
    private Camera m_Camera;
    private NavMeshAgent m_Agent;
    private float normalSpeed;

    CharacterContr controller;
    private void OnEnable()
    {
        controller = new CharacterContr();
        controller.CharacterMap.SetDestination.performed += SetDestination_performed;
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.CharacterMap.SetDestination.performed -= SetDestination_performed;
        controller.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
        m_Agent = GetComponent<NavMeshAgent>();
        normalSpeed = m_Agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void SetDestination_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) 
        {
            m_Agent.SetDestination(hit.point);
        }
    }

    public void SpeedAdjustment(float areaCost, bool isSlowingDown) 
    {
        if (isSlowingDown) 
        {
            if(m_Agent.speed > areaCost) { m_Agent.speed -= areaCost;}
            else { m_Agent.speed = 1.0f;}
        }
        else m_Agent.speed += areaCost;
    }
}

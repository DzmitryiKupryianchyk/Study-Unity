using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{
    [SerializeField] private List<GameObject> list;
    GameObject currentPrefab;
    InputManager controller;

    private void OnEnable()
    {
        controller = new InputManager();
        controller.MyMap.Creation.performed += Creation_performed;
        controller.Enable();
    }
    private void OnDisable()
    {
        controller.MyMap.Creation.performed -= Creation_performed;
        controller.Disable();
    }
    private void Creation_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        GameObject randomPrefab = list[Random.Range(0, list.Count)];
        currentPrefab = Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

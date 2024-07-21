using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeshGenerator : MonoBehaviour
{
    public CubeScript sample;
    public List <Transform> spawnSpots;
    private ActionControll controller;
    public CubeScript newMesh;
    public float verticalOffset;
    public bool isSampleBaked = true;
    public float motionSpeed;
    private void OnEnable()
    {
        controller = new ActionControll();
        controller.MyAction.MeshAction.performed += MeshAction_performed;
        controller.Enable();
    }
    private void OnDisable()
    {
        controller.MyAction.MeshAction.performed -= MeshAction_performed;
        controller.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        verticalOffset = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSample();
    }
    private void MeshAction_performed(InputAction.CallbackContext obj)
    {
        if (isSampleBaked)
        {
            System.Random random = new System.Random();
            int randomSpot = random.Next(0, spawnSpots.Count);
            sample.transform.position = new Vector3(spawnSpots[randomSpot].position.x, 0 + verticalOffset, spawnSpots[randomSpot].position.z);
            newMesh = Instantiate(sample);
            ++verticalOffset;
            isSampleBaked = false;
        }
        else 
        {
            if (newMesh != null)
            {
                newMesh.transform.position = newMesh.transform.position;
                isSampleBaked = true;
            }
        }
    }

    private void MoveSample() 
    {
        if (newMesh != null && !isSampleBaked) 
        {
            Vector3 targetDirection = new Vector3(sample.transform.position.x * -1, sample.transform.position.y, sample.transform.position.z * -1);
            newMesh.transform.position = Vector3.MoveTowards(newMesh.transform.position, targetDirection, motionSpeed * Time.deltaTime);
            if (Vector3.Distance(newMesh.transform.position, targetDirection) < 0.1) 
            {
                Destroy(newMesh.gameObject);
                isSampleBaked = true;
                --verticalOffset;
            }
        }
    }
}

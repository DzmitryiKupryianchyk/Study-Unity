using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class SlowDownZone : MonoBehaviour
{
    NavMeshModifierVolume volume;
    public NavMeshModifierVolume Volume { get { return volume = volume ?? GetComponent<NavMeshModifierVolume>(); } }
    float areaCost;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            areaCost = NavMesh.GetAreaCost(Volume.area);
            CharacterScript characterScript = other.GetComponent<CharacterScript>();
            characterScript.SpeedAdjustment(areaCost, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            areaCost = NavMesh.GetAreaCost(Volume.area);
            CharacterScript characterScript = other.GetComponent<CharacterScript>();
            characterScript.SpeedAdjustment(areaCost, false);
        }
    }
}

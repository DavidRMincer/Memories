using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControls_script : MonoBehaviour
{
    public GameObject[] phases;
    public Camera[] cameras;

    public void ActivatePhase(int index)
    {
        for (int i = 0; i < phases.Length; ++i)
        {
            phases[i].SetActive(i == index);
        }
    }

    public void DeactivateAllPhases()
    {
        foreach (var item in phases)
        {
            item.SetActive(false);
        }
    }
}

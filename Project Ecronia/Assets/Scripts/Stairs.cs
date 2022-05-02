using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField] List<GameObject> steps;

    int activatedStep = 0;

    public void Next()
    {
        if (activatedStep < steps.Count)
        {
            activatedStep++;
            steps[activatedStep].SetActive(true);
        }
    }
}

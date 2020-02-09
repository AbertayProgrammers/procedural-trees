using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeGenerator : MonoBehaviour
{
    public GameObject branchPrefab;


    void Start()
    {
        GameObject branch = Instantiate(branchPrefab);

        GenerateBranches(branch, 8);
    }


    // Recursively generate branches as children of the specified parent branch
    private void GenerateBranches(GameObject parentBranch, int iterations)
    {
        GameObject branch1 = Instantiate(branchPrefab, parentBranch.transform);

        Quaternion branch1Rotation = Quaternion.Euler(0, 0, 45) * Quaternion.Euler(0, Random.Range(0, 360), 0);
        branch1.transform.localRotation = branch1Rotation;
        branch1.transform.localPosition = branch1Rotation * Vector3.up;
        branch1.transform.localScale = Vector3.one * 0.7f;

        GameObject branch2 = Instantiate(branchPrefab, parentBranch.transform);

        Quaternion branch2Rotation = Quaternion.Euler(0, 0, -45) * Quaternion.Euler(0, Random.Range(0, 360), 0);
        branch2.transform.localRotation = branch2Rotation;
        branch2.transform.localPosition = branch2Rotation * Vector3.up;
        branch2.transform.localScale = Vector3.one * 0.7f;

        // If iterations equals 1, we’ve reached the smallest branch and no more branches should be generated.
        if (iterations > 1)
        {
            GenerateBranches(branch1, iterations - 1);
            GenerateBranches(branch2, iterations - 1);
        }
    }
}

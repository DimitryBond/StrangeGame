using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string resourceType;
    public int resourceAmount;

    
    private void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}

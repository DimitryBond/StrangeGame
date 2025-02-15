using System;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject objectToSpawn;
    private Animator camAnim;
    public GameObject buildEffect;
    public GameObject buildSound;

    private void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildSound);
            Instantiate(buildEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

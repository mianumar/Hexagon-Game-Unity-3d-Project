using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray2D ray = new Ray2D(transform.position, transform.forward);

            // Casts the ray and get the first game object hit
             hit = Physics2D.Raycast(transform.position, transform.forward);
            if (hit.transform.tag == "OBJ")
                Debug.Log("This hit at " + hit.transform.gameObject.name);
        }
    }
}

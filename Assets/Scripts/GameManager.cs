using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Vector3 mousePosNew;
    public GameObject[] hexagon;
    GameObject hex;
    SpriteRenderer spriteRenderer;
    public Material[] material;
    public int mat = 0;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //hexagon[0].spriteRenderer.material.color = Color.cyan;
        //hexagon[0].GetComponent<Material>().color = Color.red;

        WinPanel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            hexagon[0].GetComponent<SpriteRenderer>().material = material[mat];
            mat++;
            if (mat > material.Length - 1)
            {
                mat = 0;
            }

        }
        //  mousePosNew = Camera.main.ScreenToWorldPoint(-Input.mousePosition);
        //   Debug.DrawRay(transform.position, mousePosNew, Color.green);
        if (Input.GetMouseButtonUp(0))
        {
            /*      hexagon[0].GetComponent<SpriteRenderer>().material = material[mat];
                  mat++;
                  if (mat > material.Length - 1)
                  {
                      mat = 0;
                  }*/


            //   Ray2D ray = new Ray2D(transform.position, transform.forward);
            Vector3 mousePos = Input.mousePosition;
            mousePosNew = Camera.main.ScreenToWorldPoint(mousePos);

            // Casts the ray and get the first game object hit
            RaycastHit2D hit = Physics2D.Raycast(mousePosNew, Vector2.zero);
            Debug.DrawRay(transform.position, mousePosNew, Color.green);
            Debug.Log("This hit at " + hit.transform.gameObject.name);

            //gameObject.GetComponent<SpriteRenderer>().material = material[mat];
            int temp;
            do
            {
                temp = mat;
                mat = Random.Range(1, material.Length - 1);
            } while (temp == mat);

            hit.transform.gameObject.GetComponent<SpriteRenderer>().material = material[mat];

        }


        // Debug.Log(hexagon[0].GetComponent<SpriteRenderer>().material.name);
        if (hexagon[0].GetComponent<SpriteRenderer>().material.name == hexagon[1].GetComponent<SpriteRenderer>().material.name)
        {
            if (hexagon[2].GetComponent<SpriteRenderer>().material.name == hexagon[3].GetComponent<SpriteRenderer>().material.name)
            {
                if (hexagon[4].GetComponent<SpriteRenderer>().material.name == hexagon[5].GetComponent<SpriteRenderer>().material.name)
                {
                    if (hexagon[6].GetComponent<SpriteRenderer>().material.name == hexagon[0].GetComponent<SpriteRenderer>().material.name)
                    {

                        Debug.Log("All Hex are Same");
                        WinPanel.SetActive(true);

                    }

                }


            }

        }
    }
}


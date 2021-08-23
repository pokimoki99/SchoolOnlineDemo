using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if ((Input.GetMouseButton(0)))
        {

            if (hit.collider != null)
            {
                //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                if (hit.transform.tag == "Interactive_Object")
                {
                    hit.transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, 0);
                    //Debug.Log("This is an interactive object");
                }
                else
                {
                    //Debug.Log("This isn't an interactive object");
                }
            }
            //Debug.Log("Mouse button is pressed");
        }


    }

}

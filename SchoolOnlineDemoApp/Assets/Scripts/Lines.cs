using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    LineRenderer l;
    public List<Vector3> pos;
    bool drawing = false;
    public bool attach = false;
    public float line_Size;
    // Start is called before the first frame update
    void Start()
    {
        l = gameObject.GetComponent<LineRenderer>();
        pos = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if ((Input.GetMouseButtonDown(0)))
        {

            if (hit.collider != null)
            {
                if (hit.transform.tag == "Interactive_Object")
                {
                    if (!hit.transform.GetComponent<Lines>().attach && !attach)
                    {
                        this.pos.Add(hit.transform.position);
                        l.SetPosition(0, hit.transform.position);
                        Debug.Log("rendering line");
                        this.drawing = true;
                        hit.transform.GetComponent<Lines>().attach = true;
                    }
                }
            }
        }
        if ((Input.GetMouseButtonUp(0)))
        {
            if (drawing)
            {
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "box")
                    {
                        if (attach)
                        {
                            pos.Add((Camera.main.ScreenToWorldPoint(Input.mousePosition)));
                            l.startWidth = line_Size;
                            l.endWidth = line_Size;
                            l.SetPosition(1,hit.transform.position);
                            l.useWorldSpace = true;
                            drawing = false;
                            hit.transform.GetComponent<Attaching>().answer = gameObject.name;
                        }
                        else
                        {
                            pos.Clear();
                        }
                    }
                }
            }
           
        }
    }
}

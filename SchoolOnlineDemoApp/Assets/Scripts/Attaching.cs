using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaching : MonoBehaviour
{
    SpriteRenderer Change_color;
    bool checker = false;
    public string identifier = "";
    public bool attached = false;
    public string answer = "";
    // Start is called before the first frame update
    void Start()
    {
        Change_color = GetComponent<SpriteRenderer>();
    }

    public void Check()
    {

        if (checker)
        {
            Change_color.color = Color.green;
        }
        else if (identifier == answer)
        {
            Change_color.color = Color.green;
        }
        else
        {
            Change_color.color = Color.red;
        }
    }

     public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("something is inside");

        if (other.gameObject.tag.Equals("Interactive_Object"))
        {
            Change_color.color = Color.yellow;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals(identifier))
        {
            checker = true;
        }
        else
        {
            checker = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Interactive_Object"))
        {
            Change_color.color = Color.red;
        }

    }
}

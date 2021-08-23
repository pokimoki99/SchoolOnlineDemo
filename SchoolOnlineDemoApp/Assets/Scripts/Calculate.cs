using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    public int match;
    public Image image;

    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
        text.text = "";
    }
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Number_Add(string add)
    {
        text.text += add;
    }

    public void Number_Remove()
    {
        text.text = text.text.Remove(text.text.Length - 1);
    }

    public void Check()
    {
        int answer = int.Parse(text.text);
        if (answer == match)
        {
            image.color = new Color32(0, 128, 0, 255);
        }
        else
        {
            image.color = new Color32(255, 0, 0, 255);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    public int match;
    public Image image;

    public GameObject parentDelete;


    public Text text;

    private void Start()
    {
        image.color = new Color32(255, 255, 255, 255);
        Reset();
    }

    // Update is called once per frame
    public void Reset()
    {
        text.text = "";
        image.color = new Color32(255, 255, 255, 255);
    }

    public void Number_Add(string add)
    {
        text.text += add;
        image.color = new Color32(255, 255, 255, 255);
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
            parentDelete.GetComponent<QuestionCreate>().delete_Instance = true;
        }
        else
        {

            text.text = "";
            image.color = new Color32(255, 0, 0, 255);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject prefab;
    private GameObject instant;
    private bool created = false;
    public bool hidden = false;
    public string sign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (created)
        {
            if (instant.GetComponent<QuestionCreate>().delete_Instance)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Create()
    {
        if (!created)
        {
            instant = Instantiate(prefab, new Vector2(Screen.width/9, Screen.height/8f), gameObject.transform.rotation);
            instant.transform.SetParent(gameObject.transform);
            instant.GetComponent<QuestionCreate>().Appear(sign);
            created = true;
        }
    }
    public void Show_Hide()
    {
        if (hidden)
        {
            
            hidden = false;

        }
        else
        {
            hidden = true;
        }
        instant.SetActive(hidden);
    }
}

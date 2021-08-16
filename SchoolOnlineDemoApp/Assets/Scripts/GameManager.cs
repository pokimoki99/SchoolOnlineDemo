using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool submit = false;
    GameObject[] boxes;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        if (instance)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

       boxes = GameObject.FindGameObjectsWithTag("box");

    }

    private static GameManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Submit()
    {
        submit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (submit)
        {
            foreach (GameObject box in boxes)
            {
                box.GetComponent<Attaching>().Check();
            }
        }
    }

}

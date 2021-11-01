using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGame_GameManager : MonoBehaviour
{
    public int DefaultNum;
    public bool submit = false;
    public bool RandomBool = false;
    public bool Orientation; //false = portrait, true = landscape

    public string Avatar_Selection;

    public Sprite avatar_blue, avatar_green, avatar_purple, avatar_white;
    private SpriteRenderer avatars;

    GameObject[] boxes;
    public static miniGame_GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null) // This is first object, set the static reference
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);

        if (Orientation)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        avatars = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        boxes = GameObject.FindGameObjectsWithTag("box");



    }

    private static miniGame_GameManager instance = null;
    public void Submit()
    {
        submit = true;
    }

    // Update is called once per frame
    void Update()
    {
        avatars = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        if (submit)
        {
            foreach (GameObject box in boxes)
            {
                box.GetComponent<Attaching>().Check();
            }
        }

        if (Avatar_Selection == "Blue")
        {
            avatars.sprite = avatar_blue;
        }
        else if (Avatar_Selection == "Green")
        {
            avatars.sprite = avatar_green;
        }
        else if (Avatar_Selection == "Purple")
        {
            avatars.sprite = avatar_purple;
        }
        else if (Avatar_Selection == "White")
        {
            avatars.sprite = avatar_white;
        }
    }

    public void Avatar(string avatar_type)
    {
        Avatar_Selection = avatar_type;
        Debug.Log(avatar_type);
    }

    int RandomNumber()
    {
        int number = Random.Range(0, 13);
        return number;
    }

    public int QuestionCreateMultiplyRandom()
    {
        return RandomNumber();
    }
    public void DefaultChange(int num)
    {
        DefaultNum = num;
        RandomBool = false;
    }
    public void RandomActivator()
    {
        RandomBool = true;
    }

}

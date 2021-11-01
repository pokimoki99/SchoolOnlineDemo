using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame_BoardGame : MonoBehaviour
{
    public int boxes;
    public string diagram; // !!(2),£££(3)                            '>' is right; '|' is down; '<' is left
    int location = 0;
    int direction = 0;

    int dice;

    public GameObject player;
    public GameObject[] questions;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        questions = GameObject.FindGameObjectsWithTag("box");
        boxes = questions.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_Turn()
    {
        dice = Minigame_RandomNumber();
        //dice = 1;
        text.text = dice.ToString();

        if (location + dice <= diagram.Length)
        {
            for (int i = location; i < location + dice; i++)
            {
                if (diagram[i] == '>')
                {
                    direction = 0;
                }
                else if (diagram[i] == '|')
                {
                    direction = 1;
                }
                else if (diagram[i] == '<')
                {
                    direction = 2;
                }
                else if (direction == 0)
                {
                    player.transform.position = new Vector3 (player.transform.position.x + 26.5f, player.transform.position.y, player.transform.position.z);
                }
                else if (direction == 1)
                {
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 28.8f, player.transform.position.z);
                }
                else if (direction == 2)
                {
                    player.transform.position = new Vector3(player.transform.position.x - 26, player.transform.position.y, player.transform.position.z);
                }
            }
            location += dice;
            Debug.Log(location);
            questions[location].GetComponent<Creator>().Create();
        }
        else
        {
            
        }
    }

    public int Minigame_RandomNumber()
    {
        return Random.Range(1, 7);
    }
}

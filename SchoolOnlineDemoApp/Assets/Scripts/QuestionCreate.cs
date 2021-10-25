﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCreate : MonoBehaviour
{
    public string questionDefault, questionText;
    GameManager game;
    public Text text;
    string identifier = "(input)";
    string defaultNumber = "(default)";
    string DefaultSign = "(sign)";

    int exerciseTtype;

    public Calculate questionAnswer;
    public int questionNumber;
    int x, y;

    public bool delete_Instance;

    // Start is called before the first frame update
    void Awake()
    {

        game = GameObject.Find("GameManager").GetComponent<GameManager>();

        
    }

    public void Dissapear()
    {
        gameObject.SetActive(false);
    }

    public void Appear(string sign)
    {
        questionDefault = "What is (default) (sign) (input)";
        text.text = questionDefault;

        questionAnswer.Reset();

        int answerOne = GetRandom();
        int answerTwo = GetRandom();
        while (sign == "/" && answerTwo == 0)
        {
            answerTwo = GetRandom();
        }
        while (sign == "-" && answerOne - answerTwo <0)
        {
            answerTwo = GetRandom();
        }

        text.text = questionDefault.Replace(DefaultSign, sign)
            .Replace(defaultNumber, answerOne.ToString())
            .Replace(identifier, answerTwo.ToString());

        if (sign == "+")
        {

            questionAnswer.match = answerOne + answerTwo;
        }
        else if (sign == "-")
        {

            questionAnswer.match = answerOne - answerTwo;
        }
        else if (sign == "x" | sign == "*")
        {

            questionAnswer.match = answerOne * answerTwo;
        }
        else if (sign == "/")
        {

            questionAnswer.match = answerOne / answerTwo;
        }

    }
    void input()
    {
        if (game.RandomBool)
        {
            y = GetRandom();
            text.text = questionDefault.Replace(identifier, x.ToString()); ///worked on
            questionAnswer.match = x * y;
        }
        else
        {
            text.text = questionDefault.Replace(identifier, x.ToString()).Replace(defaultNumber, questionNumber.ToString());
            Debug.Log(x);
            //text.text = questionDefault.Replace(defaultNumber, questionNumber.ToString());
            questionAnswer.match = x * questionNumber;
        }

    }

    int GetRandom()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        return game.QuestionCreateMultiplyRandom();
    }

    
}

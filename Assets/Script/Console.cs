using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public GameObject Massage, Content;
    public InputField field;
    public string[] Command_Words;

    void Start()
    {

    }

    void Update()
    {

    }

    public void run()
    {
        string Command = field.text;

        Command.TrimEnd();
        Command.ToLower();
        Command_Words = Command.Split(' ');

        if (Command_Words[0] == "*") 
        {
            if (Command_Words[1] == "write") 
            {
                Message(Command_Words[2]);
            }

            if (Command_Words[1] == "camera")
            {
                int x = int.Parse(Command_Words[2]);

                Camera.main.orthographicSize = x;
            }

        }
    }

    public void Message(string message)
    {
        GameObject Obje = Instantiate(Massage, Content.transform);
        Obje.transform.GetComponent<Text>().text = message;
        _Content();
    }

    public void _Content()
    {
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, Content.transform.childCount * 40);
        // şükür
    }
}

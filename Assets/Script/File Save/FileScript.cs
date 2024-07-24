using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileScript : MonoBehaviour
{
    public Game game;
    public string NameS;


    string pathName, pathName2;


    void Start()
    {
        pathName = "Saves\\" + NameS + "1" + ".txt";
        pathName2 = "Saves\\" + NameS + "2" + ".txt";
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            string a = game.X + " " + game.Y + " " + game.Z;

            string b = "";

            for (int i = 0; i < game.Vk.Count; i++)
            {
                b += game.Vk[i].x + " " + game.Vk[i].y + "v";
            }
            b += game.Vk.Count;

            File.WriteAllText(pathName,a);
            File.WriteAllText(pathName2, b);

            string readText = File.ReadAllText(pathName);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            string readText = File.ReadAllText(pathName);
            string readText2 = File.ReadAllText(pathName2);

            string[] Aa = readText.Split(' ');
            string[] Bb = readText2.Split('v');

            for (int i = 0; i < int.Parse(Bb[Bb.Length - 1]); i++)
            {
                string[] Bi = Bb[i].Split(' ');
                game.Vk[i] = new Vector2(int.Parse(Bi[0]), int.Parse(Bi[1]));


            }

            game.X = int.Parse(Aa[0]);
            game.Y = int.Parse(Aa[1]);
            game.Z = int.Parse(Aa[2]);

        }
    }
}

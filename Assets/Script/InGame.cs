using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    public GameObject info;
    public GameObject info_own, info_pack;
    public AudioSource sc, click;
    public CountryInfo Info;
    public GameInfo GInfo;

    [Header("Start")]
    public Slider Enemy;
    public Text EnemyT, ModT, HardT, DetailT;
    public int Mod, ColorI, Hardly, Detail;
    public Color[] Colors;
    public Image ColorImage;

    private void Start()
    {
        sc.Play();
    }

    private void Update()
    {
        ColorImage.color = Colors[ColorI];

        if(Mod == 0)
        {
            ModT.text = "Tiny";
        }
        if (Mod == 1)
        {
            ModT.text = "Normal";
        }
        if (Mod == 2)
        {
            ModT.text = "Big";
        }

        if (Hardly == 0)
        {
            HardT.text = "Easy";
            GInfo.Hardly = 0;
        }
        if (Hardly == 1)
        {
            HardT.text = "Normal";
            GInfo.Hardly = 1;
        }
        if (Hardly == 2)
        {
            HardT.text = "Hard";
            GInfo.Hardly = 2;
        }

        if (Detail == 0)
        {
            DetailT.text = "Low Detail";
            GInfo.Detail = 16;
        }
        if (Detail == 1)
        {
            DetailT.text = "Normal";
            GInfo.Detail = 8;
        }
        if (Detail == 2)
        {
            DetailT.text = "High Detail";
            GInfo.Detail = 4;
        }

        EnemyT.text = Enemy.value.ToString();
    }
    public void _start()
    {
        
    }

    public void StartGame()
    {
        Info.color = ColorI;
        Info.Color = Colors[ColorI];
        GInfo.enemy = (int)Enemy.value;
        GInfo.mod = Mod;

        if(Mod == 0)
        {
            GInfo.Size = 10;
        }
        if (Mod == 1)
        {
            GInfo.Size = 20;
        }
        if (Mod == 2)
        {
            GInfo.Size = 30;
        }
    }

    public void _quit()
    {
        Application.Quit();
    }

    public void ColorB()
    {
        ColorI++;
        if (ColorI > 6)
        {
            ColorI = 0;
        }
    }

    public void ModB()
    {
        Mod++;
        if (Mod > 2)
        {
            Mod = 0;
        }
    }

    public void HardB()
    {
        Hardly++;
        if (Hardly > 2)
        {
            Hardly = 0;
        }
    }

    public void DetailB()
    {
        Detail++;
        if (Detail > 2)
        {
            Detail = 0;
        }
    }

    public void OpenPanel(GameObject Object)
    {
        Object.SetActive(true);
    }

    public void ClosePanel(GameObject Object)
    {
        Object.SetActive(false);
    }

    public void OpenChrome(string Irl)
    {
        Application.OpenURL(Irl);
    }



}

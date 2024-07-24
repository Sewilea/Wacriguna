using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public World world;
    public CountryInfo Info;
    public GameInfo GInfo;
    public Country Country;
    public List<Color> Colors;
    public CountryInfo[] EnemyInfo;
    public GameObject country;
    public List<GameObject> Enemies;
    public bool Victory;

    void Start()
    {
        
    }

    void Update()
    {
        if (isVictory())
        {
            Victory = true;
        }
        else
        {
            Victory = false;
        }
    }

    public bool isVictory()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            OtherCountries Country = Enemies[i].GetComponent<OtherCountries>();

            if(Country.Territories.Count != 0)
            {
                return false;
            }
           
        }
        return true;
    }

    public void Establish_Game()
    {
        Colors.Remove(Info.Color);

        for (int i = 0; i < GInfo.enemy; i++)
        {
            EnemyInfo[i].Color = Colors[i];
            GameObject Object = Instantiate(country, gameObject.transform);
            OtherCountries Other = Object.GetComponent<OtherCountries>();
            Other.world = world;
            Other.Info = EnemyInfo[i];
            Other.Establish_Country();
            Enemies.Add(Object);
        }

        Country.Establish_Country();
    }
}

[System.Serializable]
public class Enemy
{
    public string CountryName;
    public Vector2 Capital;
    public Color Color;

    public Enemy(string countryName, Vector2 capital, Color color)
    {
        CountryName = countryName;
        Capital = capital;
        Color = color;
    }
}

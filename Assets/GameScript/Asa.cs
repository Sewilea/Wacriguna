using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "Asa", menuName = "Asa")]
public class Asa : ScriptableObject
{
    public int X, Y;
    public int Forest, Iron, Coal, Farming;
}

[System.Serializable]
public class AsaItem
{
    public int X, Y;
    public int Forest, Iron, Coal, Farming;
}


[System.Serializable]
public class AsaInfo
{
    public int Capital;
    public float Home, Population, Castle, Search, Barracks;
    public int Soldier;
}

[System.Serializable]
public class NeededInfo
{
    public int Wood, Stone, Food, Iron;

    public NeededInfo(int wood, int stone, int food, int ıron)
    {
        Wood = wood;
        Stone = stone;
        Food = food;
        Iron = ıron;
    }
}

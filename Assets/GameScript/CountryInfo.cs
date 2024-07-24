using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Asa", menuName = "Country")]
public class CountryInfo : ScriptableObject
{
    public int color;

    public string CountryName;
    public Vector2 Capital;
    public Color Color;
}


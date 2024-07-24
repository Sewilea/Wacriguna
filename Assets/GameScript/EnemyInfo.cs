using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Asa", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public string CountryName;
    public Vector2 Capital;
    public Sprite Flag;
    public Color Color;
}

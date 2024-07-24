using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Asa", menuName = "Game")]
public class GameInfo : ScriptableObject
{
    public int mod, enemy, color, Size, Hardly, Detail;

    [Header("Needed")]
    public NeededInfo[] BuyInfos;
    public NeededInfo Soldier;
    public int[] SearchInfos;
}

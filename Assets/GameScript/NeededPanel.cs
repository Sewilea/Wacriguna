using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NeededPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    World world;
    public bool Conquer, Home, Search, Castle, Barrack, Soldier;

    public bool S1,S2,S3,S4,S5;
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        world.Warn.SetActive(false);
        world.SearhWarn.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Conquer)
        {
            world.WarnPanel(world.Country.GInfo.BuyInfos[0]);
        }
        if (Home)
        {
            world.WarnPanel(world.Country.GInfo.BuyInfos[1]);

        }
        if (Search)
        {
            world.WarnPanel(world.Country.GInfo.BuyInfos[2]);
        }
        if (Castle)
        {
            world.WarnPanel(world.Country.GInfo.BuyInfos[3]);
        }
        if (Barrack)
        {
            world.WarnPanel(world.Country.GInfo.BuyInfos[4]);
        }
        if (Soldier)
        {
            NeededInfo Infos = world.Country.GInfo.Soldier;
            int Popu = (int)world.ValueArmy.value;
            world.WarnPanel(new NeededInfo(Infos.Wood * Popu, Infos.Stone * Popu, Infos.Food * Popu, Infos.Iron * Popu));
        }
        if (S1)
        {
            world.SearchPanel(world.Country.GInfo.SearchInfos[0]);
        }

        if (S2)
        {
            world.SearchPanel(world.Country.GInfo.SearchInfos[1]);
        }

        if (S3)
        {
            world.SearchPanel(world.Country.GInfo.SearchInfos[2]);
        }

        if (S4)
        {
            world.SearchPanel(world.Country.GInfo.SearchInfos[3]);
        }

        if (S5)
        {
            world.SearchPanel(world.Country.GInfo.SearchInfos[4]);
        }
    }
}

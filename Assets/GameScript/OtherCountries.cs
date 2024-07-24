using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCountries : MonoBehaviour
{
    public World world;
    public CountryInfo Info;
    public GameInfo GInfo;
    public GameObject CapitalCity;
    public List<GameObject> Territories;
    public float time, time2;

    [Header("Source")]
    public int Stone;
    public int Wood;
    public int Iron;
    public int Patato;
    public int Gold;
    public int Search;
    public int Population;

    [Header("Source")]
    public float StoneF;
    public float WoodF;
    public float IronF;
    public float PatatoF;
    public float GoldF;
    public float SearchF;
    public float PopulationF;

    [Header("Search")]
    public int Axe;
    public int Picaxe;
    public int Hoe;
    public int Sword;
    public int Shield;

    public bool Dead;

    void Start()
    {
        
    }

    void Update()
    {

        if (Territories.Count == 0)
        {
            Dead = true;
        }
        else
        {
            Dead = false;
        }

        if (world.Time1 && !Dead)
        {
            time += 1 * Time.deltaTime;
            time2 += 1 * Time.deltaTime;

            if (time2 > (25 - GInfo.Hardly * 5))
            {
                time2 = 0;
                AIConquer();
            }
            if (time > (25 - GInfo.Hardly * 5))
            {
                AILevelUp();
                time = 0;
            }
        }

        PopulationF = 0;
        for (int i = 0; i < Territories.Count; i++)
        {
            AsaScript Asa = Territories[i].GetComponent<AsaScript>();
            PopulationF += Asa.AsaInfo.Population;
        }

        Wood = (int)WoodF;
        Patato = (int)PatatoF;
        Stone = (int)StoneF;
        Iron = (int)IronF;
        Search = (int)SearchF;
        Population = (int)PopulationF;
    }

    public void Establish_Country()
    {
        int a = Random.Range(0, world.Starter_Asa.Count);
        Debug.Log(a);
        CapitalCity = world.Starter_Asa[a];
        AddCapitalTerritory(CapitalCity);
    }

    public void AddTerritory(GameObject Object)
    {
        AsaScript Casa = Object.GetComponent<AsaScript>();
        Casa.CountryGameObject = gameObject;
        Territories.Add(Object);
        Casa.Info = Info;
    }

    public void AddCapitalTerritory(GameObject Object)
    {
        AsaScript Casa = Object.GetComponent<AsaScript>();
        Casa.CountryGameObject = gameObject;
        Territories.Add(Object);
        Casa.Info = Info;
        Casa.AsaInfo.Capital = 1;
    }

    public void AIConquer()
    {
        List<AsaScript> Objes = new List<AsaScript>();
        List<GameObject> Terry = Territories;

        for (int i = 0; i < Terry.Count; i++)
        {
            AsaScript Asa = Territories[i].GetComponent<AsaScript>();
            Asa.AIControl = true;
        }

        for (int i = 0; i < Terry.Count; i++)
        {
            AsaScript Asa = Territories[i].GetComponent<AsaScript>();


            Vector2 Vk = new Vector2(Asa.item.X, Asa.item.Y);
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    GameObject Obje = GameObject.Find("Asa " + (x + Vk.x) + " " + (y + Vk.y));

                    if (Obje != null && Asa.AIControl)
                    {
                        AsaScript Asas = Obje.GetComponent<AsaScript>();
                        
                        if (Asas.Info != null && Asas.Info.CountryName != Info.CountryName)
                        {
                            Attack(Asas, Asa);
                            Asa.AIControl = false;

                            int a = Random.Range(0, 2);
                            if (a == 0)
                            {
                                
                            }
                            if (a == 1)
                            {
                                if (Asa.AsaInfo.Barracks > 0)
                                {
                                    NeededInfo Infos = GInfo.Soldier;
                                    int Popu = Random.Range(0,(int)Asa.AsaInfo.Population);
                                    if (WoodF > Infos.Wood * Popu && StoneF > Infos.Stone * Popu && PatatoF > Infos.Food * Popu && IronF > Infos.Iron * Popu)
                                    {
                                        WoodF -= Infos.Wood * Popu;
                                        StoneF -= Infos.Stone * Popu;
                                        PatatoF -= Infos.Food * Popu;
                                        IronF -= Infos.Iron * Popu;

                                        Asa.AsaInfo.Soldier += Popu;
                                    }
                                }
                                Asa.AIControl = false;
                            }
                            
                        }
                    }
                    if (Obje != null)
                    {
                        AsaScript Asas = Obje.GetComponent<AsaScript>();
                        if(Asas.Info == null && Asas.LandType != 5)
                        {
                            Objes.Add(Asas);
                            /*
                            if (isBuy(GInfo.BuyInfos[0]))
                            {
                                AddTerritory(Asas.gameObject);
                            }
                            */
                        }
                    }
                    

                }
            }
            
        }
        if (Objes.Count > 0)
        {
            int a = Random.Range(0, Objes.Count);

            if (isBuy(GInfo.BuyInfos[0]))
            {
                AddTerritory(Objes[a].gameObject);
            }
        }
    }


    public void Attack(AsaScript Asas,AsaScript myasa)
    {
        if (Asas.Info.CountryName != Info.CountryName)
        {
            if(Asas.AsaInfo.Soldier - myasa.AsaInfo.Soldier < 0)
            {
                ConquerLand(Asas);
                Asas.AsaInfo.Soldier = myasa.AsaInfo.Soldier - Asas.AsaInfo.Soldier;
                myasa.AsaInfo.Soldier = 0;
            }
            else
            {
                Asas.AsaInfo.Soldier = Asas.AsaInfo.Soldier - myasa.AsaInfo.Soldier;
                myasa.AsaInfo.Soldier = 0;
            }
        }
    }

    public void Conquer(AsaScript Asa)
    {
        if (isCapture(Asa.gameObject,Asa) && isBuy(GInfo.BuyInfos[0]))
        {
            if(Asa.Info.CountryName == "Me")
            {
                world.Country.Territories.Remove(Asa.gameObject);
            }
            if (Asa.Info.CountryName != "Me")
            {
                Asa.CountryGameObject.GetComponent<OtherCountries>().Territories.Remove(Asa.gameObject);
            }
            AddTerritory(Asa.gameObject);
        }
    }

    public void ConquerLand(AsaScript Asa)
    {
        if (isCapture(Asa.gameObject, Asa))
        {
            if (Asa.Info.CountryName == "Me")
            {
                world.Country.Territories.Remove(Asa.gameObject);
            }
            if (Asa.Info.CountryName != "Me")
            {
                Asa.CountryGameObject.GetComponent<OtherCountries>().Territories.Remove(Asa.gameObject);
            }
            AddTerritory(Asa.gameObject);
        }
    }

    public void AILevelUp()
    {
        for (int i = 0; i < Territories.Count; i++)
        {
            AsaScript Asa = Territories[i].GetComponent<AsaScript>();
            if(Asa.AsaInfo.Home < 10)
            {
                UpdateHome(Asa);
            }
            if (Asa.AsaInfo.Barracks < 10)
            {
                UpdateBarrack(Asa);
            }
            if (Asa.AsaInfo.Search < 10)
            {
                UpdateSearch(Asa);
            }
            if (Asa.AsaInfo.Castle < 10)
            {
                UpdateCastle(Asa);
            }
        }
    }

    public bool isCapture(GameObject Object, AsaScript Asa)
    {
        Vector2 Vk = new Vector2(Asa.item.X, Asa.item.Y);

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                GameObject Obje = GameObject.Find("Asa " + (x + Vk.x) + " " + (y + Vk.y));

                if (Obje != null)
                {
                    AsaScript Asas = Obje.GetComponent<AsaScript>();

                    if (Asas.Info != null && Object.GetComponent<AsaScript>().LandType != 5)
                    {
                        if (Asas.Info.CountryName != Info.CountryName)
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    public bool isBuy(NeededInfo Info)
    {
        if (WoodF > Info.Wood && StoneF > Info.Stone && PatatoF > Info.Food && IronF > Info.Iron)
        {
            WoodF -= Info.Wood;
            StoneF -= Info.Stone;
            PatatoF -= Info.Food;
            IronF -= Info.Iron;
            return true;
        }
        return false;
    }

    public void UpdateHome(AsaScript Asa)
    {
        if (isBuy(GInfo.BuyInfos[1]))
        {
            Asa.AsaInfo.Home++;
            Asa.AsaInfo.Population += 5;
        }
    }
    public void UpdateSearch(AsaScript Asa)
    {
        if (isBuy(GInfo.BuyInfos[2]))
        {
            Asa.AsaInfo.Search++;
        }
    }
    public void UpdateCastle(AsaScript Asa)
    {
        if (isBuy(GInfo.BuyInfos[3]))
        {
            Asa.AsaInfo.Castle++;
        }
    }
    public void UpdateBarrack(AsaScript Asa)
    {
        if (isBuy(GInfo.BuyInfos[4]))
        {
            Asa.AsaInfo.Barracks++;
        }
    }
}

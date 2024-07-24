using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Country : MonoBehaviour
{
    public World world;
    [Header("Country")]
    public CountryInfo Info;
    public GameInfo GInfo;
    public GameObject CapitalCity, LosePanel;
    public bool Loseit;
    public List<GameObject> Territories;

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

    [Header("Text")]
    public Text Stonet;
    public Text Woodt;
    public Text Iront;
    public Text Patatot;
    public Text Goldt;
    public Text Searcht;
    public Text Populationt;
    public Text Landt;
    public Text Axet, Picaxet, Hoet, Swordt, Shieldt;
    public Image Flag;


    void Start()
    {
        
    }

    void Update()
    {

        if (world.Time1)
        {
            /*
            WoodF += (Info.WoodX / 10) * Time.deltaTime;
            PatatoF += Info.PatatoX / 10 * Time.deltaTime;
            StoneF += Info.StoneX / 10 * Time.deltaTime;
            IronF += Info.IronX / 10 * Time.deltaTime;
            SearchF += Info.SearchX / 10 * Time.deltaTime;
            PopulationF += (Info.PopulationX / 10 + Territories.Count / 20) * Time.deltaTime;
            */
        }

        Flag.color = Info.Color;
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

        if(Wood > 1000)
        {
            Woodt.text = (Wood / 1000) + "K";
        }
        else
        {
            Woodt.text = Wood.ToString();
        }

        if (Stone > 1000)
        {
            Stonet.text = (Stone / 1000) + "K";
        }
        else
        {
            Stonet.text = Stone.ToString();
        }

        if (Iron > 1000)
        {
            Iront.text = (Iron / 1000) + "K";
        }
        else
        {
            Iront.text = Iron.ToString();
        }

        if (Patato > 1000)
        {
            Patatot.text = (Patato / 1000) + "K";
        }
        else
        {
            Patatot.text = Patato.ToString();
        }

        if (Gold > 1000)
        {
            Goldt.text = (Gold / 1000) + "K";
        }
        else
        {
            Goldt.text = Gold.ToString();
        }

        if (Search > 1000)
        {
            Searcht.text = (Search / 1000) + "K";
        }
        else
        {
            Searcht.text = Search.ToString();
        }

        if (Population > 1000)
        {
            Populationt.text = (Population / 1000) + "K";
        }
        else
        {
            Populationt.text = Population.ToString();
        }

        Landt.text = Territories.Count.ToString();

        Shieldt.text = Shield.ToString();
        Swordt.text = Sword.ToString();
        Axet.text = Axe.ToString();
        Picaxet.text = Picaxe.ToString();
        Hoet.text = Hoe.ToString();

        /*
        Stonet.text = Stone.ToString();
        Woodt.text = Wood.ToString();
        Iront.text = Iron.ToString();
        Patatot.text = Patato.ToString();
        Goldt.text = Gold.ToString();
        Searcht.text = Search.ToString();
        Populationt.text = Population.ToString();
        Landt.text = Territories.Count.ToString();
        */

        if(Territories.Count == 0 && !Loseit)
        {
            LosePanel.SetActive(true);
            Loseit = true;
        }
    }

    public void Establish_Country()
    {
        int a = Random.Range(0, world.Starter_Asa.Count);
        Debug.Log(a);
        CapitalCity = world.Starter_Asa[a];
        world.ChooseAsa = CapitalCity.GetComponent<AsaScript>();
        AddCapitalTerritory(CapitalCity);
        world.Camera.transform.position = CapitalCity.transform.position;


    }

    public void Conquer()
    {
        world.page.click.Play();
        if (isCapture(world.ChooseAsa.gameObject) && isBuy(GInfo.BuyInfos[0]))
        {
            AddTerritory(world.ChooseAsa.gameObject);
            world.Your.SetActive(true);
            world.Yournot.SetActive(false);
            world.Warn.SetActive(false);
        }
    }

    public void Conquer(AsaScript Asa)
    {
        if (isCapture(Asa.gameObject))
        {
            Asa.CountryGameObject.GetComponent<OtherCountries>().Territories.Remove(Asa.gameObject);
            AddTerritory(Asa.gameObject);
            world.Your.SetActive(true);
            world.Yournot.SetActive(false);
            world.Warn.SetActive(false);
        }
    }

    public void UpdateHome()
    {
        world.page.click.Play();
        if (isBuy(GInfo.BuyInfos[1]) && world.ChooseAsa.AsaInfo.Home < 10)
        {
            world.ChooseAsa.AsaInfo.Home++;
            world.ChooseAsa.AsaInfo.Population += 5;
        }
    }
    public void UpdateSearch()
    {
        world.page.click.Play();
        if (isBuy(GInfo.BuyInfos[2]) && world.ChooseAsa.AsaInfo.Search < 10)
        {
            world.ChooseAsa.AsaInfo.Search++;
        }
    }
    public void UpdateCastle()
    {
        world.page.click.Play();
        if (isBuy(GInfo.BuyInfos[3]) && world.ChooseAsa.AsaInfo.Castle < 10)
        {
            world.ChooseAsa.AsaInfo.Castle++;
        }
    }
    public void UpdateBarrack()
    {
        world.page.click.Play();
        if (isBuy(GInfo.BuyInfos[4]) && world.ChooseAsa.AsaInfo.Barracks < 10)
        {
            world.ChooseAsa.AsaInfo.Barracks++;
        }
    }

    public void UpdatesSearch(int Search)
    {
        world.page.click.Play();
        if (isSearch(GInfo.SearchInfos[0]) && Search == 0)
        {
            Axe++;
        }
        if (isSearch(GInfo.SearchInfos[0]) && Search == 1)
        {
            Picaxe++;
        }
        if (isSearch(GInfo.SearchInfos[0]) && Search == 2)
        {
            Hoe++;
        }
        if (isSearch(GInfo.SearchInfos[0]) && Search == 3)
        {
            Sword++;
        }
        if (isSearch(GInfo.SearchInfos[0]) && Search == 4)
        {
            Shield++;
        }
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

    public bool isBuy(NeededInfo Info)
    {
        if(WoodF > Info.Wood && StoneF > Info.Stone && PatatoF > Info.Food && IronF > Info.Iron)
        {
            WoodF -= Info.Wood;
            StoneF -= Info.Stone;
            PatatoF -= Info.Food;
            IronF -= Info.Iron;
            return true;
        }
        return false;
    }

    public void TrainSoldier()
    {
        NeededInfo Infos = GInfo.Soldier;
        float Popu = world.ValueArmy.value;

        if (WoodF > Infos.Wood * Popu && StoneF > Infos.Stone * Popu && PatatoF > Infos.Food * Popu && IronF > Infos.Iron * Popu)
        {
            WoodF -= Infos.Wood * Popu;
            StoneF -= Infos.Stone * Popu;
            PatatoF -= Infos.Food * Popu;
            IronF -= Infos.Iron * Popu;

            world.ChooseAsa.AsaInfo.Soldier += (int)Popu;
            world.ArmyPanel.SetActive(false);
            world.Warn.SetActive(false);
        }
        world.Click = true;
    }

    public bool isSearch(int Info)
    {
        if (SearchF > Info)
        {
            SearchF -= Info;
            return true;
        }
        return false;
    }

    public bool isCapture(GameObject Object)
    {
        Vector2 Vk = new Vector2(world.ChooseAsa.item.X, world.ChooseAsa.item.Y);

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
                        if (Asas.Info.CountryName == "Me")
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }
}


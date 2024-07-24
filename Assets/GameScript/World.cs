using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    public Camera cam;
    public bool Time1, Click;
    public float time;
    public int Hour, Day, Week, Month;
    public Text Clock;

    public Homepage page;
    public CountryInfo Info;
    public GameInfo GInfo;
    public int SizeX, SizeZ;
    public GameObject Asa, Camera;

    [Header("PerlinNoise")]
    public float seed;
    public float terDetail, td2;
    public float Size_Y;

    [Header("InGame")]
    public AsaScript ChooseAsa;
    public Text TopText;
    public List<GameObject> Starter_Asa, All_Asa;
    public Country Country;
    public Manager Manager;

    [Header("Army")]
    public GameObject ArmyPanel, MovePanel, demobilizationPanel;
    public Slider ValueArmy, ValueMove, ValueDemo;
    public Text ArmyMax, ValurMax, DemoMax;
    public int MoveInt;

    [Header("Panels")]
    public GameObject LandPanel, Your, Yournot;
    public GameObject InfoPanel, SoldierB, DemoliB, ConquerB;
    public Text WoodI, FoodI, StoneI, IronI, TType;
    public Text PopuI, HomeI, CastleI, SearchI, BarracksI;

    [Header("Warning")]
    public GameObject Warn, SearhWarn;
    public Text WoodW, StoneW, FoodW, IronW, SearchW;

    [Header("Musics")]
    public AudioSource Walking, Military;


    void Start()
    {
        seed = Random.Range(100000, 999999);
        CreateAsa();
    }

    void Update()
    {
        // New Technique

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            //MousePos.x = Mathf.Round(MousePos.x);
            //MousePos.y = Mathf.Round(MousePos.y);

            for (int i = 0; i < All_Asa.Count; i++)
            {
                Vector2 AsaPos = All_Asa[i].gameObject.transform.position;
                float Distance = Vector2.Distance(AsaPos, MousePos);

                if(Distance < 0.6)
                {
                    Debug.Log("I founded");
                    if (Click)
                    {
                        //Debug.Log(item.X + " " + item.Y);
                        ChooseAsa = All_Asa[i].gameObject.GetComponent<AsaScript>();
                        TerritoryInfo();

                        if (ChooseAsa.Info != null)
                        {
                            if (ChooseAsa.Info.CountryName == "Me")
                            {
                                Your.SetActive(true);
                                Yournot.SetActive(false);
                            }
                            else
                            {
                                Your.SetActive(false);
                                Yournot.SetActive(true);
                                ConquerB.SetActive(false);
                            }
                        }
                        else
                        {
                            Your.SetActive(false);
                            Yournot.SetActive(true);
                            ConquerB.SetActive(true);
                        }
                    }
                }

                if (AsaPos == MousePos)
                {
                   
                }
            }

            Debug.Log(MousePos);
        }



        if (ChooseAsa != null)
        {
            TopText.text = "X:" + ChooseAsa.item.X + " Y:" + ChooseAsa.item.Y;
        }

        Clock.text = "Month " + Month + " Week " + Week + " Day " + Day;

        if (Time1)
        {
            time += 1 * Time.deltaTime;

            if (time > 20)
            {
                Day++;
                Country.PatatoF -= Country.PopulationF;
                time = 0;
            }

            if (Day > 7)
            {
                Day = 0;
                Week++;
            }

            if (Week > 4)
            {
                Week = 0;
                Month++;
            }
        }

        if (InfoPanel.activeSelf)
        {
            HomeI.text = ChooseAsa.AsaInfo.Home.ToString();
            CastleI.text = ChooseAsa.AsaInfo.Castle.ToString();
            BarracksI.text = ChooseAsa.AsaInfo.Barracks.ToString();
            SearchI.text = ChooseAsa.AsaInfo.Search.ToString();
            PopuI.text = ChooseAsa.AsaInfo.Population.ToString();

            if (ChooseAsa.AsaInfo.Barracks != 0)
            {
                SoldierB.SetActive(true);
                if(ChooseAsa.AsaInfo.Soldier > 0)
                {
                    DemoliB.SetActive(true);
                }
            }
            else
            {
                SoldierB.SetActive(false);
                DemoliB.SetActive(false);
            }
        }

        if (ArmyPanel.activeSelf)
        {
            ArmyMax.text = ValueArmy.value.ToString();
            ValueArmy.maxValue = ChooseAsa.AsaInfo.Population;
        }

        if (MovePanel.activeSelf)
        {
            ValurMax.text = ValueMove.value.ToString();
            ValueMove.maxValue = ChooseAsa.AsaInfo.Soldier;
        }

        if (demobilizationPanel.activeSelf)
        {
            DemoMax.text = ValueDemo.value.ToString();
            ValueDemo.maxValue = ChooseAsa.AsaInfo.Soldier;
        }

        if (ChooseAsa != null && ChooseAsa.AsaInfo.Soldier > 0 && ChooseAsa.Info.CountryName == "Me")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ValueMove.value = ChooseAsa.AsaInfo.Soldier;
                ValueArmy.value = ChooseAsa.AsaInfo.Soldier;
                Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
                GameObject Obje = GameObject.Find("Asa " + Vk.x + " " + (Vk.y + 1));

                if (Obje != null)
                {
                    AsaScript Asas = Obje.GetComponent<AsaScript>();
                    if (Asas.Info != null)
                    {
                        Military.Play();
                        MovePanel.SetActive(true);
                        MoveInt = 1;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ValueMove.value = ChooseAsa.AsaInfo.Soldier;
                ValueArmy.value = ChooseAsa.AsaInfo.Soldier;
                Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
                GameObject Obje = GameObject.Find("Asa " + Vk.x + " " + (Vk.y - 1));

                if (Obje != null)
                {
                    AsaScript Asas = Obje.GetComponent<AsaScript>();
                    if (Asas.Info != null)
                    {
                        Military.Play();
                        MovePanel.SetActive(true);
                        MoveInt = 2;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ValueMove.value = ChooseAsa.AsaInfo.Soldier;
                ValueArmy.value = ChooseAsa.AsaInfo.Soldier;
                Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
                GameObject Obje = GameObject.Find("Asa " + (Vk.x + 1) + " " + Vk.y);

                if (Obje != null)
                {
                    AsaScript Asas = Obje.GetComponent<AsaScript>();
                    if (Asas.Info != null)
                    {
                        Military.Play();
                        MovePanel.SetActive(true);
                        MoveInt = 3;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ValueMove.value = ChooseAsa.AsaInfo.Soldier;
                ValueArmy.value = ChooseAsa.AsaInfo.Soldier;
                Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
                GameObject Obje = GameObject.Find("Asa " + (Vk.x - 1) + " " + Vk.y);

                if (Obje != null)
                {
                    AsaScript Asas = Obje.GetComponent<AsaScript>();
                    if (Asas.Info != null)
                    {
                        Military.Play();
                        MovePanel.SetActive(true);
                        MoveInt = 4;
                    }
                }
            }

        }
    }

    public void SoldierDemo()
    {
        page.click.Play();
        ChooseAsa.AsaInfo.Soldier -= (int)ValueDemo.value;
        demobilizationPanel.SetActive(false);
        Click = false;
    }

    public void SoldierMove()
    {
        page.click.Play();
        if (MoveInt == 1)
        {
            Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
            GameObject Obje = GameObject.Find("Asa " + Vk.x + " " + (Vk.y + 1));
            AsaScript Asas = Obje.GetComponent<AsaScript>();

            if (Asas.Info.CountryName == "Me")
            {
                Asas.AsaInfo.Soldier += (int)ValueMove.value;
                ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
            }
            if (Asas.Info.CountryName != "Me")
            {
                int CurrentSoldier = (int)ValueMove.value;

                if (CurrentSoldier - Asas.AsaInfo.Soldier > 0)
                {
                    Country.Conquer(Asas);
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier = CurrentSoldier - Asas.AsaInfo.Soldier;
                }
                else
                {
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier -= CurrentSoldier;
                }
            }
        }

        if (MoveInt == 2)
        {
            Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
            GameObject Obje = GameObject.Find("Asa " + Vk.x + " " + (Vk.y - 1));
            AsaScript Asas = Obje.GetComponent<AsaScript>();

            if (Asas.Info.CountryName == "Me")
            {
                Asas.AsaInfo.Soldier += (int)ValueMove.value;
                ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
            }
            if (Asas.Info.CountryName != "Me")
            {
                int CurrentSoldier = (int)ValueMove.value;

                if (CurrentSoldier - Asas.AsaInfo.Soldier > 0)
                {
                    Country.Conquer(Asas);
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier = CurrentSoldier - Asas.AsaInfo.Soldier;
                }
                else
                {
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier -= CurrentSoldier;
                }
            }
        }

        if (MoveInt == 3)
        {
            Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
            GameObject Obje = GameObject.Find("Asa " + (Vk.x + 1) + " " + Vk.y);
            AsaScript Asas = Obje.GetComponent<AsaScript>();

            if (Asas.Info.CountryName == "Me")
            {
                Asas.AsaInfo.Soldier += (int)ValueMove.value;
                ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
            }
            if (Asas.Info.CountryName != "Me")
            {
                int CurrentSoldier = (int)ValueMove.value;

                if (CurrentSoldier - Asas.AsaInfo.Soldier > 0)
                {
                    Country.Conquer(Asas);
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier = CurrentSoldier - Asas.AsaInfo.Soldier;
                }
                else
                {
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier -= CurrentSoldier;
                }
            }
        }

        if (MoveInt == 4)
        {
            Vector2 Vk = new Vector2(ChooseAsa.item.X, ChooseAsa.item.Y);
            GameObject Obje = GameObject.Find("Asa " + (Vk.x - 1) + " " + Vk.y);
            AsaScript Asas = Obje.GetComponent<AsaScript>();

            if (Asas.Info.CountryName == "Me")
            {
                Asas.AsaInfo.Soldier += (int)ValueMove.value;
                ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
            }
            if (Asas.Info.CountryName != "Me")
            {
                int CurrentSoldier = (int)ValueMove.value;

                if (CurrentSoldier - Asas.AsaInfo.Soldier > 0)
                {
                    Country.Conquer(Asas);
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier = CurrentSoldier - Asas.AsaInfo.Soldier;
                }
                else
                {
                    ChooseAsa.AsaInfo.Soldier -= (int)ValueMove.value;
                    Asas.AsaInfo.Soldier -= CurrentSoldier;
                }
            }
        }
        MovePanel.SetActive(false);
        Click = true;
    }

    public void TrainSoldier()
    {
        page.click.Play();
        ArmyPanel.SetActive(true);
        ValueArmy.maxValue = ChooseAsa.AsaInfo.Population;
    }

    public void TerritoryInfo()
    {
        InfoPanel.SetActive(true);
        WoodI.text = ChooseAsa.WoodP.ToString();
        FoodI.text = ChooseAsa.PatatoP.ToString();
        StoneI.text = ChooseAsa.StoneP.ToString();
        IronI.text = ChooseAsa.IronP.ToString();

        HomeI.text = ChooseAsa.AsaInfo.Home.ToString();
        CastleI.text = ChooseAsa.AsaInfo.Castle.ToString();
        BarracksI.text = ChooseAsa.AsaInfo.Barracks.ToString();
        SearchI.text = ChooseAsa.AsaInfo.Search.ToString();
        PopuI.text = ChooseAsa.AsaInfo.Population.ToString();

        if(ChooseAsa.AsaInfo.Barracks != 0)
        {
            SoldierB.SetActive(true);
        }
        else
        {
            SoldierB.SetActive(false);
        }

        if (ChooseAsa.LandType == 0)
        {
            TType.text = "Plain";
        }
        if (ChooseAsa.LandType == 1)
        {
            TType.text = "Forest";
        }
        if (ChooseAsa.LandType == 5)
        {
            TType.text = "Sea";
        }
    }

    public void CreateAsa()
    {
        float x, z;

        for (int i = 0; i < GInfo.Size; i++)
        {
            x = i;
            z = x / 2;

            for (int j = 0; j < GInfo.Size; j++)
            {
                int maxY = (int)(Mathf.PerlinNoise((i + seed) / GInfo.Detail, (j + seed) / GInfo.Detail) * Size_Y);
                int maxYZ = (int)(Mathf.PerlinNoise((i + seed) / td2, (j + seed) / td2) * Size_Y);

                float x2 = j + x;
                float z2 = z - (0.5f * j);

                GameObject Obje = Instantiate(Asa, new Vector2(x2, z2), Quaternion.identity, gameObject.transform);
                Obje.name = "Asa " + i + " " + j;
                AsaScript Asas = Obje.GetComponent<AsaScript>();
                All_Asa.Add(Obje);
                Asas.item.X = i;
                Asas.item.Y = j;

                if (maxY > 10)
                {
                    Asas.LandType = 1;
                }
                if(maxY > 5 && maxY < 10 && maxYZ > 10)
                {
                    Asas.LandType = 3;
                }
                if (maxY < 5)
                {
                    Asas.LandType = 5;
                }

                if(Asas.LandType == 0)
                {
                    Starter_Asa.Add(Obje);
                }
            }
        }
        Manager.Establish_Game();
    }

    public void WarnPanel(NeededInfo Info)
    {
        Warn.SetActive(true);
        WoodW.text = Info.Wood.ToString();
        StoneW.text = Info.Stone.ToString();
        FoodW.text = Info.Food.ToString();
        IronW.text = Info.Iron.ToString();
    }

    public void SearchPanel(int Info)
    {
        SearhWarn.SetActive(true);
        SearchW.text = Info.ToString();
    }
}

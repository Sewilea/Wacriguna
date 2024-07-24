using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsaScript : MonoBehaviour
{
    public AsaItem item;
    public SpriteRenderer rd, rd2, rd3, rd4, rd5, choose;
    public Sprite[] LandSprite, DecorSprite;
    public int LandType;
    public CountryInfo Info;
    public GameObject CountryGameObject;
    public Country Coun;
    public AsaInfo AsaInfo;
    World world;
    public Text ArmyT;
    public GameObject Army;

    [Header("Source")]
    public float StoneP;
    public float WoodP;
    public float IronP;
    public float PatatoP;
    public float GoldP;

    public bool AIControl;


    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        Coun = GameObject.Find("_Script").GetComponent<Country>();
        SourceCreate();
    }

    void Update()
    {

        rd.sprite = LandSprite[LandType];

        if(Info != null)
        {
            rd2.gameObject.SetActive(true);
            rd2.color = Info.Color;

            if(AsaInfo.Capital == 1)
            {
                rd4.gameObject.SetActive(true);
                rd5.color = Info.Color;
            }

            if(AsaInfo.Soldier > 0)
            {
                Army.SetActive(true);
                ArmyT.text = AsaInfo.Soldier.ToString();
            }
            else
            {
                Army.SetActive(false);
            }
        }
        else
        {
            rd2.gameObject.SetActive(false);
            rd4.gameObject.SetActive(false);
            Army.SetActive(false);
        }

        if(world.ChooseAsa != null)
        {
            if (world.ChooseAsa.gameObject == gameObject)
            {
                choose.gameObject.SetActive(true);
            }
            else
            {
                choose.gameObject.SetActive(false);
            }
        }

        if(Info != null)
        {
            if (world.Time1 && Info.CountryName == "Me")
            {
                Coun.WoodF += ((WoodP / 10) + (AsaInfo.Population / 10) + (Coun.Axe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Coun.PatatoF += ((PatatoP / 20) + (AsaInfo.Population / 10) + (Coun.Hoe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Coun.StoneF += ((StoneP / 20) + (AsaInfo.Population / 10) + (Coun.Picaxe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Coun.IronF += ((IronP / 20) + (AsaInfo.Population / 10) + (Coun.Picaxe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Coun.SearchF += (AsaInfo.Search / 10) * Time.deltaTime;
            }
            if (world.Time1 && Info.CountryName != "Me")
            {
                OtherCountries Count = CountryGameObject.GetComponent<OtherCountries>();

                Count.WoodF += ((WoodP / 10) + (AsaInfo.Population / 10) + (Count.Axe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Count.PatatoF += ((PatatoP / 20) + (AsaInfo.Population / 10) + (Count.Hoe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Count.StoneF += ((StoneP / 20) + (AsaInfo.Population / 10) + (Count.Picaxe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Count.IronF += ((IronP / 20) + (AsaInfo.Population / 10) + (Count.Picaxe / 10) - (AsaInfo.Soldier / 10)) * Time.deltaTime;
                Count.SearchF += (AsaInfo.Search / 10) * Time.deltaTime;
            }
        }

     

        /*
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, 100f))
            {
                if(hit.transform != null)
                {
                    if (hit.transform == gameObject.transform)
                    {
                        world.ChooseAsa = gameObject.GetComponent<AsaScript>();
                        world.LandPanel.SetActive(true);
                    }
                }
            }

        }*/
    }

    public void SourceCreate()
    {
        if(LandType != 5)
        {
            if(LandType == 0)
            {
                StoneP = Random.Range(1, 20);
                WoodP = Random.Range(1, 20);
                IronP = Random.Range(1, 6);
                PatatoP = Random.Range(1, 20);
                GoldP = Random.Range(1, 10);
                AsaInfo.Population = Random.Range(8, 20);
            }
            if(LandType == 1)
            {
                StoneP = Random.Range(1, 20);
                WoodP = Random.Range(1, 25);
                IronP = Random.Range(1, 6);
                PatatoP = Random.Range(1, 20);
                GoldP = Random.Range(1, 10);
                AsaInfo.Population = Random.Range(8, 20);
            }
            if (LandType == 3)
            {
                StoneP = Random.Range(1, 25);
                WoodP = Random.Range(1, 5);
                IronP = Random.Range(1, 10);
                PatatoP = Random.Range(1, 5);
                GoldP = Random.Range(1, 15);
                AsaInfo.Population = Random.Range(4, 10);
            }
        }

        if (LandType != 5)
        {
            if(LandType == 3)
            {
                int a = Random.Range(0, 2);

                if(a == 1)
                {
                    rd3.gameObject.SetActive(true);
                    rd3.sprite = DecorSprite[5];
                }
            }

            if (LandType == 1)
            {
                int a = Random.Range(0, 3);

                if (a < 2)
                {
                    rd3.gameObject.SetActive(true);
                    rd3.sprite = DecorSprite[a];
                }
            }

            if (LandType == 0)
            {
                int b = Random.Range(0, 15);

                if (b < DecorSprite.Length)
                {
                    rd3.gameObject.SetActive(true);
                    rd3.sprite = DecorSprite[b];
                }
            }

            
        }
    }

    private void OnMouseDown()
    {
        /*
        if (world.Click)
        {
            //Debug.Log(item.X + " " + item.Y);
            world.ChooseAsa = gameObject.GetComponent<AsaScript>();
            world.TerritoryInfo();

            if(Info != null)
            {
                if(Info.CountryName == "Me")
                {
                    world.Your.SetActive(true);
                    world.Yournot.SetActive(false);
                }
                else
                {
                    world.Your.SetActive(false);
                    world.Yournot.SetActive(true);
                    world.ConquerB.SetActive(false);
                }
            }
            else
            {
                world.Your.SetActive(false);
                world.Yournot.SetActive(true);
                world.ConquerB.SetActive(true);
            }
        }
        */
    }
}

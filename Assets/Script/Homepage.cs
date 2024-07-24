using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Homepage : MonoBehaviour
{
    public Manager Man;
    public GameObject AraMenü, ConsoleObject, Victory;
    public bool AraMenüb, Consoleb;
    public AudioSource sc, click;
    public Camera cam;
    public float wx;

    [Header("Settings")]
    public KeyCode Menu_code, Console_code;

    [Header("Panels")]
    public World world;
    public Image ClockI;

    public Text ScaleT;
    public int Scale;

    private void Start()
    {
        sc.Play();
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        ScaleT.text = Scale.ToString();
        Time.timeScale = Scale;

        if (Man.Victory)
        {
            Victory.SetActive(true);
        }
        // Application.OpenURL(url);

        if (Input.GetKeyDown(Menu_code))
        {
            AraMenüb = !AraMenüb;
            world.Click = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            world.Time1 = !world.Time1;
        }

        AraMenü.SetActive(AraMenüb);

        if (Input.GetKeyDown(Console_code))
        {
            Consoleb = !Consoleb;
        }

        ConsoleObject.SetActive(Consoleb);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && wx > 1)
        {
            wx -= 0.5f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && wx < 8)
        {
            wx += 0.5f;
        }

        cam.orthographicSize = wx;

        if (world.Time1)
        {
            ClockI.color = Color.white;
        }
        if (!world.Time1)
        {
            ClockI.color = Color.red;
        }
    }

    public void ScaleChange(int a)
    {
        Scale += a;
        if(Scale < 0)
        {
            Scale = 0;
        }
        if(Scale > 10)
        {
            Scale = 10;
        } 
    }

    public void TimeStop()
    {
        world.Time1 = !world.Time1;
    }

    public void _continue()
    {
        AraMenüb = !AraMenüb;
        world.Click = true;
    }

    public void _Back_to_menu()
    {
       
    }

    public void OpenPanel(GameObject Object)
    {
        Object.SetActive(true);
       
    }

    public void ClosePanel(GameObject Object)
    {
        Object.SetActive(false);
        world.Click = true;

    }

    public void OpenChrome(string Irl)
    {
        Application.OpenURL(Irl);
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;



public class HandsUp : MonoBehaviour
{
    public static bool AllAttachedBool = false;
    public static bool Magenta1 = false;
    public static bool Magenta2 = false;
    public static bool Magenta3 = false;
    public static bool Magenta4 = false;
    public static bool Red1 = false;
    public static bool Red2 = false;
    public static bool Red3 = false;
    public static bool Red4 = false;
    public static bool Blue1 = false;
    public static bool Blue2 = false;
    public static bool Blue3 = false;
    public static bool Blue4 = false;
    public static bool Green = false;


    private GameObject goNextHouse;
    private GameObject goNextRobot;
    private GameObject goNextSofa;



    public static bool left = false;
    public static bool right = false;

    private GameObject go;
    private GameObject goTimerHouse;
    private GameObject goTimerRobot;
    private GameObject goTimerSofa;
    private GameObject goTimerTotal;

    public float timer;
    public static string strHouse;
    public static string strRobot;
    public static string strSofa;
    public static string strTotal;
    public static TimeSpan timespanHouse;
    public static TimeSpan timespanRobot;
    public static TimeSpan timespanSofa;
    public static TimeSpan timespanTotal;

    // Use this for initialization
    void Start () {
		go = GameObject.FindWithTag("panel");

        goNextHouse = GameObject.FindWithTag("houseNext");
        goNextRobot = GameObject.FindWithTag("robotNext");
        goNextSofa = GameObject.FindWithTag("sofaNext");

        goTimerHouse = GameObject.FindWithTag("houseTimer");
        goTimerRobot = GameObject.FindWithTag("robotTimer");
        goTimerSofa = GameObject.FindWithTag("sofaTimer");
        goTimerTotal = GameObject.FindWithTag("totalTime");

        timer = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        NoGravity();
        allAttached();
    }

   
    public void leftHandUp()
    {
        left = true;
       // Debug.Log("leftHand var is up " + left.ToString());
    }
    public void rightHandUp()
    {
       right = true;
       // Debug.Log("rightHand var is up " + right.ToString());
    }

    public void leftHandDown()
    {
        left = false;
       // Debug.Log("leftHand var is down " + left.ToString());
    }
    public void rightHandDown()
    {
        right = false;
       // Debug.Log("rightHand var is down " + right.ToString());
    }

    public void NoGravity()
    {
        if (left == true && right == true)
        {
             if (AllAttachedBool)
            {
                go.transform.rotation = Quaternion.Euler(90f, 90 * Mathf.Sin(Time.time * 2),  0f);
            //go.transform.position = new Vector3(transform.position.x, 2, transform.position.z);
                 }

        }
    }

    public void allAttached()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "AVRHouse")
        {
            if (Magenta1 && Magenta2 && Magenta3 && Magenta4 && Red1 && Red2 && Blue1 && Blue2 && Green)
            {
                AllAttachedBool = true;
                goNextHouse.SetActive(true);

            }
            else
            {
                AllAttachedBool = false;
                timespanHouse = TimeSpan.FromSeconds(Math.Round(Time.time - timer));
                strHouse = "elapsed time" + System.Environment.NewLine + "   " + timespanHouse.ToString();
                goTimerHouse.GetComponent<TextMesh>().text = strHouse;
                goNextHouse.SetActive(false);
            }
        }
        else if (scene.name == "AVRRobot")
        {
            if (Magenta1 && Magenta2 && Magenta3 && Red1 && Red2 && Blue1 && Blue2 && Green)
            {
                AllAttachedBool = true;
                goNextRobot.SetActive(true);
            }
            else
            {
                AllAttachedBool = false;
                timespanRobot = TimeSpan.FromSeconds(Math.Round(Time.time - timer));
                strRobot = "elapsed time" + System.Environment.NewLine + "   " + timespanRobot.ToString();
                goTimerRobot.GetComponent<TextMesh>().text = strRobot;
                goNextRobot.SetActive(false);
            }
        }
        else if (scene.name == "AVRFurniture")
        {
            if (Magenta1 && Magenta2 && Magenta3 && Magenta4 && Red1 && Red2 && Red3 && Red4 && Blue1 && Blue2 && Blue3 && Blue4)
            {
                AllAttachedBool = true;
                goNextSofa.SetActive(true);
            }
            else
            {
                AllAttachedBool = false;
                timespanSofa = TimeSpan.FromSeconds(Math.Round(Time.time - timer));
                strSofa = "elapsed time" + System.Environment.NewLine + "   " + timespanSofa.ToString();
                goTimerSofa.GetComponent<TextMesh>().text = strSofa;
                goNextSofa.SetActive(false);
            }
        }
        else if (scene.name == "AVRLast")
        {

                timespanTotal = timespanHouse + timespanRobot + timespanSofa;
                strTotal = timespanTotal.ToString();
                goTimerTotal.GetComponent<TextMesh>().text = "House " + strHouse + System.Environment.NewLine+ "Robot " + strRobot + System.Environment.NewLine+ "Sofa " + strSofa + System.Environment.NewLine + "Total Time is " +strTotal;

               
        }

    }

   
}

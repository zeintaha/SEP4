using Leap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using Leap.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Hand = Valve.VR.InteractionSystem.Hand;

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



    public static bool leftUp = false;
    public static bool leftDown = false;
    public static bool LeftRight = false;
    public static bool LeftLeft = false;
    public static bool LeftBack = false;
    public static bool LeftForth = false;



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

    public GameObject myPrefabObject;
    public GameObject myPrefabObject2;
    //public GameObject myPrefabObject2;
    public float spawnDistance = 10;
    public Transform maincam;
    public float timerx;
    

    // Use this for initialization
    void Start () {
        //go = GameObject.FindWithTag("panel");

        //goNextHouse = GameObject.FindWithTag("houseNext");
        //goNextRobot = GameObject.FindWithTag("robotNext");
        //goNextSofa = GameObject.FindWithTag("sofaNext");

        //goTimerHouse = GameObject.FindWithTag("houseTimer");
        //goTimerRobot = GameObject.FindWithTag("robotTimer");
        //goTimerSofa = GameObject.FindWithTag("sofaTimer");
        //goTimerTotal = GameObject.FindWithTag("totalTime");

        //timer = Time.time;
       
        
        
       
        maincam = GameObject.Find("Main Camera").GetComponent<Transform>();

        //holoBrickPos = maincam.TransformDirection(Vector3.forward)*10;

        holoBrickPos = new Vector3(0.0f,3.0f,4.0f);
    }
	
	// Update is called once per frame
    
    
	void Update ()
    {
        //NoGravity();
        timerx -= 1.0f;
        if (timerx == 1)
        {
            timerx = 20.0f;
            UpDown();
            RightLeft();
            BackForth();
        }

        InstBrickRight();

    }

   
    public void leftHandUpTrue()
    {
        leftUp = true;
       // Debug.Log("leftHand var is up " + left.ToString());
    }
    public void leftHandUpFalse()
    {
        leftUp = false;
        // Debug.Log("leftHand var is up " + left.ToString());
    }

    public void leftHandDownTrue()
    {
        leftDown = true;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    public void leftHandDownFalse()
    {
        leftDown = false;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    //-------------------------------------------------

    public void leftHandRighTrue()
    {
        LeftRight = true;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    public void leftHandRighFalse()
    {
        LeftRight = false;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    public void leftHandLeftTrue()
    {
        LeftLeft = true;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    public void leftHandLeftFalse()
    {
        LeftLeft = false;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    //--------------------------------------------------------------
    public void leftHandBackTrue()
    {
        LeftBack = true;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    public void leftHandBackFalse()
    {
        LeftBack = false;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    public void leftHandForthTrue()
    {
        LeftForth = true;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    public void leftHandForthFalse()
    {
        LeftForth = false;
        // Debug.Log("leftHand var is down " + left.ToString());
    }

    //-----------------------------------------------------------------
    public void rightHandUp()
    {
       right = true;
       // Debug.Log("rightHand var is up " + right.ToString());
    }

    public void leftHandDown()
    {
        //left = false;
       // Debug.Log("leftHand var is down " + left.ToString());
    }
    public void rightHandDown()
    {
        right = false;
       // Debug.Log("rightHand var is down " + right.ToString());
    }


    
    public void UpDown()
    {
        if (leftUp == true)
        {
            Debug.Log("leftUp == true");
            DistroyHoloBrick();
            UpHoloBrick();
        }


        if (leftDown == true)
        {
            Debug.Log("leftDown == true");
            DistroyHoloBrick();
            DwonHoloBrick();
        }
    }

    public void RightLeft()
    {
        if (LeftRight == true)
        {
           
            DistroyHoloBrick();
            RightHoloBrick();
        }


        if (LeftLeft == true)
        {
           Debug.Log("LeftLeft");
            DistroyHoloBrick();
            LeftHoloBrick();
        }
    }

    public void BackForth()
    {
        if (LeftForth == true)
        {

            DistroyHoloBrick();
            ForthHoloBrick();
        }


        if (LeftBack == true)
        {

            DistroyHoloBrick();
            BackHoloBrick();
        }
    }

    public bool flag = false;
    public void InstBrickRight()
    {
        if (right == true)
        {
            Instbrick();
            right = false;
        }


    }


    public GameObject instantiatedObj;
    public GameObject instantiatedObj2;
    public static Vector3 holoBrickPos;

    void UpHoloBrick()
    {
        instantiatedObj = (GameObject)Instantiate(myPrefabObject, holoBrickPos, Quaternion.identity);
        if (holoBrickPos.y < 20) {
        holoBrickPos = new Vector3(holoBrickPos.x, holoBrickPos.y+0.5f, holoBrickPos.z);
        }
    }

    void DwonHoloBrick()
    {
        instantiatedObj = (GameObject)Instantiate(myPrefabObject, holoBrickPos, Quaternion.identity);
        if (holoBrickPos.y > 0)
        {
            holoBrickPos = new Vector3(holoBrickPos.x, holoBrickPos.y - 0.5f, holoBrickPos.z);
        }
    }

       void RightHoloBrick()
    {
        instantiatedObj = (GameObject)Instantiate(myPrefabObject, holoBrickPos, Quaternion.identity);
        if (holoBrickPos.z < 20 )
        {
            holoBrickPos = new Vector3(holoBrickPos.x, holoBrickPos.y, holoBrickPos.z + 0.5f);
        }
    }
       void LeftHoloBrick()
       {
           instantiatedObj = (GameObject) Instantiate(myPrefabObject, holoBrickPos, Quaternion.identity);
           if (holoBrickPos.z > 4)
           {
               holoBrickPos = new Vector3(holoBrickPos.x, holoBrickPos.y, holoBrickPos.z - 0.5f);
           }
       }

       void ForthHoloBrick()
       {
           instantiatedObj = (GameObject)Instantiate(myPrefabObject, holoBrickPos, Quaternion.identity);
           if (holoBrickPos.x < 10)
           {
               holoBrickPos = new Vector3(holoBrickPos.x + 0.5f, holoBrickPos.y , holoBrickPos.z);
           }
       }

       void BackHoloBrick()
       {
           instantiatedObj = (GameObject)Instantiate(myPrefabObject, holoBrickPos, Quaternion.identity);
           if (holoBrickPos.x > -10)
           {
               holoBrickPos = new Vector3(holoBrickPos.x - 0.5f, holoBrickPos.y, holoBrickPos.z);
           }
       }

    void Instbrick()
    {
        instantiatedObj2 = (GameObject)Instantiate(myPrefabObject2, holoBrickPos, Quaternion.identity);
    }

    void DistroyHoloBrick()
    {
        Destroy(instantiatedObj);
    }

}

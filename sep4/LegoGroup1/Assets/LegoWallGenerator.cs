using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Timeline;

public class LegoWallGenerator : MonoBehaviour {

	
	void Start () {
	GameObject prefab = Resources.Load("m3003") as GameObject;
    
     for (int i=0; i < 10; i++)
     {
         for (int height = 0; height < 8; height++)
         {
             GameObject m3003 = Instantiate(prefab) as GameObject;
             float offset = height %2;
             m3003.transform.position= new Vector3(transform.position.x+i*2,
                                                    transform.position.y+height+0.5f,
                                                    transform.position.z );
         }
     }






    }
	
	void Update () {
		
	}
}

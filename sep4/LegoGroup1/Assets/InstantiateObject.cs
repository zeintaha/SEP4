using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour {

    public GameObject myPrefabObject = null;

    // Use this for initialization
    void Start () {
        Instantiate(myPrefabObject, transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

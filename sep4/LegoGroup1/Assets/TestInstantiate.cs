using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstantiate : MonoBehaviour
{

    public GameObject myPrefab = null;
	// Use this for initialization
	void Start ()
    {
        Instantiate(myPrefab, transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

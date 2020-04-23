using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnTrigger : MonoBehaviour
{

    public string tagFilter;


    void OnTriggerEnter(Collider other) // 1 
    {
	if (other.gameObject.CompareTag("DropSheep")) // 2 
	{
		
		Destroy(gameObject); // 3

	}    }


}

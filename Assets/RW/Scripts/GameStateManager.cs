using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector]
    public int sheepSaved; // 2

    [HideInInspector]
    public int sheepDropped; // 3

    public int sheepDroppedBeforeGameOver; // 4
    public SheepSpawner sheepSpawner; // 5 

    //Variables SheepDropped
    public Text sheepDroppedText;
    private int count_sheep;

   
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
       SetCountText ();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
	{
    		SceneManager.LoadScene("Title");
	}
    }

    public void SavedSheep()
    {
    	sheepSaved++;
    }

    private void GameOver()
    {
  	  sheepSpawner.canSpawn = false; // 1
  	  sheepSpawner.DestroyAllSheep(); // 2
    }

    public void DroppedSheep()
    {
   	sheepDropped++; // 1
	SetCountText ();
    	if (sheepDropped == sheepDroppedBeforeGameOver) // 2
    	{
            GameOver();
    	}
    }

    void SetCountText ()
    {
	sheepDroppedText.text = "Sheep Dropped: " + sheepDropped.ToString ();
    }

}

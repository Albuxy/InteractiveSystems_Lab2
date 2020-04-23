using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;

    //Variables Contador
    public Text countText;
    private int count;

    void Start()
    {
       count = 0;
       SetCountText ();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.x);
	UpdateMovement();
	UpdateShooting();
    }
    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
	
	if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 1 
	{
		transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
	}
	else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 2 
	{
		transform.Translate(transform.right * movementSpeed * Time.deltaTime);
	}
    }
    private void ShootHay() 
    {
	Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
	SoundManager.Instance.PlayShootClip();
    }
    private void UpdateShooting() 
    {
    	shootTimer -= Time.deltaTime;
	if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) 
	{
		count = count + 1;
		SetCountText ();
		shootTimer = shootInterval;
		ShootHay(); 
        }
    }
    void SetCountText ()
    {
	countText.text = "Hay Throwed: " + count.ToString ();
    }


}

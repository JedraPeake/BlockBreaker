﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public static int brickNumber;
	public AudioClip crack;
	public GameObject smoke;
		
	private int maxHits;
	private int timesHit;
	private LevelManager levelmanager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () 
	{
		isBreakable =(this.tag == "Breakable");
		if(isBreakable)
		{
			brickNumber++;
		}
		timesHit=0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D col)
	{	
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);
		if(isBreakable)
		{
			HandleHits();
		}
		
	}
	
	void HandleHits()
	{
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if(timesHit>=maxHits)
		{
			brickNumber--;
			levelmanager.BrickDestroyed();
			Destroy(gameObject);
			PuffSmoke();
		}
		else
		{
			LoadSprites();
		}
	}
	
	void LoadSprites()
	{
		int spriteIndex= timesHit-1;
		if(hitSprites[spriteIndex]!=null)
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else{
		Debug.LogError("Brick sprite missing");
		}
	}
	//TODO remove this method once we can win
	
	void simulateWin()
	{
		levelmanager.LoadNextLevel();
	}
	
	void PuffSmoke () {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
}

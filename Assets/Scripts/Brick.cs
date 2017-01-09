using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int maxHits;
	private int timesHit;
	public Sprite[] hitSprites;
	public static int brickNumber;
	private LevelManager levelmanager;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
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
	
	void OnCollisionEnter2D(Collision2D col){
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
		}
		else
		{
			LoadSprites();
		}
	}
	
	void LoadSprites()
	{
		int spriteIndex= timesHit-1;
		if(hitSprites[spriteIndex])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	//TODO remove this method once we can win
	
	void simulateWin()
	{
		levelmanager.LoadNextLevel();
	}
	
}

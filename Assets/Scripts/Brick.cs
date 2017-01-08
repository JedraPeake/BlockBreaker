using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;
	public Sprite[] hitSprites;
	private LevelManager levelmanager;
	// Use this for initialization
	void Start () {
		timesHit=0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D col){
		timesHit++;
		if(timesHit>=maxHits)
		{
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
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
	//TODO remove this method once we can win
	
	void simulateWin()
	{
		levelmanager.LoadNextLevel();
	}
	
}

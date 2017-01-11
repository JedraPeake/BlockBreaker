 using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
	{
		Debug.Log("Level load requested for: "+name);
		Brick.brickNumber=0;
		Application.LoadLevel(name);
	}
	
	public void QuitRequest()
	{
		Debug.Log("Quit requested");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{
		Brick.brickNumber=0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed()
	{
		if(Brick.brickNumber <= 0)
		{
			LoadNextLevel();
		}
	}
}

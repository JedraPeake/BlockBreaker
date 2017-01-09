using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoplay =false;
	
	private Ball ball;
	
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}	
	// Update is called once per frame
	void Update () 
	{
		if(!autoplay)
		{
			moveWithMouse();	
		}
		else{
			autoPlay();
		}
	}
	
	void autoPlay()
	{
		Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y , 0f);
		Vector3 position = ball.transform.position;
		paddlePosition.x=Mathf.Clamp(position.x,0.5f,15.5f);
		this.transform.position = paddlePosition;
	}
	
	void moveWithMouse()
	{
		Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y , 0f);
		float position = Input.mousePosition.x / Screen.width * 16;
		paddlePosition.x=Mathf.Clamp(position,0.5f,15.5f);
		this.transform.position = paddlePosition;
	}
}

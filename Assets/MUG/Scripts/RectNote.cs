using UnityEngine;
using System.Collections;

public class RectNote : Note {
	public Note endNote,headNote;
	public bool isPressed;
	public float temp;
	// Use this for initialization
	void Start () {
		isPressed=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isPressed)
		{
			temp=this.transform.localScale.y-speed*Time.deltaTime;
			this.transform.localScale=new Vector3(this.transform.localScale.x,temp,this.transform.localScale.z);

		}else{
			this.transform.Translate(new Vector2(0,-1*speed*Time.deltaTime));
		}
		if(this.transform.localScale.y<0)
		{
			Destroy(this.gameObject);
		}
	}
}

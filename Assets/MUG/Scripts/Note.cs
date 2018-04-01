using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public FlashController flash;
	public float speed;
	public RectNote pre;
	public bool isFlashing=false;
	public int Side{get;set;}
	public int Type{get;set;}
	// Use this for initialization
	void Start () {
		//isFlashing=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFlashing)
		{
			flash.OneShine();
		}
		this.transform.Translate(new Vector3(0,-1*speed*Time.deltaTime,0));
	}
}

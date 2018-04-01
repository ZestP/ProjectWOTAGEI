using UnityEngine;
using System.Collections;

public class RectRemover : MonoBehaviour {
	public myUGUI l;
	// Use this for initialization
	void Start () {
		l=GameObject.Find("HUD").GetComponent<myUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit2D(Collider2D other)
	{
		//Debug.Log("Enter");
		if(other.gameObject.tag=="Rect")
		{
			Destroy(other.gameObject);
			l.setStr("Miss");
		}
	}
}

using UnityEngine;
using System.Collections;

public class NoteRemover : MonoBehaviour {
	public myUGUI l;
	// Use this for initialization
	void Start () {
		l=GameObject.Find("HUD").GetComponent<myUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider other)
	{
		//Debug.Log("Enter");
		if(other.gameObject.tag=="Note")
		{
			RectNote r=other.gameObject.GetComponent<Note>().pre;
			if(r!=null)
			{
				//Debug.Log("HEREDESTRO");
				Destroy(r.endNote.gameObject);
				Destroy(r.gameObject);
			}
			Destroy(other.gameObject);
			l.setStr("Miss");
		}
	}
}

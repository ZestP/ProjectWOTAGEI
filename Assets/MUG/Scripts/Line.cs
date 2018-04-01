using UnityEngine;
using System.Collections;
public enum State
{
	down,up,swipe
}
public class Line : MonoBehaviour {
	public FlashController flash;
	public bool isStateChanged;
	public State mState;
	public myUGUI l;
	public string str;
	public int score;
	public GameObject r;
	public bool isEnter;
	// Use this for initialization
	void Start () {
		mState=State.down;
		isStateChanged=false;
		score=0;
		isEnter=false;
		l=GameObject.Find("HUD").GetComponent<myUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setState(State s)
	{
		mState=s;
		isStateChanged=true;
		//Debug.Log("Set"+mState);
	}
	void OnTriggerStay(Collider other)
	{
		if(isStateChanged)
		{
			//Debug.Log("Stay");
			if(other.gameObject.tag=="Note")
			{
				int tType=other.gameObject.GetComponent<Note>().Type;
				//Debug.Log(tType);
				if(mState==State.down)
				{
					float dy=Mathf.Abs(other.gameObject.transform.position.y-this.transform.position.y);
					//Debug.Log(dy);
					if(dy<0.3f)
					{
						str="Perfect";
						score=100;
					}else if(dy<0.5f)
					{
						str="Great";
						score=80;
					}else if(dy<1.0f)
					{
						str="Good";
						score=40;
					}else{
						str="Bad";
						score=20;
					}

					l.setStr(str);

					l.setScore(score);
					flash.Shine();
					Destroy(other.gameObject);
					isEnter=false;

				}else if(mState==State.up){
					if(tType==3)
					{
						float dy=Mathf.Abs(other.gameObject.transform.position.y-this.transform.position.y);
						//Debug.Log(dy);
						if(dy<0.3f)
						{
							str="Perfect";
							score=100;
						}else if(dy<0.5f)
						{
							str="Great";
							score=80;
						}else if(dy<1.0f)
						{
							str="Good";
							score=40;
						}else{
							str="Bad";
							score=20;
						}
						l.setStr(str);

						l.setScore(score);
						flash.Shine();
						GameObject pre;
						if(other.gameObject.GetComponent<Note>().pre!=null)
						{
							pre=other.gameObject.GetComponent<Note>().pre.gameObject;
							Destroy(pre);
						}	
						//Debug.Log("HERE DESTROYS PRE");
						Destroy(other.gameObject);
						isEnter=false;
					}
				}
			}
			isStateChanged=false;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		isEnter=true;
	}
	void OnTriggerExit(Collider other)
	{
		isEnter=false;
	}
}

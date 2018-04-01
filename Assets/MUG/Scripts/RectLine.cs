using UnityEngine;
using System.Collections;

public class RectLine : MonoBehaviour {
	public FlashController flash;
	public bool isStateChanged;
	public State mState;
	public myUGUI l;
	public string str;
	public int score;
	public GameObject r;
	public RectNote re;
	public Line noteLine;
	// Use this for initialization
	void Start () {
		mState=State.up;
		isStateChanged=false;
		score=0;
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
			if(other.gameObject.tag=="Rect"&&mState==State.up&&!noteLine.isEnter)
			{
				Destroy(r.GetComponent<RectNote>().endNote.gameObject);
				Destroy(r);
				str="Miss";
				l.setStr(str);
				//Debug.Log("UP");
			}
			isStateChanged=false;
			flash.OffFlashing();
		}
		if(other.gameObject.tag=="Rect")
		{
			if(mState==State.down&&re.headNote==null)
			{
				if(!re.isPressed)
				{
					re.isPressed=true;
					r.transform.position=new Vector3(r.transform.position.x,this.transform.position.y,this.transform.position.z);
					r.transform.localScale=new Vector3(r.transform.localScale.x,-this.transform.position.y+re.endNote.transform.position.y,r.transform.localScale.z);
				}
				l.setScore((int)(Time.deltaTime*100));
				flash.OnFlashing();
				//Debug.Log(r.transform.localScale.y);
			}

		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Rect")
		{
			r=other.gameObject;
			re=r.GetComponent<RectNote>();

		}
	}
}

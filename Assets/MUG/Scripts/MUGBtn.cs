using UnityEngine;
using System.Collections;

public class MUGBtn : MonoBehaviour {
	public int type;
	public Line m_line;
	public RectLine m_rectLine;
	public int curFrame,curFingerID;
	public SpriteRenderer mat;
	public Camera UICam;
	public myUGUI l;
	public string str;
	public int btnTag;
	// Use this for initialization
	void Start () {
		Input.multiTouchEnabled=true;
		mat=this.GetComponent<SpriteRenderer>();
		mat.enabled=false;
		UICam=GameObject.Find("UICam").GetComponent<Camera>();
		l=GameObject.Find("HUD").GetComponent<myUGUI>();
//		curFrame=-1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0)
		{
			str="";
			str+=Input.touchCount;
			str+=" ";

			foreach(Touch touch in Input.touches)
			{
				str=str+touch.position+" "+touch.phase+" "+touch.fingerId+"\n";

				if(touch.phase==TouchPhase.Began)
				{
					if(!this.mat.enabled&&CheckTouch(touch.position))
					{
						curFingerID=touch.fingerId;
						mat.enabled=true;
						m_line.setState(State.down);
						m_rectLine.setState(State.down);

					}
				}else if(this.mat.enabled&&(touch.phase==TouchPhase.Ended||touch.phase==TouchPhase.Canceled)){
					if(touch.fingerId==curFingerID)
					{
						mat.enabled=false;
						m_line.setState(State.up);
						m_rectLine.setState(State.up);
						break;
					}
				}
			}

		}else{
			str="0";
		}
		//l.setInfo(str);



		//l.SendMessage("setInfo",str);
//		if(Input.GetMouseButtonDown(0))
//		{
//			CheckTouch(Input.mousePosition);
//		}
//		if(Input.GetMouseButtonUp(0))
//		{
//			
//		}
//		if(type==1)
//		{
//		if(Input.GetKeyDown("z"))
//		{
//			m_line.SendMessage("setState",true);
//		}
//		if(Input.GetKeyUp("z"))
//		{
//			m_line.SendMessage("setState",false);
//		}
//		}else if(type==2)
//		{
//			if(Input.GetKeyDown("x"))
//			{
//				m_line.SendMessage("setState",true);
//			}
//			if(Input.GetKeyUp("x"))
//			{
//				m_line.SendMessage("setState",false);
//			}	
//		}

//KEYBOARD METHODS
		if(btnTag==0)
		{
			if(Input.GetKeyDown("z"))
			{
				//Debug.Log("Z");
				mat.enabled=true;
				m_line.SendMessage("setState",State.down);
				m_rectLine.SendMessage("setState",State.down);

			}
			if(Input.GetKeyUp("z"))
			{
				mat.enabled=false;
				m_line.SendMessage("setState",State.up);
				m_rectLine.SendMessage("setState",State.up);
			}
		}else if(btnTag==1){
			if(Input.GetKeyDown("x"))
			{
				mat.enabled=true;
				m_line.SendMessage("setState",State.down);
				m_rectLine.SendMessage("setState",State.down);
			}
			if(Input.GetKeyUp("x"))
			{
				mat.enabled=false;
				m_line.SendMessage("setState",State.up);
				m_rectLine.SendMessage("setState",State.up);
			}
		}else if(btnTag==2){
			if(Input.GetKeyDown("n"))
			{
				mat.enabled=true;
				m_line.SendMessage("setState",State.down);
				m_rectLine.SendMessage("setState",State.down);
			}
			if(Input.GetKeyUp("n"))
			{
				mat.enabled=false;
				m_line.SendMessage("setState",State.up);
				m_rectLine.SendMessage("setState",State.up);
			}
		}else if(btnTag==3){
			if(Input.GetKeyDown("m"))
			{
				mat.enabled=true;
				m_line.SendMessage("setState",State.down);
				m_rectLine.SendMessage("setState",State.down);
			}
			if(Input.GetKeyUp("m"))
			{
				mat.enabled=false;
				m_line.SendMessage("setState",State.up);
				m_rectLine.SendMessage("setState",State.up);
			}
		}
//		if(curFrame>=100)
//		{
//			curFrame=-1;
//		}else if(curFrame>=0){
//			curFrame++;
//		}
	}
	bool CheckTouch(Vector3 pos)
	{
		Ray ray=UICam.ScreenPointToRay(pos);

		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity,1<<5))
		{
			//Debug.DrawLine(ray.origin,hit.point,Color.green);
//			Debug.Log(hit.collider.name);
			//Debug.Log(this.name);
			//Debug.Log(type);
			if(hit.collider.gameObject.Equals(this.gameObject))
			{return true;}else{return false;}
			//this.transform.Translate(new Vector2(1,0));
		}else{
			return false;
		}
	}
}

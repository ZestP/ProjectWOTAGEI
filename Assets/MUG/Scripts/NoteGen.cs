using UnityEngine;
using System.Collections;
//public enum TNote:int
//{
//	note,swipe,bar
//}
public class NoteGen : MonoBehaviour {
	public Transform Gen,fac;
	public Note sub,sub2,oriNote;
	public RectNote sub3,oriRect;
	public float speed;
	void Start()
	{
		fac=this.transform.parent.GetComponentInParent<Transform>();
	}
	public bool genNote(int t,bool isFlashing)
	{
		if(t==0)
		{
			sub=Instantiate(oriNote,Gen.position,Gen.rotation) as Note;
			//Debug.Log(Gen.position);
			sub.Type=1;
			sub.transform.localScale=fac.localScale;
			sub.speed=speed*fac.localScale.y;
			if(isFlashing)
			{
				sub.isFlashing=true;
			}
			return true;
		}else if(t==2)
		{
			//TODO:swipe
			return true;
		}else{
			return false;
		}
	}
	public void hello()
	{
		Debug.Log("Hello"+this.transform.parent.name);
	}
	public bool genNote(int t,float dt,bool isFlashing)
	{
		if(t==1)
		{
			sub=Instantiate(oriNote) as Note;
			sub2=Instantiate(oriNote) as Note;
			sub3=Instantiate(oriRect) as RectNote;
			sub.transform.localScale=fac.localScale;
			sub2.transform.localScale=fac.localScale;
			sub3.transform.localScale=fac.localScale;
			sub3.transform.localScale=new Vector3(sub3.transform.localScale.x,sub3.transform.localScale.y*speed*dt,sub3.transform.localScale.z);
			sub.transform.position=Gen.position;
			sub.transform.RotateAround(sub.transform.position,Vector3.forward,fac.localEulerAngles.z);
			sub2.transform.position=Gen.position;
			sub2.transform.Translate(new Vector3(0,sub3.transform.localScale.y,0));
			sub2.transform.RotateAround(sub.transform.position,Vector3.forward,fac.localEulerAngles.z);
			sub3.transform.position=Gen.position;
			sub3.transform.RotateAround(sub.transform.position,Vector3.forward,fac.localEulerAngles.z);
			sub.Type=2;
			sub2.Type=3;
			sub3.endNote=sub2;
			sub2.pre=sub3;
			sub.pre=sub3;
			sub.speed=speed*fac.localScale.y;
			sub2.speed=speed*fac.localScale.y;
			sub3.speed=speed*fac.localScale.y;
			if(isFlashing)
			{
				sub.isFlashing=true;
				sub2.isFlashing=true;
			}
			return true;
		}else{
			return false;
		}
	}
	//TODO:Following code is to be removed
//	private float p;
//	public float interv;

//	void Update()
//	{
//		if(Time.time-p>=interv)
//		{
//			int type=Random.Range(0,3);
//			if(type==2)
//			{
//				genNote(TNote.bar,speed,dt);
//			}else if(type==1){
//				genNote(TNote.note);
//			}
//			p=Time.time;
//		}
//
//	}
}

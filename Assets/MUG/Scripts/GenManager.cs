using UnityEngine;
using System.Collections;
//WARNING:NO LONGER USED
public class GenManager : MonoBehaviour {
	public Transform LG,RG,LRG,RRG;
	public Note sub,sub2,ob;
	public RectNote sub3,rect;
	public float interv,p,dt,speed;
	// Use this for initialization
	void Start () {
		p=Time.time;
	}

	// Update is called once per frame
	void Update () {
		if(Time.time-p>=interv)
		{
			int type=Random.Range(1,6);
			//Debug.Log(type);
//			if(type==1)
//			{
//				sub=Instantiate(ob,LG.position,Quaternion.identity) as Note;
//				sub.Type=1;
//			}else if(type==2)
//			{
//				sub=Instantiate(ob,RG.position,Quaternion.identity) as Note;
//				sub.Type=1;
//			}else if(type==3)
//			{
//				sub=Instantiate(ob,LG.position,Quaternion.identity) as Note;
//				sub2=Instantiate(ob,RG.position,Quaternion.identity) as Note;
//				sub.Type=1;
//				sub2.Type=1;
//			}else if(type==4)
//			{
//				sub=Instantiate(ob,LG.position,Quaternion.identity) as Note;
//				sub2=Instantiate(ob,new Vector2(LG.position.x,LG.position.y+speed*dt),Quaternion.identity) as Note;
//				sub3=Instantiate(rect,new Vector3(LRG.position.x,LRG.position.y,LRG.position.z),Quaternion.identity) as RectNote;
//				sub3.transform.localScale=new Vector2(1f,speed*dt);
//				sub.Type=2;
//				sub2.Type=3;
//				sub3.endNote=sub2;
//				sub2.pre=sub3;
//				sub.pre=sub3;
//			}else if(type==5)
//			{
//				sub=Instantiate(ob,RG.position,Quaternion.identity) as Note;
//				sub2=Instantiate(ob,new Vector2(RG.position.x,RG.position.y+speed*dt),Quaternion.identity) as Note;
//				sub3=Instantiate(rect,new Vector3(RRG.position.x,RRG.position.y,LRG.position.z),Quaternion.identity) as RectNote;
//				sub3.transform.localScale=new Vector2(1f,speed*dt);
//				sub.Type=2;
//				sub2.Type=3;
//				sub3.endNote=sub2;
//				sub3.headNote=sub;
//				sub2.pre=sub3;
//				sub.pre=sub3;
//			}
//
			p=Time.time;
			//interv=Random.Range(2.0f,4.0f);
			//Debug.Log(interv);
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
public class NetSync : NetworkBehaviour {
	[SyncVar(hook="UpdateOpScore")]
	public int score;

	[SyncVar(hook="UpdateOpGei")]
	public int gei;

	[SyncVar]
	public bool isConnected;

	//[SyncVar(hook="GetLaunch")]
	[SyncVar(hook="Launch")]
	public bool isReady;

	[SyncVar(hook="UpdateAtk")]
	public int atkGei;

	[SyncVar(hook="UpdateDef")]
	public int defGei;

	[SyncVar(hook="UpdateHeal")]
	public int healGei;

	[SyncVar(hook="UpdateDs")]
	public int ds;

	public VersusUI l;
	public GameObject[] ns;
	public NoteGenMan gen;
	public AudioSource audio;
	public ArrayList opSelectedGeis;
	//public GameObject btn;
	// Use this for initialization
	void Start () {
		isReady=false;
		isConnected=false;
		opSelectedGeis=new ArrayList();
		l=GameObject.Find("HUD").GetComponent<VersusUI>();
		gen=GameObject.Find("Reader").GetComponent<NoteGenMan>();
		audio=GameObject.Find("Audio Source").GetComponent<AudioSource>();
		if(l.myDataSync==null||l.opDataSync==null)
		{
			ns=GameObject.FindGameObjectsWithTag("Syncs");
			foreach(GameObject n in ns)
			{
				NetSync nv=n.GetComponent<NetSync>();
				if(nv.isLocalPlayer)
				{
					l.myDataSync=nv;
					gen.myDataSync=nv;
				}else{
					l.opDataSync=nv;
					gen.opDataSync=nv;
				}
			}
			if(ns.Length==2)
			{
				isConnected=true;
				l.DeactivitateInitPanel();
				//l.ActivitateGeiPanel();

				Time.timeScale=1;
				l.ActivitateMe();
				l.ActivitateOp();
				audio.Play();
			}
		}
		//btn.GetComponent<Button>().onClick.RemoveAllListeners();
		score=0;
	}
	void Launch(bool c)
	{
		Debug.Log("launch");
		if(c&&Time.timeScale<=0)
		{
			//l.StartGame();
		}
	}
	// Update is called once per frame
	void UpdateOpScore(int s)
	{
		if(!isLocalPlayer)
		{
			
			l.SyncOpScore(s);
		}
	}

	void UpdateOpGei(int g)
	{
		if(!isLocalPlayer&&g!=-1)
		{
			gen.SyncPn(g);
		}
	}
	void UpdateAtk(int g)
	{
		if(!isLocalPlayer)
		{
			l.atk=g;
		}
	}
	void UpdateDef(int g)
	{
		if(!isLocalPlayer)
		{
			l.def=g;
		}
	}
	void UpdateHeal(int g)
	{
		if(!isLocalPlayer)
		{
			l.heal=g;
		}
	}
	void UpdateDs(int g)
	{
		if(!isLocalPlayer)
		{
			l.SyncOpDs(g);
		}
	}
	[Command]
	public void CmdUpdateScore(int s)
	{
		score=s;
	}

	[Command]
	public void CmdUpdateGei(int g)
	{
		gei=g;
	}
	[Command]
	public void CmdGetReady()
	{
		isReady=true;
	}
	[Command]
	public void CmdUpdateAtkGei(int g)
	{
		atkGei=g;
	}
	[Command]
	public void CmdUpdateDefGei(int g)
	{
		defGei=g;
	}
	[Command]
	public void CmdUpdateHealGei(int g)
	{
		healGei=g;
	}
	[Command]
	public void CmdUpdateDs(int g)
	{
		ds=g;
	}
}

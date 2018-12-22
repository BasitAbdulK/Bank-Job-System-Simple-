using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Client
{
	public string clientName;
	public int clientMoney;

	////Client Constructor
	//	public Client(string name, int money)
	//	{
	//		clientName = name;
	//		clientMoney = money;
	//	}
}

public class BankManager : MonoBehaviour {

	#region Singleton
	private static BankManager _instance;
	public static BankManager Instance
	{
		get
		{
			if (_instance == null) 
			{
				GameObject go = new GameObject ("BankManager");
				go.AddComponent<BankManager> ();
			}
			return _instance;	
		}
	}
	#endregion

	public Bank[] banks = new Bank[1];
	public Client[] clients = new Client[1];

	void Awake()
	{
		_instance = this;
	}

	void Start () {
		banks [0] = new Bank ("Barclays", 15000);
		clients[0].clientName = "Zarak";
		clients [0].clientMoney = 1000;
	}
}

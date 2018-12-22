using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankAccess : MonoBehaviour {

	public string customerName;
	public int customerMoney;

	public Bank bank;

	private bool isClient;
	private Client _currentClient;

	void OnTriggerEnter(Collider col)
	{
		customerName = BankManager.Instance.clients [0].clientName;
		customerMoney = BankManager.Instance.clients [0].clientMoney;

		bank = BankManager.Instance.banks [0];

		if (col.tag == "Player") 
		{
			for (int i = 0; i < BankManager.Instance.clients.Length; i++) {
				if (BankManager.Instance.clients [i].clientName == col.GetComponent<Player> ().playerName) {
					isClient = true;
					_currentClient = BankManager.Instance.clients [i];
				}
			}

			Debug.Log ("Welcome To " + bank.bankName + " Bank");
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player") 
		{
			if (Input.GetKeyDown (KeyCode.Keypad1)) {
				bank.CheckBalance (_currentClient);
			}	
			if (Input.GetKeyDown (KeyCode.Keypad2)) {
				bank.CashDeposit (_currentClient, col.GetComponent<Player> (), this.gameObject.GetComponent<BankAccess>());
			}	
			if (Input.GetKeyDown (KeyCode.Keypad3)) {
				bank.CashWithdrawl (_currentClient, col.GetComponent<Player> (), this.gameObject.GetComponent<BankAccess>());
			}	
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bank {
	
	public string bankName;
	public int cashInVault;

	void Start()
	{
		
	}

	public void CheckBalance (Client clients) {
		int balance = clients.clientMoney;

		Debug.Log ("Your Account Balance is::" + balance);
	}

	public void CashDeposit (Client clients, Player player, BankAccess bankAccess) {
		if (player.playerMoney >= 100) {
			player.playerMoney -= 100;
			clients.clientMoney += 100;

			//
			bankAccess.customerMoney += 100;
			bankAccess.bank.cashInVault += 100;

			Debug.Log ("Hurrah! You Successfully Deposited Your Money In Bank Now Your Money is:" + clients.clientMoney);
		} else
		{
			Debug.Log ("Oh! You Don't Have Enough Money To Deposit.");
		}
	}

	public void CashWithdrawl (Client clients, Player player, BankAccess bankAccess) {
		if (clients.clientMoney >= 100) {
			player.playerMoney += 100;
			clients.clientMoney -= 100;

			//
			bankAccess.customerMoney -= 100;
			bankAccess.bank.cashInVault -= 100;

			Debug.Log ("Hurrah! You Successfully Withdrawl 100 $ from Your Accout and your remaining Money in Bank is:" + clients.clientMoney);
		} else
		{
			Debug.Log ("Oh! You Don't Have Enough Money To Withdrawl.");
		}
	}

	//Constructor
	public Bank(string name, int cash)
	{
		bankName = name;
		cashInVault = cash;
	}
}

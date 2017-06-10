using UnityEngine;

public class PlayerStats : MonoBehaviour 
{

	public static int Money; // Гроші гравця
	public int StartMoney = 300; // стартові гроші гравці 
	public static int Lives; // Здоровя гравця
	public int StartLives = 10; // стартове здоровя гравця
	void Start () 
	{
		Money = StartMoney; // даємо ігроку стартовий капітал
		Lives = StartLives; // даємо кількість здоровя
		
	}
}

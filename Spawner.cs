using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Spawner : MonoBehaviour 
{
	public UnityEngine.UI.Text _Wave; // на якому рівні знаходиться гравець
	public UnityEngine.UI.Text _NextWave; // наступний рівень через
	public UnityEngine.UI.Text _Money; // кількість грошей гравця
	public Transform EnemyPrefab; // Створюємо прифаб
	public float StaticTimeSpawn = 5f; // Інтервал виходу гоблінів
	public float TimeSpawn = 10f; // Час першого виходу гоблінів
	private int WaveNumber = 0; // стартовий рівенль

	void Update()
	{
		_Wave.text = "Wave: " + WaveNumber; // відображаємо рівень гравця
		_NextWave.text = "Next wave: " + TimeSpawn.ToString("F2"); // наступний рівень
		_Money.text = "Money: " + PlayerStats.Money + "$"; // і кількість грошей

		
		if(TimeSpawn <= 0f) // перевіряємо таймер. Якщо він <= 0 то спавнимо ворогів
		{
			StartCoroutine(SpawnWave());
			TimeSpawn = StaticTimeSpawn; // обновлюємо таймер
		}
		TimeSpawn -= Time.deltaTime; // Обновлення кадрів
	}

	IEnumerator SpawnWave() // функція відповідає за затримку виходу ворогів
	{
		WaveNumber++; // перехід на наступинй рівель
		for (int i = 0; i < WaveNumber; i++) // цикл який регулує частоту виходу ворогів
		{
			SpawnEnemy(); // спавнимо ворогів
			yield return new WaitForSeconds(0.5f); // ставимо інтервал виходу ворогів в 0.5с
		}
	}
	void SpawnEnemy() // ставн ворога
	{
		Instantiate(EnemyPrefab, transform.position, transform.rotation); // створюємо обєкт противника
	}
}

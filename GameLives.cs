using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLives : MonoBehaviour 
{
	public UnityEngine.GameObject Panel; // панель Game Over
	public Text _GameLives; // панель життя гравця

	void Start()
	{
		Panel.SetActive(false); // деактивуємо панель
		Time.timeScale = 1; // швидкість гри 100%
	}
	void Update()
	{
		_GameLives.text = "Lives: " + PlayerStats.Lives.ToString(); // Відображаємо життя гравця

		if(PlayerStats.Lives <= 0) // перевірка якщо ХП <= 0 
		{
			Panel.SetActive(true); // відображаємо панель
			Time.timeScale = 0; // Ставимог гру на паузу
		}
	}
	public void BackGame() // кнопка яка відповідає за повернення на головне мення
	{
		SceneManager.LoadScene(0); // відкриваємо нульову сцену
	}
}

using UnityEngine;

public class CreateTower : MonoBehaviour 
{
	public GameObject Effect; // ефекти будування башні
	public Material Default; // Кольор пластини стандартний
	public Color Active; // Кольор пластини активний
	public GameObject Tower; // башня
	private bool TowerBuild = false;
	private bool _Build = true;
	void Update()
	{
		if(TowerBuild == true) // якщо дозволене будівництво тоді будуємо
		{
			Click(); // створюємо башню
		}
	}
	void OnMouseEnter()
	{
		if(gameObject.tag == "Tower Plate") // перевіряємо чи це плитка для башні
		{
			if(_Build == true) // перевіряємо чи там можна будувати (чи не знаходиться там башня)
			{
				TowerBuild = true; // дозволяємо будування башні
				GetComponent<Renderer>().material.color = Active; // міняємо колір вибраної плитки на червоний (це активний колір)
			}
		}
	}
	void OnMouseExit()
	{
		if(gameObject.tag == "Tower Plate") // перевіряємо чи це плитка для башні
		{
			TowerBuild = false; // забороняємо будування башні
			GetComponent<Renderer>().material = Default; // міняємо колір вибраної плитки на стандартний (це не активний колір)
		}
	}
	private void Click() // функція яка відповідає за будування башні
	{
		if(GameMenu.SM == false) // перевіряємо чи відкрите меню. Якщо так то забороняємо будувати
		{
			if(Input.GetMouseButtonDown(0)) // перевіряємо чи була нажата ліва кнопка мишки
			{
				if(PlayerStats.Money >= 100) // перевірка чи на балансі є бальше ніж 100$
				{
					if(_Build == true) // перевірка чи на тому місці вже є башня якщо ні то можна будувати
					{
						Instantiate(Tower, transform.position, transform.rotation); // створюємо башню
						GameObject ef = (GameObject)Instantiate(Effect, transform.position, Quaternion.identity); // Створюємо ефекти
						Destroy(ef, 3f); // видаляємо ефекти
						
						_Build = false; // забороняємо будування башні
					}
					PlayerStats.Money -= 100; // знімаємо 100$ з балансу
				}
			}
		}
	}
}

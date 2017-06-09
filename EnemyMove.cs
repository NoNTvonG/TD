using UnityEngine;

public class EnemyMove : MonoBehaviour 
{
	public float Speed = 5f; // Швидкість обєкта
	private Transform AllControlPosition; // Тримаємо всі контрольні точки 
	private Transform Waypoint; // Дані про кожну окрему точку
	private int WaypointIndex = -1; // Перша контрольна точа

	void Start()
	{
		AllControlPosition = GameObject.Find("Waypoints").transform; // записуємо всі контрольні точки з обєкту (Waypoints)
		NextWayPoint(); // функція ідповідає за маршрут ворогів
	}
	void Update()
	{	
		Vector3 dir = Waypoint.transform.position - transform.position; // записуємо відстань між обєктом і точкою
		dir.y = 0; // Кажемо то що ні в верх ні в низ він не може міняти позицію
		transform.Translate(dir.normalized * Time.deltaTime * Speed);
		if(dir.magnitude <= Time.deltaTime * Speed)
		{
			NextWayPoint(); // функція відповідає за перехід на наступний вейпоінт
		}
	}
	private void NextWayPoint()
	{
		WaypointIndex++; // перехід на наступний вейпоінт
		if(WaypointIndex >= AllControlPosition.childCount) // childCount -> це нумерована кількість всіх точок
		{
			LivesDown(); // функція відповідає за зменшення ХП гравця 
			return;
		}
		Waypoint = AllControlPosition.GetChild(WaypointIndex); // GetChild -> показує індекс обєкта
	}
	private void LivesDown()
	{
		PlayerStats.Lives--; // віднімаємо ХП ігрока
		Destroy(gameObject); // знищуємо ворога
	}
}

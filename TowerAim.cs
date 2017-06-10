using UnityEngine;

public class TowerAim : MonoBehaviour
{
	[Header("Tower")]
	public Transform TowerHead; // Голова башні
	private Transform Target; // приціл на ворога

	[Header("Tower Options")]
	public float TowerRange = 15f; // Область яку захоплює башні
	public float TowerRotateSpeed = 10f; // Швидкість повороту башні

	[Header("Tower Fire")]
	public GameObject Bullet; // Обєкт пулі
	public Transform CreatBullet; // місце де появиться пуля
	public float Fire = 0; // затримка між вистрілами

	void Start()
	{
		InvokeRepeating("FindEnemy", 0f, 0.1f); // Таймер реакції на ворога
	}
	void Update()
	{
		if(Target == null) // якщо ворога немає то нічого не робимо
		{
			return;
		}

		Vector3 Rotate = Target.position - transform.position; // вираховуємо відстань між ворогом і башнею
		Quaternion lookRotate = Quaternion.LookRotation(Rotate); // повертаємо башню в напрямок ворога
		Vector3 Rotation = Quaternion.Lerp(TowerHead.rotation, lookRotate, Time.deltaTime * TowerRotateSpeed).eulerAngles; // функція виконує сом поворот башні на ворога
		TowerHead.rotation = Quaternion.Euler(0f, Rotation.y, 0f); // поворот може виконуватися тільки по осі Y

		if(Fire <= 0) // перезарядка. Якщо час пройшов робимо вистріл
		{
			Shoot(); // виконуємо вистріл
			Fire = 1f; // обновляємо таймер
		}

		Fire -= Time.deltaTime; // віднімаємо від таймера час
	}

	private void FindEnemy()
	{
		GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy"); // Створюємо таблицю всіх ворогів під тегом EnemyName
		GameObject SeeEnemy = null; // Видимий ворог для тавера

		foreach (GameObject Enemy in Enemys) // Провірка на ворогів і визначення відстані до них
		{
			float DistanceEnemy = Vector3.Distance(transform.position, Enemy.transform.position); // Взнаємо відстань від башні до ворога і записуємо в переміну float
			if(DistanceEnemy <= TowerRange) // Якщо дистанція ворога попадає в діапазон башні тоді ...
			{
				SeeEnemy = Enemy; // башня приймає її за свого ворога
			}
		}
		if(SeeEnemy != null) // якщо ворог знайдений...
		{
			Target = SeeEnemy.transform; // виконуємо приціл на нього
		}
		else
		{
			Target = null; // ворог не знайдений. башня відпочиває
		}
	}

	private void Shoot()
	{
		GameObject BulletGO = (GameObject)Instantiate(Bullet, CreatBullet.transform.position, CreatBullet.transform.rotation); //створюємо обєкт який в собі тримає всі снаряди
		Bullet bullet = BulletGO.GetComponent<Bullet>(); // новий приватний компонент пулі 

		if(bullet != null) // Якщо пуля була створена то вона має ворога
		{
			bullet.X(Target); // Цю пулю задаємо ворогові 
		}
	}
}
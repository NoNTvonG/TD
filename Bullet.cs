using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public GameObject EffectBullet; // ефект розлому пулі
	public GameObject EffectEnemy; // ефект вбивства ворога
	private Transform target; // вибраний ворог
	public float Speed = 70f; // Швидкість пулі

	public void X (Transform _target)
	{
		target = _target;
	}
	void Update()
	{
		if(target == null) // Якщо пуля досягнула свого обєкту то знищуємо її
		{
			Destroy(gameObject); // знищуємо обєкт
			return;
		}

		Vector3 dir = target.position - transform.position; // Вираховуємо відстань між обєктами
		float Distance = Speed * Time.deltaTime; // Записуємо дистанцію 

		if(dir.magnitude <= Distance) // magnitude -> показує довжину цього вектору і якщо вона менша дистанції то ...
		{
			HitTower(); // функція попадання в ворога
			return;
		}

		transform.Translate(dir.normalized * Distance, Space.World); // normalized -> повертаємо цей вектор з величиною 1
	}

	void HitTower()
	{
		GameObject effects = (GameObject)Instantiate(EffectBullet, transform.position, transform.rotation); // відображаємо ефект пулі
		GameObject effects2 = (GameObject)Instantiate(EffectEnemy, transform.position, transform.rotation); // відображаємо ефект вбивства ворога
		Destroy(effects, 1f); // видаляємо ефект
		Destroy(effects2, 1f); // видаляємо ефект
		
		PlayerStats.Money += 1; // за вбивство додажмо гроші 

		Destroy(target.gameObject); // видаляємо ворога
	}
}
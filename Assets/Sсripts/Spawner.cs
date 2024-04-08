using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _delay;
	[SerializeField] private float _speed;
	[SerializeField] private Material _material;
	[SerializeField] private Enemy _enemy;

	private void Start()
	{
		StartCoroutine(Spawn(_delay));
	}

	private void ActionOnSpawn(GameObject enemy)
	{
		enemy.GetComponent<Renderer>().material = _material;
		enemy.transform.position = transform.position;

		MovementToDerection movement = enemy.GetComponent<MovementToDerection>();
		movement.SetTarget(_target);
		movement.SetSpeed(_speed);
	}

	private IEnumerator Spawn(float delay)
	{
		var wait = new WaitForSeconds(delay);

		while (enabled)
		{
			GameObject enemy = Instantiate(_enemy.Prefab);
			ActionOnSpawn(enemy);
			yield return wait;
		}
	}
}

public class Enemy
{
	public GameObject Prefab;
}
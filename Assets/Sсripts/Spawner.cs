using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _delay;
	[SerializeField] private float _speed;
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private Material _material;

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
			GameObject enemy = Instantiate(_enemyPrefab);
			ActionOnSpawn(enemy);
			yield return wait;
		}
	}
}
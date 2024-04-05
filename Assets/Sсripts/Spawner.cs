using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject _target;
	[SerializeField] private GameObject _enemyPrefab; 
	[SerializeField] private float _delay;
	[SerializeField] private float _speed;

	[SerializeField] private int _poolCapacity;
	[SerializeField] private int _poolMaxSize;

	private void Start()
    {
		StartCoroutine(Spawn(_delay));
	}

	private void ActionOnGet(GameObject obj)
	{
		MovementToDerection movement = obj.GetComponent<MovementToDerection>();
		obj.transform.position = transform.position;

		movement.SetTarget(_target);
		movement.SetSpeed(_speed);
	}

	private IEnumerator Spawn(float delay)
	{
		var wait = new WaitForSeconds(delay);

		while (enabled)
		{
			GameObject enemy = Instantiate(_enemyPrefab);
			ActionOnGet(enemy);
			yield return wait;
		}
	}
}
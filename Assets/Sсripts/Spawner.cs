using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _delay;
	[SerializeField] private float _speed;
	[SerializeField] private Material _material;
	[SerializeField] private Renderer _prefab;

	private void Start()
    {
		StartCoroutine(Spawn(_delay));
	}

	private void ActionOnSpawn(Renderer enemy)
	{
		enemy.material = _material;
		enemy.gameObject.transform.position = transform.position;
		enemy.gameObject.tag = "Enemy";

		MovementToDerection movement = enemy.gameObject.AddComponent<MovementToDerection>();
		movement.SetTarget(_target);
		movement.SetSpeed(_speed);
	}

	private IEnumerator Spawn(float delay)
	{
		var wait = new WaitForSeconds(delay);

		while (enabled)
		{
			Renderer enemy = Instantiate(_prefab);
			ActionOnSpawn(enemy);
			yield return wait;
		}
	}
}
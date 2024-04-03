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

	private ObjectPool<GameObject> _pool;

	private void Start()
    {
		float radius = GetComponent<SphereCollider>().radius;

		_pool = new ObjectPool<GameObject>(
			createFunc: () => Instantiate(_enemyPrefab, transform.position, Quaternion.identity),
			actionOnGet: (obj) => ActionOnGet(obj),
			actionOnRelease: (obj) => obj.SetActive(false),
			actionOnDestroy:(obj) => Destroy(obj),
			defaultCapacity: _poolCapacity,
			maxSize: _poolMaxSize);

		StartCoroutine(Spawn(_delay));
	}

	private void ActionOnGet(GameObject obj)
	{
		obj.transform.position = transform.position;

		obj.GetComponent<MovementToDerection>().SetTarget(_target);
		obj.GetComponent<MovementToDerection>().SetSpeed(_speed);
		obj.SetActive(true);
	}

	private IEnumerator Spawn(float delay)
	{
		var wait = new WaitForSeconds(delay);

		while (enabled)
		{
			_pool.Get();
			yield return wait;
		}
	}
}
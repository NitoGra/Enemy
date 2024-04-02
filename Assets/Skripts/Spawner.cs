using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
//Этот префаб имеет более чем один компонент. Так что использование GameObject кажется необходимым. Если это не так, то я прошу дополнительных разъяснений.
	[SerializeField] private GameObject _enemyPrefab; 
	[SerializeField] private float _delay;
	[SerializeField] private Vector3 _direction;
	[SerializeField] private float _speed;

	[SerializeField] private int _poolCapacity;
	[SerializeField] private int _poolMaxSize;

	private ObjectPool<GameObject> _pool;

	private void Start()
    {
		float radius = GetComponent<SphereCollider>().radius;

		_pool = new ObjectPool<GameObject>(
			createFunc: () => Instantiate(_enemyPrefab, Random.insideUnitSphere * radius, Quaternion.identity),
			actionOnGet: (obj) => ActionOnGet(obj),
			actionOnRelease: (obj) => obj.SetActive(false),
			actionOnDestroy:(obj) => Destroy(obj),
			defaultCapacity: _poolCapacity,
			maxSize: _poolMaxSize);
		StartCoroutine(Spawn(_delay));
	}

	private void ActionOnGet(GameObject obj)
	{
		transform.position = transform.position;

		obj.GetComponent<Move>().SetDirection(_direction);
		obj.GetComponent<Move>().SetSpeed(_speed);
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

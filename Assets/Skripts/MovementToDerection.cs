using UnityEngine;

public class MovementToDerection : MonoBehaviour
{
	[SerializeField] private float _timeToDead;
	[SerializeField] private float _speed;

	private Vector3 _direction;
	private GameObject _target;

	private void Start()
	{
		Invoke(nameof(Die), _timeToDead);
	}

	private void Update()
    {
		if (_target != null)
			_direction = _target.transform.position;

		transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
	}

	public void SetDirection(Vector3 direction)
	{
		_direction = direction;
	}

	public void SetTarget(GameObject target)
	{
		_target = target;
	}

	public void SetSpeed(float speed)
	{
		_speed = speed;
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
using UnityEngine;

public class MovementToDerection : MonoBehaviour
{
	[SerializeField] private float _timeToDead;
	[SerializeField] private float _speed;

	private Vector3 _nextPosition;
	private GameObject _target;

	private void Start()
	{
		if (_timeToDead != 0)
			Invoke(nameof(Die), _timeToDead);
	}

	private void Update()
	{
		MoveToNextPosition();
	}

	private void Die()
	{
		Destroy(gameObject);
	}

	protected void MoveToNextPosition()
	{
		if (_target != null)
			SetNextPosition(_target.transform.position);

		transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _speed * Time.deltaTime);
	}

	public void SetNextPosition(Vector3 nextPosition)
	{
		_nextPosition = nextPosition;
	}

	public void SetTarget(GameObject target)
	{
		_target = target;
	}

	public void SetSpeed(float speed)
	{
		_speed = speed;
	}
}
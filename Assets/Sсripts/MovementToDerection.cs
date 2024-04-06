using UnityEngine;

public class MovementToDerection : MonoBehaviour
{
	[SerializeField] private float _timeToDead;
	[SerializeField] private float _speed;

	private Vector3 _nextPosition;
	private Transform _target;

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
			RotateToPosition(_target);

		transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}

	public void RotateToPosition(Transform nextPosition)
	{
		transform.LookAt(nextPosition);
	}

	public void SetTarget(Transform target)
	{
		_target = target;
	}

	public void SetSpeed(float speed)
	{
		_speed = speed;
	}
}
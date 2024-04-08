using UnityEngine;

public class MovementToDerection : MonoBehaviour
{
	[SerializeField] private float _timeToDead;
	[SerializeField] private float _speed;

	private Transform _target;

	private void Start()
	{
		if (_timeToDead != 0)
			Invoke(nameof(Die), _timeToDead);
	}

	private void Update()
	{
		MoveToTargetWayPoint();
	}

	private void Die()
	{
		Destroy(gameObject);
	}

	protected void MoveToTargetWayPoint()
	{
		if (_target != null)
			transform.LookAt(_target);

		transform.Translate(Vector3.forward * _speed * Time.deltaTime);
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
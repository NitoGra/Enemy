using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField] private float timeToDead;

	private float _speed;
	private Vector3 _direction;

	private void Start()
	{
		Invoke(nameof(Dead), timeToDead);
	}

	private void Update()
    {
		transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
	}

	public void SetDirection(Vector3 direction)
	{
		_direction = direction;
	}

	public void SetSpeed(float speed)
	{
		_speed = speed;
	}

	private void Dead()
	{
		Destroy(gameObject);
	}
}
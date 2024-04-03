using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FollowPath : MovementToDerection
{
	[SerializeField] private List<Transform> _wayPoints;
	[SerializeField] private float _pauseTime;

	private int _index;
	private Vector3 _wayPoint;

	private void Start()
	{
		_index = 0;
		MakeDirection();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != nameof(Point))
			return;

		int index = _wayPoints.Count - 1;

		if (_wayPoint == _wayPoints[index].position)
			_index = 0;
		else
			_index++;

		Invoke(nameof(MakeDirection), _pauseTime);
	}

	private void MakeDirection()
	{
		_wayPoint = _wayPoints[_index].position;
		SetDirection(_wayPoint);
	}
}
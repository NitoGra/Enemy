using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MovementToDerection
{
	[SerializeField] private List<Transform> _wayPoints;
	[SerializeField] private float _minDistance;

	private int _index;
	private Transform _wayPoint;

	private void Start()
	{
		_index = 0;
		_wayPoint = _wayPoints[_index];
		RotateToPosition(_wayPoint);
	}

	private void Update()
	{
		ChangeTargetWayPoint();
		float distance = Vector3.Distance(_wayPoints[_index].position, transform.position);

		if (distance <= _minDistance)
		{
			int index = _wayPoints.Count - 1;

			if (_wayPoint == _wayPoints[index])
				_index = 0;
			else
				_index++;

			MakeNextPosition();
		}
	}

	private void MakeNextPosition()
	{
		_wayPoint = _wayPoints[_index];
		RotateToPosition(_wayPoint);
	}
}
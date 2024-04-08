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
		MoveToTargetWayPoint();
		float distance = Vector3.Distance(_wayPoints[_index].position, transform.position);

		if (distance <= _minDistance)
		{
			_index = ++_index % _wayPoints.Count == 0 ? 0 : _index++;
			MakeNextPosition();
		}
	}

	private void MakeNextPosition()
	{
		_wayPoint = _wayPoints[_index];
		RotateToPosition(_wayPoint);
	}
}
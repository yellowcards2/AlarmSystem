using System.Collections.Generic;
using UnityEngine;

public class Crook : MonoBehaviour
{
    private List<Vector3> _waypoints;
    private Vector3 _firstHousePoint;
    private Vector3 _secondHousePoint;
    private Vector3 _waypoint;
    private float _firstXPosition = 9.66f;
    private float _secondXPosition = -20f;
    private float _crookHeight = 1f;
    private float _speed = 3f;
    private int _index = 0;

    private void Start()
    {
        _firstHousePoint = new Vector3(_firstXPosition, _crookHeight, 0);
        _secondHousePoint = new Vector3(_secondXPosition, _crookHeight, 0);

        _waypoints = new()
        {
            _firstHousePoint,
            _secondHousePoint
        };

        _waypoint = _waypoints[_index];
        transform.forward = _waypoint - transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoint, _speed * Time.deltaTime);

        if (transform.position == _waypoint)
        {
            _waypoint = GetNextPosition();
        }
    }

    private Vector3 GetNextPosition()
    {
        _index = ++_index % _waypoints.Count;

        Vector3 nextPosition = _waypoints[_index];
        transform.forward = nextPosition - transform.position;
        return nextPosition;
    }
}


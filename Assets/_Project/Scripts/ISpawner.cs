using System;
using UnityEngine;
using Random = UnityEngine.Random;

public interface ISpawner
{
    public void GetRandomPositions(out Vector3 startPosition, out Vector3 endPosition);
    
    public void Spawn();

    public void StartSpawning();

    public void EndSpawning();
}

[Serializable]
public class SideRange
{
    [SerializeField] private Vector3 _firstPoint;
    [SerializeField] private Vector3 _lastPoint;

    public Vector3 GetRandomPoint()
    {
        var randomPoint = new Vector3(Random.Range(_firstPoint.x, _lastPoint.x),
            Random.Range(_firstPoint.y, _lastPoint.y), Random.Range(_firstPoint.z, _lastPoint.z));

        return randomPoint;
    }
}
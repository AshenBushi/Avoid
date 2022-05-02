using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected int _poolCount;
    [SerializeField] protected T _template;
    [SerializeField] protected Transform _container;

    protected List<T> _pool = new List<T>();

    private void Awake()
    {
        InitPool();
    }

    protected virtual void InitPool()
    {
        for (var i = 0; i < _poolCount; i++)
        {
            _pool.Add(Instantiate(_template, _container));
            _pool[i].gameObject.SetActive(false);
        }
    }

    public bool TryGetObject(out T poolObject)
    {
        foreach (var currentObject in _pool.Where(currentObject => currentObject.gameObject.activeSelf == false))
        {
            poolObject = currentObject;
            return true;
        }

        poolObject = null;
        return false;
    }
}

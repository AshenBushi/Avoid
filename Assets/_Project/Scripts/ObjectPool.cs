using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T: Component
{
    [SerializeField] private int _poolCount;
    [SerializeField] private T _template;
    [SerializeField] private Transform _container;

    private List<T> _pool = new List<T>();

    private void Awake()
    {
        Init();
    }

    private void Init()
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

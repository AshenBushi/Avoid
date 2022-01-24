using System;
using System.Collections.Generic;


public class SpawnersManager : Singleton<SpawnersManager>
{
    public EnemySpawner EnemySpawner { get; private set; }
    public List<ISpawnerItem> ItemSpawners { get; set; } = new List<ISpawnerItem>();

    protected override void Awake()
    {
        base.Awake();

        EnemySpawner = GetComponentInChildren<EnemySpawner>();
        ItemSpawners.AddRange(GetComponentsInChildren<ISpawnerItem>());
    }

    public void StartSpawning()
    {
        EnemySpawner.StartSpawning();

        for (int i = 0; i < ItemSpawners.Count; i++)
        {
            ItemSpawners[i].StartSpawning();
        }
    }

    public void EndSpawning()
    {
        EnemySpawner.EndSpawning();

        for (int i = 0; i < ItemSpawners.Count; i++)
        {
            ItemSpawners[i].EndSpawning();
        }
    }
}

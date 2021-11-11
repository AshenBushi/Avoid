using UnityEngine;

public class SpawnersManager : Singleton<SpawnersManager>
{
    public EnemySpawner EnemySpawner { get; private set; }
    public HealSpawner HealSpawner { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        EnemySpawner = GetComponentInChildren<EnemySpawner>();
        HealSpawner = GetComponentInChildren<HealSpawner>();
    }

    public void StartSpawning()
    {
        EnemySpawner.StartSpawning();
        HealSpawner.StartSpawning();
    }

    public void EndSpawning()
    {
        EnemySpawner.EndSpawning();
        HealSpawner.EndSpawning();
    }
}

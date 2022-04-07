using System.Collections.Generic;

public class SpawnersManager : Singleton<SpawnersManager>
{
    public ISpawnerEnemyState SpawnerEnemy { get; private set; }
    public List<ISpawner> ItemSpawners { get; set; } = new List<ISpawner>();

    protected override void Awake()
    {
        base.Awake();

        SpawnerEnemy = GetComponentInChildren<ISpawnerEnemyState>();
        ItemSpawners.AddRange(GetComponentsInChildren<ISpawner>());
    }

    public void StartSpawning()
    {
        for (int i = 0; i < ItemSpawners.Count; i++)
        {
            ItemSpawners[i].StartSpawning();
        }
    }

    public void EndSpawning()
    {
        for (int i = 0; i < ItemSpawners.Count; i++)
        {
            ItemSpawners[i].EndSpawning();
        }
    }
}

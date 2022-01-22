using System;
using System.Collections.Generic;


public class SpawnersManager : Singleton<SpawnersManager>
{
    //private ItemSpawner _prevSpawn = null;

    public EnemySpawner EnemySpawner { get; private set; }
    public List<ItemSpawner> ItemSpawners { get; set; } = new List<ItemSpawner>();

    protected override void Awake()
    {
        base.Awake();

        EnemySpawner = GetComponentInChildren<EnemySpawner>();
        ItemSpawners.AddRange(GetComponentsInChildren<ItemSpawner>());
    }

    public void StartSpawning()
    {
        EnemySpawner.StartSpawning();

        List<ItemSpawner> tempItems = new List<ItemSpawner>();
        tempItems.AddRange(ItemSpawners);

        while(tempItems.Count != 0)
        {
            var rand = new Random().Next(0, tempItems.Count);
            tempItems[rand].StartSpawning();
            tempItems.RemoveAt(rand);
        }

        //for (int i = 0; i < tempItems.Count; i++)
        //{
            
        //}


        //for (int i = 0; i < ItemSpawners.Count; i++)
        //{
        //    //if (ItemSpawners[i] == _prevSpawn) continue;
        //    //if (ItemSpawners[i].IsSpawned) continue;

        //    ItemSpawners[i].StartSpawning();
        //}
    }

    public void EndSpawning()
    {
        EnemySpawner.EndSpawning();

        for (int i = 0; i < ItemSpawners.Count; i++)
        {
            //if (ItemSpawners[i] == _prevSpawn) continue;
            //if (ItemSpawners[i].IsSpawned) continue;

            ItemSpawners[i].EndSpawning();
        }
    }
}

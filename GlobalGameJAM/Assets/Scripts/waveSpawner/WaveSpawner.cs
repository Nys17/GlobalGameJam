using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
      List<GameObject> EnemyArray = new List<GameObject>();
    public GameObject Enemy;
    public float NumberOfEnemies;
    public float SpawnDelay;
     private int Round;
    public int MaxRounds;

    public bool ShouldSpawnEnemies ;

    void Start()
    {
         Round = 1; /// set round
        for (int i = 0; i <NumberOfEnemies; i++)
        {
            EnemyArray.Add(Enemy);
        } 
        ShouldSpawnEnemies = true;

       // StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {


        WaveOne();
        
    }

    void WaveOne()
    {
        if (ShouldSpawnEnemies == true)
        {
            foreach (var Enemy in EnemyArray)
            {
                // StartCoroutine(SpawnEnemies());
                InvokeRepeating("SpawnEnemies", 0.2f, SpawnDelay);
            }
           
            ShouldSpawnEnemies = false; //// so we can invoke it
        }

       
    }
    protected void SpawnEnemies()
    {
      //  for (int i = 0;i <NumberOfEnemies;i++)
      //  {
      //      Debug.Log(EnemyArray[i].name);
      //      Debug.Log(EnemyArray.Count);
            Instantiate(Enemy, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
    //    EnemyArray.Remove(EnemyArray[i]);
          // yield return new WaitForSeconds(SpawnDelay);
        // }

        // ShouldSpawnEnemies = false; //// so we can invoke it
        
    }
}

public enum WaveState
{
    FirstWave,
    SecondWave,
    ThirdWave
}

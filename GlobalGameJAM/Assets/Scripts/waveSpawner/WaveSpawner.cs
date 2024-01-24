using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    List<GameObject> EnemyTypeOne = new List<GameObject>();
    List<GameObject> EnemyTypeTwo = new List<GameObject>();
    List<GameObject> EnemyTypeThree = new List<GameObject>();
    public GameObject Enemy;
    public GameObject EnemyTwo;
    public GameObject EnemyThree;
    public float NumberOfEnemiesOne;
    public float NumberOfEnemiesTwo;
    public float NumberOfEnemiesThree;

    public int EnemyOneMultiplier;
    public int EnemyTwoMultiplier;
    public int EnemyThreeMultiplier;
    private int Round;
    public int MaxRounds;

    public bool ShouldSpawnEnemies;

    private WaveState waveState;
    void Start()
    {
        Round = 1; /// set round
       FillEnemyArrays();
        ShouldSpawnEnemies = true;

    }
    void Update()
    {
        if (Round < 4)
        {
            switch (Round)
            {

                case 1:
                    waveState = WaveState.FirstWave;
                    break;

                case 2:
                    waveState = WaveState.SecondWave;
                    break;
                case 3:
                    waveState = WaveState.ThirdWave;
                    break;


                default:
                    break;
            }
        }
        else
        {
            waveState = WaveState.InfinityWave;
        }

        switch (waveState) {

            case WaveState.FirstWave:
                WaveOne();
                break;


            case WaveState.SecondWave:
                WaveTwo();
                break;


            case WaveState.ThirdWave:
                WaveThree();
                break;


            case WaveState.InfinityWave:
                InfinityWave();
                break;

        }


    }

    void WaveOne()
    {
        if (ShouldSpawnEnemies == true)
        {
            for (int i = 0; i < EnemyTypeOne.Count; i++) {

                SpawnEnemies(i, EnemyTypeOne);

            }
            ShouldSpawnEnemies = false;
        }


    }
    private void WaveTwo()
    {
        if (ShouldSpawnEnemies == true)
        {
            for (int i = 0; i < EnemyTypeTwo.Count; i++)
            {

                SpawnEnemies(i, EnemyTypeTwo);

            }
            ShouldSpawnEnemies = false;
        }
    }

    void WaveThree()
    {
        if (ShouldSpawnEnemies == true)
        {
            for (int i = 0; i < EnemyTypeThree.Count; i++)
            {
                SpawnEnemies(i, EnemyTypeThree);
            }
        }
    }

    void InfinityWave()
    {
        if (ShouldSpawnEnemies == true)
        {
            for (int i = 0; i < EnemyTypeOne.Count; i++)
            {
                for (int j = 0; j< EnemyTypeTwo.Count; j++)
                {
                    for (int k = 0; k < EnemyTypeThree.Count; k++)
                    {
                        SpawnEnemies(i, EnemyTypeOne);
                        SpawnEnemies(j, EnemyTypeTwo);
                        SpawnEnemies(k, EnemyTypeThree);
                    }
                }
            }
        }
    }
    protected void SpawnEnemies(int i, List <GameObject> ListOfEnemies)
    {
    
            Instantiate(ListOfEnemies[i], this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
           
    
        
    }

    public void DestroyEnemy(GameObject enemyType)
    {

        Destroy(enemyType.gameObject);

        if (enemyType.tag == "Enemy") { 
                EnemyTypeOne.Remove(enemyType);
        
        }
        else if (enemyType.tag == "EnemyTwo") {
        
        EnemyTypeTwo.Remove(enemyType); 
        
        }
        else if (enemyType.tag == "EnemyThree")
        {
            EnemyTypeThree.Remove(enemyType);
        }

        StartNextRound();
    }

    void StartNextRound()
    {
        switch (waveState)
        {
            case WaveState.FirstWave:
                if(EnemyTypeOne.Count == 0)
                {
                   if(Round <= MaxRounds)
                    {
                        Round = +1;
                        ShouldSpawnEnemies = true;
                    }
                    
                }    
                break;
            case WaveState.SecondWave:
                if (EnemyTypeTwo.Count == 0)
                {
                    if (Round <= MaxRounds)
                    {
                        Round = +1;
                        ShouldSpawnEnemies = true;
                    }
                }
                break;
            case WaveState.ThirdWave:
                if (EnemyTypeThree.Count == 0)
                {
                    if (Round <= MaxRounds)
                    {
                        Round = +1;
                        ShouldSpawnEnemies = true;
                    }
                }
                break;
            case WaveState.InfinityWave:
                if (EnemyTypeThree.Count == 0&& EnemyTypeTwo.Count == 0&& EnemyTypeOne.Count == 0)
                {
                    if (Round <= MaxRounds)
                    {
                        Round = +1;
                        FillEnemyArrays();
                        ShouldSpawnEnemies = true;
                    }
                }
                else
                {
                    Debug.Log("finished");
                }
                break;
            default:
                break;
        }
    }

    void FillEnemyArrays()
    {
        if (waveState == WaveState.InfinityWave) /// may need to do if statements like below
        {
            if (Round > 4)
            {
                EnemyOneMultiplier = EnemyOneMultiplier + Random.Range(1,10);
                EnemyTwoMultiplier = EnemyTwoMultiplier + Random.Range(1,10);
                EnemyThreeMultiplier = EnemyThreeMultiplier + Random.Range(1,10);
            }
            for (int i = 0; i < NumberOfEnemiesOne * EnemyOneMultiplier; i++)
            {
                EnemyTypeOne.Add(Enemy);
            }
            for (int i = 0; i < NumberOfEnemiesTwo * EnemyTwoMultiplier; i++)
            {
                EnemyTypeTwo.Add(EnemyTwo);
            }
            for (int i = 0; i < NumberOfEnemiesThree * EnemyThreeMultiplier; i++)
            {
                EnemyTypeThree.Add(EnemyThree);
            }
        }
       
        else {
            for (int i = 0; i < NumberOfEnemiesOne ; i++)
            {
                if (EnemyTypeOne.Count<= NumberOfEnemiesOne)
                {
                    EnemyTypeOne.Add(Enemy);
                }
                
            }
            for (int i = 0; i < NumberOfEnemiesTwo; i++)
            {
                if (EnemyTypeTwo.Count<= NumberOfEnemiesTwo)
                {
                    EnemyTypeTwo.Add(EnemyTwo);
                }
                
            }
            for (int i = 0; i < NumberOfEnemiesThree; i++)
            {
                if(EnemyTypeThree.Count<= NumberOfEnemiesThree)
                {
                    EnemyTypeThree.Add(EnemyThree);
                }
               
            }
        }
    }
}

public enum WaveState
{
    FirstWave,
    SecondWave,
    ThirdWave,
    InfinityWave
}

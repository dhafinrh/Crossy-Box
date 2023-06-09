using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayManager : MonoBehaviour
{
    [SerializeField] List<Terrain> terrainList;
    [SerializeField] List<Coin> coinList;
    [SerializeField] int initialGrassCount = 5;
    [SerializeField] int horizontalSize;
    [SerializeField] int backViewDistance = -4;
    [SerializeField] int forwardViewDistance = 15;
    Dictionary<int, Terrain> activeTerrainDict = new Dictionary<int, Terrain>(20);
    [SerializeField] private int travelDistance;
    [SerializeField] private int coin;
    public UnityEvent<int, int> OnUpdateTerrainLimit;
    public UnityEvent<int> OnScoreUpdate;
    public UnityEvent OnResetTimer;


    private void Start()
    {
        //Create initial Grass
        for (int zPos = backViewDistance; zPos < initialGrassCount; zPos++)
        {
            var terrain = Instantiate(terrainList[0]);
            terrain.transform.position = new Vector3(0, 0, zPos);

            if (terrain is Grass grass)
                grass.SetTreePercentage(zPos < -1 ? 1 : 0);

            terrain.Generate(horizontalSize);
            activeTerrainDict[zPos] = terrain;
        }

        for (int zPos = initialGrassCount; zPos < forwardViewDistance; zPos++)
        {
            SpawnRandomTerrain(zPos);
        }
        OnUpdateTerrainLimit.Invoke(horizontalSize, travelDistance + backViewDistance);
    }

    private Terrain SpawnRandomTerrain(int zPos)
    {
        Terrain comparatorTerrain = null;
        int randomIndex;

        for (int z = -1; z >= -3; z--)
        {
            var checkPos = zPos + z;

            if (comparatorTerrain == null)
            {
                comparatorTerrain = activeTerrainDict[checkPos];
                continue;
            }
            else if (comparatorTerrain.GetType() != activeTerrainDict[checkPos].GetType())
            {
                randomIndex = Random.Range(0, terrainList.Count);
                return SpawnTerrain(terrainList[randomIndex], zPos);
            }
            else
            {
                continue;
            }
        }

        var candicateTerrain = new List<Terrain>(terrainList);
        for (int i = 0; i < candicateTerrain.Count; i++)
        {
            if (comparatorTerrain.GetType() == candicateTerrain[i].GetType())
            {
                candicateTerrain.Remove(candicateTerrain[i]);
                break;
            }
        }

        randomIndex = Random.Range(0, candicateTerrain.Count);
        OnResetTimer.Invoke();
        return SpawnTerrain(candicateTerrain[randomIndex], zPos);
    }

    public Terrain SpawnTerrain(Terrain terrain, int zPos)
    {
        terrain = Instantiate(terrain);
        terrain.transform.position = new Vector3(0, 0, zPos);
        terrain.Generate(horizontalSize);
        activeTerrainDict[zPos] = terrain;
        SpawnCoin(horizontalSize, zPos, 0.2f);
        return terrain;
    }

    public Coin SpawnCoin(int horizontalSize, int zPos, float coinProbability = 0.2f)
    {
        List<Vector3> spawnCandidateList = new List<Vector3>();
        for (int i = -horizontalSize / 2; i <= horizontalSize / 2; i++)
        {
            var spawnPos = new Vector3(i, 0, zPos);
            if (Tree.PositionSet.Contains(spawnPos) == false)
            {
                spawnCandidateList.Add(spawnPos);
            }
        }

        if (coinProbability == 0)
        {
            return null;
        }
        else if (coinProbability > Random.value)
        {
            int index = Random.Range(0, coinList.Count);
            int spawnIndex = Random.Range(0, spawnCandidateList.Count);
            return Instantiate(
                coinList[index],
                spawnCandidateList[spawnIndex],
                Quaternion.identity
                );
        }

        return null;
    }

    public void UpdateTravelDistance(Vector3 targetPos)
    {
        if (targetPos.z > travelDistance)
        {
            travelDistance = Mathf.CeilToInt(targetPos.z);
            UpdateTerrain();
            OnScoreUpdate.Invoke(GetScore());
        }
    }
    public void AddCoin(int value = 1)
    {
        this.coin += value;
        OnScoreUpdate.Invoke(GetScore());
    }

    private int GetScore()
    {
        return travelDistance + coin;
    }

    public void UpdateTerrain()
    {
        var destroyPos = travelDistance - 1 + backViewDistance;
        Destroy(activeTerrainDict[destroyPos].gameObject);
        activeTerrainDict.Remove(destroyPos);

        var spawnPosition = travelDistance - 1 + forwardViewDistance;
        SpawnRandomTerrain(spawnPosition);

    }
}

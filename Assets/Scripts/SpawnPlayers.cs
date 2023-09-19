using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public List<PlayerSpawn> playerSpawns = new List<PlayerSpawn>();

    [Serializable]
    public struct PlayerSpawn
    {
        public GameObject PlayerPrefab;
        public Transform SpawnTransform;
    }

    private void Start()
    {
        foreach (PlayerSpawn playerSpawn in playerSpawns)
        {
            Instantiate(playerSpawn.PlayerPrefab, playerSpawn.SpawnTransform.position, playerSpawn.SpawnTransform.rotation);
        }
    }
}

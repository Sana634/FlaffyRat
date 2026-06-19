using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private DroppedCoin droppedCoinPrefab;
    [SerializeField] private float invincibilityDuration = 1.5f;

    public int Coins { get; private set; }
    public bool IsGameOver { get; private set; }
    public bool IsInvincible { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void CollectCoin(GameObject coin)
    {
        if (IsGameOver) return;

        Coins++;
        Destroy(coin);
    }

    public void HandleObstacleHit(Vector3 playerPosition)
    {
        if (IsGameOver || IsInvincible) return;

        if (Coins > 0)
        {
            KnockOutCoins(playerPosition);
            StartCoroutine(InvincibilityCoroutine());
        }
        else
        {
            GameOver();
        }
    }

    void KnockOutCoins(Vector3 position)
    {
        int coinsToDrop = Coins;
        Coins = 0;

        if (droppedCoinPrefab == null) return;

        for (int i = 0; i < coinsToDrop; i++)
        {
            Vector2 scatter = Random.insideUnitCircle * 0.3f;
            DroppedCoin coin = Instantiate(droppedCoinPrefab, position + (Vector3)scatter, Quaternion.identity);
            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1.5f)).normalized;
            coin.Launch(direction * Random.Range(2f, 4f));
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        IsInvincible = false;
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;

        SpawnColumns spawner = FindObjectOfType<SpawnColumns>();
        if (spawner != null)
            spawner.StopSpawning();
    }
}

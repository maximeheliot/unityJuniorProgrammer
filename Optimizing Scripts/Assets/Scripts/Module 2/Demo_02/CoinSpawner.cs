using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinController coinPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < 300; i++)
        {
            Vector2 spawnPosition =
                Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
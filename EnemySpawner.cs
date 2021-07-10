using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Список настроек для врагов")]
    [SerializeField] private List<EnemyData> enemySetttings;

    [Tooltip("Количество объектов в пуле")]
    [SerializeField] private int poolCount;

    [Tooltip("Ссылка на базовый префаб для врагов")]
    [SerializeField] private GameObject enemyPrefab;

    [Tooltip("время между спауном")]
    [SerializeField] private float spawnTime;

    public static Dictionary<GameObject, Enemy> Enemies;

    private Queue<GameObject> currentEnemies;

    private void Start()
    {
        Enemies = new Dictionary<GameObject, Enemy>();
        currentEnemies = new Queue<GameObject>();

        for (int i = 0; i < poolCount; ++i)
        {
            var prefab = Instantiate(enemyPrefab);
            var script = prefab.GetComponent<Enemy>();
            prefab.SetActive(false);
            Enemies.Add(prefab, script);
            currentEnemies.Enqueue(prefab);
        }

        Enemy.OnEnemyOverFly += ReturnEnemy;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if (spawnTime == 0)
        {
            Debug.LogError("Не выставлено время спауна, задано стандартное значение: 1 сек.");
            spawnTime = 1;
        }
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (currentEnemies.Count > 0)
            {
                var enemy = currentEnemies.Dequeue();
                var script = Enemies[enemy];
                enemy.SetActive(true);

                int rand = Random.Range(0, enemySetttings.Count);
                script.Init(enemySetttings[rand]);

                float xPos = Random.Range(-GameCamera.Border, GameCamera.Border);
                enemy.transform.position = new Vector2(xPos, transform.position.y);

            }
        }
    }

    private void ReturnEnemy(GameObject _enemy)
    {
        _enemy.transform.position = transform.position;
        _enemy.SetActive(false);
        currentEnemies.Enqueue(_enemy);
    }
}

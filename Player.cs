using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("Начальная позиция")]
    [SerializeField] private Vector3 startPos;

    [Tooltip("Начальное здоровье")]
    [SerializeField] private float health = 5.0f;

    [Tooltip("Скорость")]
    [Range(0.01f, 0.5f)]
    [SerializeField] private float speed = 0.1f;

    private GameManage manager;
    private MenuManage menu;

    private void Start()
    {
        transform.position = startPos;
        manager = FindObjectOfType<GameManage>();
        menu = FindObjectOfType<MenuManage>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) &&
            transform.position.x > -GameCamera.Border)
            transform.Translate(Vector3.left * speed);
        else if (Input.GetKey(KeyCode.RightArrow) &&
            transform.position.x < GameCamera.Border)
            transform.Translate(Vector3.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var obj = col.gameObject;
        if (EnemySpawner.Enemies.ContainsKey(obj))
        {
            health -= EnemySpawner.Enemies[obj].Attack;
            if (health <= 0)
            {
                manager.HealthDown(health);
                Debug.Log("Игра окончена");
                menu.ChangeLvl(0);
                Destroy(gameObject);
            }
            else
            {
                manager.HealthDown(health);
                Debug.Log("Осталось " + health + " hp");
            }
        }
    }
}

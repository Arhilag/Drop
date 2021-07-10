using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData data;

    /// <summary>
    /// Инициализация врага
    /// </summary>
    /// <param name="_data"></param>
    public void Init(EnemyData _data)
    {
        data = _data;
        GetComponent<SpriteRenderer>().sprite = data.MainSprite;
    }

    /// <summary>
    /// Атака врага
    /// </summary>
    public float Attack
    {
        get { return data.Attack; }
        protected set { }
    }

    public static Action<GameObject> OnEnemyOverFly;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * data.Speed);
        if (transform.position.y < -10 && OnEnemyOverFly != null)
            OnEnemyOverFly(gameObject);
    }
}

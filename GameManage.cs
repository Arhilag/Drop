using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    [Tooltip("Список под здоровье")]
    [SerializeField] private List<GameObject> health;

    [Tooltip("Список под здоровье")]
    [SerializeField] public Text scoreText;

    private int score = 0;
    private float time = 1;

    private void Start()
    {
        StartCoroutine(TimeScore());
    }

    public void HealthDown(float num)
    {
        int flag = (int)num;
        health[flag].SetActive(false);
    }

    private IEnumerator TimeScore()
    {
        while (true)
        {
            score++;
            scoreText.text = score + "";
            yield return new WaitForSeconds(time);
        }
    }
}

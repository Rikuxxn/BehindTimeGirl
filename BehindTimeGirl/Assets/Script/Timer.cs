using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshPro用の型
    public Color countdownColor = Color.blue; // カウントダウン時の文字色
    public Color countupColor = Color.red;    // カウントアップ時の文字色
    private float countdownTime = 60f; // カウントダウンの初期時間
    private bool isCountingDown = true; // カウントダウン中かどうか

    void Start()
    {
        // 初期設定
        if (timerText != null)
        {
            timerText.color = countdownColor;
            UpdateTimerText(countdownTime);
        }
    }

    void Update()
    {
        if (isCountingDown)
        {
            // カウントダウン処理
            countdownTime -= Time.deltaTime;
            if (countdownTime <= 0)
            {
                countdownTime = 0;
                isCountingDown = false;
                timerText.color = countupColor; // 色を赤に変更
            }
            UpdateTimerText(countdownTime);
        }
        else
        {
            // カウントアップ処理
            countdownTime += Time.deltaTime;
            UpdateTimerText(countdownTime);
        }
    }

    // タイマーの文字表示を更新
    void UpdateTimerText(float time)
    {
        if (isCountingDown)
        {
            timerText.text = Mathf.CeilToInt(time).ToString(); // 小数点切り上げ
        }
        else
        {
            timerText.text = Mathf.FloorToInt(time).ToString(); // 小数点切り捨て
        }
    }

    // 現在の時間を取得するメソッドを追加
    public float GetCurrentTime()
    {
        return countdownTime;
    }

    public bool IsCountingDown()
    {
        return isCountingDown;
    }
}
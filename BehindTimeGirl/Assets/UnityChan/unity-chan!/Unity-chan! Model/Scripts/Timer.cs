using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントを使用するため

public class CountdownAndAddTimer : MonoBehaviour
{
    public Text timerText; // タイマーを表示するTextコンポーネント
    private float timer = 30f; // 初期タイマー値（カウントダウン開始値）
    private bool isCountingDown = true; // 現在カウントダウン中かどうか

    void Start()
    {
        UpdateTimerDisplay(); // 初期表示を更新
    }

    void Update()
    {
        if (isCountingDown)
        {
            // カウントダウン処理
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0f;
                isCountingDown = false; // カウントダウン終了
                timerText.color = Color.red; // テキストの色を赤に変更
            }
        }
        else
        {
            // 加算処理
            timer += Time.deltaTime;
        }

        UpdateTimerDisplay(); // 表示を更新
    }

    void UpdateTimerDisplay()
    {
        if (isCountingDown)
        {
            timerText.color = Color.blue; // カウントダウン中は青色
        }

        // 小数点以下を切り捨てて秒数を表示
        timerText.text = Mathf.FloorToInt(timer).ToString();
    }
}

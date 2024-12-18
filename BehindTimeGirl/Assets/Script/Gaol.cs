using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    public TextMeshProUGUI goalText; // ゴール表示用のTextMeshPro
    public Timer timerScript; // Timerスクリプトへの参照を追加

    // ゴール時間に応じたメッセージ
    private string GetGoalMessage(float time, bool isCountingDown)
    {
        if (isCountingDown && time <= 0) // タイムオーバー
        {
            return "TIME OVER...";
        }
        else if (!isCountingDown) // カウントアップ中
        {
            return "TIME OVER...";
        }
        else if (time <= 30f) // 30秒以内でゴール
        {
            return "PERFECT GOAL!";
        }
        else if (time <= 45f) // 45秒以内でゴール
        {
            return "GOOD GOAL!";
        }
        else // 45秒を超えた場合
        {
            return "GOAL...";
        }
    }
    void Start()
    {
        // 最初はゴールメッセージを非表示にする
        if (goalText != null)
        {
            goalText.text = "";
        }

        // Timerスクリプトの参照がない場合、シーン内から探す
        if (timerScript == null)
        {
            timerScript = FindObjectOfType<Timer>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // プレイヤーがゴールオブジェクトに触れたとき
        if (other.CompareTag("Player") && timerScript != null)
        {
            DisplayGoalMessage(timerScript.GetCurrentTime(), timerScript.IsCountingDown());
        }
    }

    void DisplayGoalMessage(float time, bool isCountingDown)
    {
        if (goalText != null)
        {
            goalText.text = GetGoalMessage(time, isCountingDown);
        }
    }
}
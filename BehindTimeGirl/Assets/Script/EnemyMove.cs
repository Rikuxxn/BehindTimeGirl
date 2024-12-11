using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float speed = 3.0f;           // 敵の移動速度
    public float moveTime = 2.0f;       // ランダムに移動する時間
    public float waitTime = 1.0f;       // 移動後に待機する時間
    private float timer;                // タイマー
    private Vector3 moveDirection;      // 移動方向
    private bool isWaiting = false;     // 待機状態かどうか

    void Start()
    {
        timer = moveTime;               // 初期タイマーを設定
        ChooseDirection();              // 初期移動方向を決定
    }

    void Update()
    {
        if (isWaiting)
        {
            // 待機状態の処理
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isWaiting = false;
                timer = moveTime;
                ChooseDirection();      // 次の移動方向を決定
            }
        }
        else
        {
            // 移動状態の処理
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isWaiting = true;
                timer = waitTime;       // 待機タイムに切り替え
            }
        }
    }

    // 移動方向をランダムに決定する関数 (X軸限定)
    void ChooseDirection()
    {
        // X軸方向に左右どちらかをランダムで選択
        float randomX = Random.Range(-1.0f, 1.0f);
        moveDirection = new Vector3(randomX, 0, 0).normalized; // X軸の方向を設定
    }
}

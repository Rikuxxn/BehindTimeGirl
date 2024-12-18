using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;        // プレイヤーの走るスピード
    public float jumpForce = 5f;   // ジャンプの力
    private bool isGrounded = false; // 地面についているかの判定

    private Rigidbody rb;
    private bool isStopped = false; // 停止状態の判定

    private Queue<Vector3> positionHistory = new Queue<Vector3>(); // 過去の位置を記録するキュー
    private float positionRecordInterval = 0.1f; // 位置記録の間隔 (0.1秒ごと)
    private float positionRecordTimer = 0f;    // タイマー
    private float rewindTime = 2f;            // 何秒前に戻るか

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyを取得
    }

    void Update()
    {
        // Sキーで停止・再開の切り替え
        if (Input.GetKey(KeyCode.S))
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }

        // 移動処理 (停止していない場合のみ)
        if (!isStopped)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // 位置を一定間隔で記録
        positionRecordTimer += Time.deltaTime;
        if (positionRecordTimer >= positionRecordInterval)
        {
            positionHistory.Enqueue(transform.position); // 現在の位置をキューに追加
            positionRecordTimer = 0f;

            // キューのサイズを2秒分に制限 (古いデータを削除)
            while (positionHistory.Count > Mathf.CeilToInt(rewindTime / positionRecordInterval))
            {
                positionHistory.Dequeue();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面についているかの判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // 障害物に接触した場合、2秒前の位置にテレポート
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (positionHistory.Count > 0)
            {
                transform.position = positionHistory.Peek(); // キューの先頭（最古の位置）にテレポート
            }
        }
    }
}

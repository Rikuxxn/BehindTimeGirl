using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMoverWithTrigger : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; // 移動方向（デフォルトは前方）
    public float speed = 5f;                   // 移動速度
    public Transform player;                   // プレイヤーオブジェクトのTransform
    public float activationRange = 10f;        // 起動する範囲の半径

    private bool isActive = false;             // 移動がアクティブかどうか
    private bool hasStarted = false;           // 一度でも移動を開始したかどうか
    private float activeTime = 0f;             // アクティブになってからの経過時間

    void Update()
    {
        if (!hasStarted)
        {
            // プレイヤーとの距離を測定
            float distance = Vector3.Distance(player.position, transform.position);

            // 範囲内なら移動を開始
            if (distance <= activationRange)
            {
                isActive = true;
                hasStarted = true; // 一度でも起動したことを記録
            }
        }

        // アクティブな場合に移動処理
        if (isActive)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);

            // 経過時間をカウント
            activeTime += Time.deltaTime;

            // 10秒経過したら削除
            if (activeTime >= 5f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Unityエディタで範囲を可視化（選択時のみ）
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, activationRange);
    }
}

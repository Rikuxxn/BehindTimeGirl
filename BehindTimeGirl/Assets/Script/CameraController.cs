using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;       // プレイヤーのTransform
    public Vector3 offset;         // カメラとプレイヤー間の固定オフセット
    public float lookAtOffsetX = -15f; // プレイヤーを左寄せにするための視点オフセット

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置を設定（プレイヤーの位置とオフセットを基に計算）
        transform.position = player.position + offset;
    }

    // LateUpdateはすべてのUpdate後に呼び出される
    void LateUpdate()
    {
        // プレイヤーの位置に基づいてカメラ位置を更新
        transform.position = player.position + offset;

        // カメラの視点をプレイヤーに向ける（少し左寄せ）
        Vector3 lookAtTarget = player.position;
        lookAtTarget.x -= lookAtOffsetX;
        transform.LookAt(lookAtTarget);
    }
}

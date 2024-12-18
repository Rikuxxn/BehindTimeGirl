using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightWithRange : MonoBehaviour
{
    public Light redLight;                    // 赤信号
    public Light greenLight;                  // 青信号
    public Transform car;                     // 車のTransform
    public float detectionRange = 10f;        // 信号が車を検知する範囲

    private bool isCarInRange = false;        // 車が範囲内にいるかどうか

    void Update()
    {
        // 車との距離を測定
        float distance = Vector3.Distance(car.position, transform.position);

        // 車が範囲内にいるかを判定
        isCarInRange = distance <= detectionRange;

        // 信号の状態を更新
        if (isCarInRange)
        {
            redLight.enabled = true;
            greenLight.enabled = false;
        }
        else
        {
            redLight.enabled = false;
            greenLight.enabled = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Unityエディタで範囲を可視化（選択時のみ）
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

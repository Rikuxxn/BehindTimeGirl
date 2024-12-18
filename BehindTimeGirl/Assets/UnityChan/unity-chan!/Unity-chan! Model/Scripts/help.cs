using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJumpPlayer : MonoBehaviour
{
    // 基本走行速度
    public float baseRunSpeed = 5f;
    // エンター連打による最大追加速度
    public float maxAdditionalSpeed = 5f;
    // エンター連打時の加速率
    public float speedIncreaseRate = 1f;
    // 速度減衰率
    public float speedDecreaseRate = 0.5f;
    // ジャンプ力
    public float jumpForce = 8f;

    // 現在の追加速度
    private float currentAdditionalSpeed = 0f;
    // 接地判定
    private bool isGrounded = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // エンターキー連打で速度上昇
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 最大追加速度に達していない場合のみ加速
            currentAdditionalSpeed = Mathf.Min(
                currentAdditionalSpeed + speedIncreaseRate,
                maxAdditionalSpeed
            );
        }
        else
        {
            // 速度を徐々に減衰
            currentAdditionalSpeed = Mathf.Max(
                currentAdditionalSpeed - speedDecreaseRate * Time.deltaTime,
                0
            );
        }

        // 合計速度での移動
        float totalSpeed = baseRunSpeed + currentAdditionalSpeed;
        transform.Translate(Vector3.right * totalSpeed * Time.deltaTime);

        // スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // 地面との接触判定
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
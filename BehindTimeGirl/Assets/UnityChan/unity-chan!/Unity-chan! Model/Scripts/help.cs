using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJumpPlayer : MonoBehaviour
{
    // ��{���s���x
    public float baseRunSpeed = 5f;
    // �G���^�[�A�łɂ��ő�ǉ����x
    public float maxAdditionalSpeed = 5f;
    // �G���^�[�A�Ŏ��̉�����
    public float speedIncreaseRate = 1f;
    // ���x������
    public float speedDecreaseRate = 0.5f;
    // �W�����v��
    public float jumpForce = 8f;

    // ���݂̒ǉ����x
    private float currentAdditionalSpeed = 0f;
    // �ڒn����
    private bool isGrounded = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �G���^�[�L�[�A�łő��x�㏸
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // �ő�ǉ����x�ɒB���Ă��Ȃ��ꍇ�̂݉���
            currentAdditionalSpeed = Mathf.Min(
                currentAdditionalSpeed + speedIncreaseRate,
                maxAdditionalSpeed
            );
        }
        else
        {
            // ���x�����X�Ɍ���
            currentAdditionalSpeed = Mathf.Max(
                currentAdditionalSpeed - speedDecreaseRate * Time.deltaTime,
                0
            );
        }

        // ���v���x�ł̈ړ�
        float totalSpeed = baseRunSpeed + currentAdditionalSpeed;
        transform.Translate(Vector3.right * totalSpeed * Time.deltaTime);

        // �X�y�[�X�L�[�ŃW�����v
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // �n�ʂƂ̐ڐG����
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
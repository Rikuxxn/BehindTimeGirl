using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;        // �v���C���[�̑���X�s�[�h
    public float jumpForce = 5f;   // �W�����v�̗�
    private bool isGrounded = false; // �n�ʂɂ��Ă��邩�̔���

    private Rigidbody rb;
    private bool isStopped = false; // ��~��Ԃ̔���

    private Queue<Vector3> positionHistory = new Queue<Vector3>(); // �ߋ��̈ʒu���L�^����L���[
    private float positionRecordInterval = 0.1f; // �ʒu�L�^�̊Ԋu (0.1�b����)
    private float positionRecordTimer = 0f;    // �^�C�}�[
    private float rewindTime = 2f;            // ���b�O�ɖ߂邩

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody���擾
    }

    void Update()
    {
        // S�L�[�Œ�~�E�ĊJ�̐؂�ւ�
        if (Input.GetKey(KeyCode.S))
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }

        // �ړ����� (��~���Ă��Ȃ��ꍇ�̂�)
        if (!isStopped)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // �X�y�[�X�L�[�ŃW�����v
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // �ʒu�����Ԋu�ŋL�^
        positionRecordTimer += Time.deltaTime;
        if (positionRecordTimer >= positionRecordInterval)
        {
            positionHistory.Enqueue(transform.position); // ���݂̈ʒu���L���[�ɒǉ�
            positionRecordTimer = 0f;

            // �L���[�̃T�C�Y��2�b���ɐ��� (�Â��f�[�^���폜)
            while (positionHistory.Count > Mathf.CeilToInt(rewindTime / positionRecordInterval))
            {
                positionHistory.Dequeue();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �n�ʂɂ��Ă��邩�̔���
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // ��Q���ɐڐG�����ꍇ�A2�b�O�̈ʒu�Ƀe���|�[�g
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (positionHistory.Count > 0)
            {
                transform.position = positionHistory.Peek(); // �L���[�̐擪�i�ŌÂ̈ʒu�j�Ƀe���|�[�g
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;        // �v���C���[�̑���X�s�[�h
    public float jumpForce = 5f;   // �W�����v�̗�
    private bool isGrounded = false; // �n�ʂɂ��Ă��邩�̔���

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody���擾
    }

    void Update()
    {
        // ��ɑO�i���� (W�L�[��������Ă��邩�̂悤�ȓ���)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // �X�y�[�X�L�[�ŃW�����v
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �n�ʂɂ��Ă��邩�̔���
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

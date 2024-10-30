using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpBrick : MonoBehaviour
{
    float jumpPower = 300f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpPower, ForceMode.Impulse);
            //<> �ڿ��� ()�� ���ϰ�
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; // ��ֹ� ������Ʈ��
    private bool stepped = false; // �÷��̾� ĳ���Ͱ� ��Ҵ°�

    //������Ʈ�� Ȱ��ȭ �� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        //������ �����ϴ� ó��

        //���� ���¸� ����
        stepped = false;

        // ��ֹ��� ����ŭ ����
        for (int i = 0;i <obstacles.Length; i++){

            // ���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
            if (Random.Range(0,3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false); 
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    // �÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
    {
        //�浹�� ������ �±װ� Player�̰� ������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
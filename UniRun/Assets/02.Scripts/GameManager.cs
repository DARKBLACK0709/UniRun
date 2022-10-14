using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// ���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameover = false; // ���ӿ��� ����
    public TextMeshProUGUI scoreText;  // ������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI; // ���ӿ��� �� Ȱ��ȭ�� UI ���� ������Ʈ

    private int score = 0; // ��������

    //���� ���۰� ���ÿ� �̱����� ����
     void Awake()
    {
        //�̱��� ���� instance�� ��� �ִ°�?
        if (instance == null)
        {
            // instance�� ��� �ִٸ�(unll) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this; 
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �� �� �̻��� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            // ���ӿ��� ���¿��� ���콺 ���� ��ư�� Ŭ���ϸ� ���� �� �����
            SceneManager.LoadScene(SceneManager. GetActiveScene().name);
        }
    }

    //������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ϶��
        if (!isGameover) // isGameover�� ���� true���
        {
            // ������ ����
            score += newScore;
            scoreText.text = "Score :" + score;
        }
    }

    //�÷��̾� ĳ���� ��� �� ���ӿ����� �����ϴ� �޼���
    public void OnPlayerDead()
    {
        //���� ���¸� ���ӿ��� ���·� ����
        isGameover = true;
        //���ӿ��� UI�� Ȱ��ȭ
        gameoverUI.SetActive(true);
    }

    public void Method(int num)
    {
        Time.timeScale = num;
    }
}

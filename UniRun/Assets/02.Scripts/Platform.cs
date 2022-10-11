using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; // 플레이어 캐릭터가 밝았는가

    //컴포넌트가 활성화 될 떄마다 매번 실행되는 메서드
    private void OnEnable()
    {
        //발판을 리셋하는 처리

        //밟힘 상태를 리셋
        stepped = false;

        // 장애물의 수만큼 루프
        for (int i = 0;i <obstacles.Length; i++){

            // 현재 순번의 장애물을 1/3의 확률로 활성화
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
    // 플레이어 캐릭터가 자신을 밝았을 때 점수를 추가하는 처리
    {
        //충돌한 상대방의 태그가 Player이고 이전에 플레이어 캐릭터가 밟지 않았다면
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

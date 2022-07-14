using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 배열: 하나의 변수로 여러개를 가져올 수 있게 해준다.

    public GameObject WinUI;
    public ItemBox[] itemBoxes;

    public bool isGameOver;

    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
            // => SceneManager.LoadScene("0");
        }

        if(isGameOver == true)
        {
            return; // 1. 결과값을 전달한다
                    // 2. 함수가 결과를 냈기 때문에 코드를 종료한다.
        }

        int count = 0;
        for (int i= 0; i<3; i++) // 순번 -> 조건 -> 갱신
        {
            if (itemBoxes[i].isOveraped == true)
            {
                count++;
            }
        }

        if (count >= 3)
        {
            isGameOver = true;
            Debug.Log("Game Clear!");
            WinUI.SetActive(true);           
        }
    }
}

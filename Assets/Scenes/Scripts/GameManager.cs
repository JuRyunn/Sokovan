using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �迭: �ϳ��� ������ �������� ������ �� �ְ� ���ش�.

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
            return; // 1. ������� �����Ѵ�
                    // 2. �Լ��� ����� �±� ������ �ڵ带 �����Ѵ�.
        }

        int count = 0;
        for (int i= 0; i<3; i++) // ���� -> ���� -> ����
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

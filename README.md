### :pushpin: UNITY 3D GAME: SOKOVAN


##### TIL
- [20220711](https://github.com/JuRyunn/Sokovan/blob/main/TIL/20220711.md)
- [20220712](https://github.com/JuRyunn/Sokovan/blob/main/TIL/20220712.md)
- [20220713](https://github.com/JuRyunn/Sokovan/blob/main/TIL/20220713.md)
- [20220714](https://github.com/JuRyunn/Sokovan/blob/main/TIL/20220714.md)

<br>

![image](https://user-images.githubusercontent.com/79950504/178995772-34f2794c-055a-422c-aef3-6af4df55869a.png)
- Yellow Circle: Player
- Red Box: ItemBox
- Green Box: EndPoint
- Player가 방향키를 이용하여 ItemBox를 Endpoint로 전부 밀어 넣는 간단한 퍼즐 게임.

<br>

### Player 움직임 제어 코드
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameManager gameManager;

    // float speed= 10f; (내부적으로 private 처리가 된다.
    // └[ private float speed= 10f; ] )
    public float speed = 10f; 
    public Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (gameManager.isGameOver == true)
        {
            return;
        }

        // 수평방향에 대해 키보드 입력을 -1 ~ +1 값을 준다.
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float fallSpeed = playerRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        
        velocity = velocity * speed;
        velocity.y = fallSpeed;

        playerRigidbody.velocity= velocity;
    }
}

```

<br>

### GameManager 코드
```C#
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

```

<br>

### ItemBox 제어 코드
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    
    public bool isOveraped = false;

    private Renderer myRenderer;
    public Color touchColor;
    private Color originalColor;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;         
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = false;
            myRenderer.material.color = originalColor;
        }
    }
}
```

<br>

### Endpoint 회전 코드
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{  
    void Update()
    {
        transform.Rotate(60 * Time.deltaTime, 60 * Time.deltaTime, 60 * Time.deltaTime);
    }
}
```



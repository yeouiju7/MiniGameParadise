// PlayerController.cs
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 터치(클릭) 시 아래로 떨어지는 힘의 크기
    public float dropForce = 8f;

    // Rigidbody 컴포넌트 참조
    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 사용자가 화면을 터치하거나 마우스 왼쪽 버튼을 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            HandleDrop();
        }
    }

    // 캐릭터를 아래로 떨어지게 하는 함수
    void HandleDrop()
    {
        // 캐릭터의 현재 y축 속도를 0으로 초기화 (관성 제거)
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        // 아래쪽 방향(-Vector2.up)으로 힘을 가합니다. 
        // ForceMode.VelocityChange를 사용하면 질량과 상관없이 바로 속도를 변화시킵니다.
        rb.AddForce(-Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    // 충돌 처리 (발판 파괴 로직은 여기에 추가됩니다)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 2단계에서 발판 태그를 "Floor"로 지정할 예정입니다.
        if (collision.gameObject.CompareTag("Floor"))
        {
            // 발판이 플레이어의 아래쪽에 있을 때만 파괴되도록 조건 추가
            // (플레이어가 발판 위에서 떨어지는 경우)
            if (collision.transform.position.y < transform.position.y)
            {
                // 발판 파괴 함수 호출 (2단계에서 구현)
                Destroy(collision.gameObject);
            }
        }
    }
}
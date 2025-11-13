using Unity.VisualScripting;
using UnityEngine;
// using을 사용해서 자주 쓰는 namespace, enum을 줄여 쓸 수 있다.
using GMState = GameManager.State;

public class BirdControl : MonoBehaviour
{
    [SerializeField] float velocity = 1.5f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] Animator flapAnim;
    [SerializeField] Animator birdAnim;
    Rigidbody2D rb;
    GameManager gmI;

    void Start()
    {
        // 자주 쓰려고 만든 Instance 연결
        gmI = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        // 처음 시작 시 안 떨어지게 중력값 조정
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 게임 상태가 READY면
            if (gmI.GameState == GMState.READY)
            {
                // 게임 상태를 PLAY로 바꾸고
                gmI.GamePlay();
                // Bird가 떨어지도록 중력값 변경
                rb.gravityScale = 1.0f;
            }
            else if (gmI.GameState == GMState.PLAY) // 게임 상태가 PLAY면
            {
                rb.velocity = Vector2.up * velocity;
            }
        }
    }
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotateSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 게임 PLAY일 때만 충돌 감지
        if (gmI.GameState != GMState.PLAY) return;

        gmI.GameOver();
        // 새의 Flap 애니메이션을 멈춘다.
        // GetComponent<Animator>().enabled = false;
        flapAnim.enabled = false;
    }

    public void BirdReady()
    {
        // 새를 뒤로 움직이는 애니메이션 실행.
        birdAnim.SetTrigger("Ready");
    }

    public void OffBirdAnimator()
    {
        // Bird의 애니메이션을 끈다.(* BirdFlap이 아님!!)
        birdAnim.enabled = false;
    }
}

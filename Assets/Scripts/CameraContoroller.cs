// CameraController.cs
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 추적할 대상 (플레이어) (Inspector에서 연결)
    public Transform target;

    // 카메라가 따라가는 속도 (0에 가까울수록 느려지고 1에 가까울수록 즉시 따라갑니다)
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.125f;

    // 카메라의 기본 X 좌표 (중앙)
    private float initialX;

    void Start()
    {
        // 카메라의 X축 위치를 저장해 둡니다. (가로 스크롤 방지)
        initialX = transform.position.x;
    }

    // Update 대신 LateUpdate를 사용하여, 모든 오브젝트의 이동 처리가 끝난 후 카메라를 움직이게 합니다.
    void LateUpdate()
    {
        // 플레이어의 현재 Y 좌표를 가져옵니다.
        float targetY = target.position.y;

        // 카메라의 목표 위치를 설정합니다. X는 고정하고 Z는 카메라 시점 그대로 유지합니다.
        Vector3 targetPosition = new Vector3(initialX, targetY, transform.position.z);

        // Lerp 함수를 사용하여 현재 위치에서 목표 위치까지 부드럽게 이동합니다.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // 카메라 위치 업데이트
        transform.position = smoothedPosition;
    }
}
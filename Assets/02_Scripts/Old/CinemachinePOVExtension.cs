using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{

    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]    //수직 ㅏㄱㄱ도 제한
    private float clampAngle = 80f;


    private InputManager inputManager;
    private Vector3 startingRotation;   //시작 회전을 고정

    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }


    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, 
                                                        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow) //우리가 대상으 ㄹ따르고 있는 지 확인
        {
            if(stage == CinemachineCore.Stage.Aim)  //스테이지를 통과하면? 현재 카메라가 맞는지 확인하는
            {   //마우스의 VEctor2 값을 받는다
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = inputManager.GetMousDelta();
                Debug.Log($"{deltaInput.x}, {deltaInput.y}");
                startingRotation.x = deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y = deltaInput.y * horizontalSpeed * Time.deltaTime; 
                //각도 제한
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                //회전
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }
}

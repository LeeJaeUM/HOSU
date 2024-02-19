using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{

    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]    //���� �������� ����
    private float clampAngle = 80f;


    private InputManager inputManager;
    private Vector3 startingRotation;   //���� ȸ���� ����

    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }


    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, 
                                                        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow) //�츮�� ����� �������� �ִ� �� Ȯ��
        {
            if(stage == CinemachineCore.Stage.Aim)  //���������� ����ϸ�? ���� ī�޶� �´��� Ȯ���ϴ�
            {   //���콺�� VEctor2 ���� �޴´�
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = inputManager.GetMousDelta();
                Debug.Log($"{deltaInput.x}, {deltaInput.y}");
                startingRotation.x = deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y = deltaInput.y * horizontalSpeed * Time.deltaTime; 
                //���� ����
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                //ȸ��
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }
}

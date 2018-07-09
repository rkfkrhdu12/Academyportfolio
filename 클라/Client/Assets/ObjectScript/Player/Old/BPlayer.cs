using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eModCount
{
    MOVE,
    ATTACK,
    ANI,
    CAMERAROT,
    INPUTKEY,
}


public class BPlayer : MonoBehaviour
{
    public float _forwardSpeed;
    public float _MaxforwardSpeed = 1;
    public float _sideSpeed;
    public float _MaxsideSpeed = 1;
    
    public float _gravityPower = -9.8f;
    public float _gravityAccel = -20;
    public float _jumpPower = 2;

    public bool _isMoveAble = true;
    public bool _isMove = false;
    public bool _isJump = false;
    public bool _isAttack = false;
    public bool _isCamera = true;
    public bool _isRun = false;

    public float _SkillProgressTime = 1f;

    public List<Module> _list = new List<Module>();

    public CharacterController _charcontrol;

    public static BPlayer MainPlayer;

    void Init()
    {
        _charcontrol = transform.GetComponent<CharacterController>();

        Module[] module = new Module[5];
        int i = 0;
        module[i++] = new Move();
        module[i++] = new Attack();
        module[i++] = new Ani();
        module[i++] = new CameraRot();
        module[i++] = new InputKey();

        foreach (Module j in module)
            _list.Add(j);
    }

    void Awake()
    {
        MainPlayer = this;
    }

    void Start()
    {
        Init();

        foreach (Module i in _list)
            i.Init(this);

        foreach (Module i in _list)
            i.Start();
    }

    void Update()
    {
        foreach (Module i in _list)
           i.Update();
    }
}

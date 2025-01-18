using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DecisionTree;
using BehaviourTrees;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public float m_decisionTime;

    public float m_hungryValue;
    [HideInInspector]
    public float m_energeValue;
    [HideInInspector]
    public bool m_isGoodHumor;

    DecisionTreeNode rootNode;

    BehaviourTrees.BehaviourTree behaviourTree;
    [HideInInspector]
    public bool isInBed;

    StateMachine m_statemchine;

    HierarchicalStateMachine m_HFSM;

    [SerializeField]
    float speed;
    [SerializeField]
    float y;

    public float Speed { get => speed; set => speed = value; }
    public float Y { get => y; set => y = value; }

    public void InitBehaviourTree()
    {
        Cooking cooking = new Cooking();
        Dining dining = new Dining();
        Washing washing = new Washing();
        Clean clean = new Clean();
        PlayingIphone playingIphone = new PlayingIphone();
        BehaviourTrees.RandomSelector selector = new BehaviourTrees.RandomSelector();
        InBed inBed = new InBed(this);
        BehaviourTrees.Sequence sequence = new BehaviourTrees.Sequence();
        selector.AddChild(inBed);
        selector.AddChild(washing);
        selector.AddChild(clean);
        selector.AddChild(playingIphone);
        sequence.AddChild(cooking);
        sequence.AddChild(dining);
        sequence.AddChild(selector);
        behaviourTree = new BehaviourTrees.BehaviourTree();
        behaviourTree.AddChild(sequence);
        StartCoroutine(StartAIDecision2());
    }

    IEnumerator StartAIDecision2()
    {
        yield return new WaitForSeconds(m_decisionTime);
        behaviourTree.Process();
        StopCoroutine(StartAIDecision2());
        StartCoroutine(StartAIDecision2());
    }

    public void InitDecisionTree()
    {
        CookingAction cookAction = new CookingAction();
        OrderTakeOutsAction orderAction = new OrderTakeOutsAction();
        ProgrameAction programeAction = new ProgrameAction();
        PlayPhoneAction playPhoneAction = new PlayPhoneAction();
        FloatDecisionNode energeValue = new EnergeDecisionNode(this, float.MaxValue, 80, cookAction, orderAction);
        BoolDecisionNode isGoodHumor = new IsGoodHumor(this, programeAction, playPhoneAction);
        rootNode = new HungryDecisionNode(this, float.MaxValue, 50, isGoodHumor, energeValue);
        StartCoroutine(StartAIDecision());
    }

    IEnumerator StartAIDecision()
    {
        yield return new WaitForSeconds(m_decisionTime);
        ActionNode action = (ActionNode)rootNode.makeDecision();
        action.HandlerAction();
        StopCoroutine(StartAIDecision());
        StartCoroutine(StartAIDecision());
    }


    public void InitFSM()
    {
        this.m_statemchine = new StateMachine();
        this.m_statemchine.SwitchState(new Idle(this,m_statemchine));
    }

    public void Update()
    {
        this.m_statemchine?.Update();
    }

    public void InitHFSM()
    {
        #region 初始化状态
        DoubleJumpState doubleJumpState = new DoubleJumpState();
        JumpState jumpState = new JumpState();
        RunState runState = new RunState();
        WalkState walkState = new WalkState();
        IdleState idleState = new IdleState();
        JumpMachineState jumpMachineState = new JumpMachineState(jumpState);
        MovementMachineState movementMachineState = new MovementMachineState(walkState);
        jumpMachineState.AddState(StateEnum.idle, idleState);
        jumpMachineState.AddState(StateEnum.jump,jumpState);
        jumpMachineState.AddState(StateEnum.doublejump,doubleJumpState);

        movementMachineState.AddState(StateEnum.idle,idleState);
        movementMachineState.AddState(StateEnum.walk,walkState);
        movementMachineState.AddState(StateEnum.run,runState);
        movementMachineState.AddState(StateEnum.jumpSubFSM,jumpMachineState);

        this.m_HFSM = new HierarchicalStateMachine(idleState);
        this.m_HFSM.AddState(StateEnum.idle, idleState);
        this.m_HFSM.AddState(StateEnum.movementSubFSM, movementMachineState);

        #endregion
        #region 初始化过渡
        IdleStateTransition idleTransition = new IdleStateTransition(this);
        RunTransition runTransition = new RunTransition(this);
        DoubleJumpTransition doubleJumpTransition = new DoubleJumpTransition(this);
        MovementFSMTransition movementFSMTransition = new MovementFSMTransition(this);
        JumpFSMTransition jumpFSMTransition = new JumpFSMTransition(this);

        idleState.AddTransition(movementFSMTransition);
        movementMachineState.AddTransition(idleTransition);
        movementMachineState.AddTransition(jumpFSMTransition);

        walkState.AddTransition(idleTransition);
        walkState.AddTransition(runTransition);        
        walkState.AddTransition(jumpFSMTransition);

        runState.AddTransition(idleTransition);
        runState.AddTransition(movementFSMTransition);
        runState.AddTransition(jumpFSMTransition);

        jumpMachineState.AddTransition(movementFSMTransition);
        jumpMachineState.AddTransition(runTransition);

        jumpState.AddTransition(idleTransition);
        jumpState.AddTransition(movementFSMTransition);
        jumpState.AddTransition(doubleJumpTransition);

        doubleJumpState.AddTransition(idleTransition);
        #endregion
    }

    float gravity = 0.98f;

    public void UpdateHFSM()
    {
        this.speed = Mathf.Abs(Input.GetAxis("Horizontal") * 5);
        
        if (Input.GetKey(KeyCode.Space))
        {
            this.y = 2.5f;
        }
        if (Input.GetKey(KeyCode.M))
        {
            this.y = 5.5f;
        }

        if(this.y > 0)
        {
            this.y -= gravity * Time.deltaTime;
            this.y = Mathf.Max(0, this.y);
        }

        this.m_HFSM?.update();
    }
}

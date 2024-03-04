using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class DetectTarget : ActionNode
{
    [SerializeField] float detectionRadius;
    [SerializeField] LayerMask targetMask;

    protected override string NodeDescription()
    {
        return "Detect targets, which belong to the targetMask layer, in a certain area around the unit.";
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(context.transform.position, detectionRadius);
    }

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        var colls = Physics2D.OverlapCircleAll(context.transform.position, detectionRadius, targetMask);
        if (colls.Length > 0)
            return State.Success;
        else
            return State.Failure;
    }
}

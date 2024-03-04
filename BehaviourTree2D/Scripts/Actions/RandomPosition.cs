using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomPosition : ActionNode
{
    [SerializeField] float randomRange = 10f;

    protected override string NodeDescription()
    {
        return "Generate a random position within the specified range around the unit and saves it in the black-board";
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(context.transform.position, randomRange);
    }

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        blackboard.moveToPosition = context.transform.position + Random.insideUnitSphere * randomRange;
        return State.Success;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveToPosition : ActionNode
{
    [SerializeField] float speed = 5;
    [SerializeField] float stoppingDistance = 0.1f;

    protected override string NodeDescription()
    {
        return "The unit move to the saved target position (refer to black-board).";
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = gizmoColor;
        Gizmos.DrawLine(context.transform.position, blackboard.moveToPosition);
    }

    protected override void OnStart() 
    {
        
    }

    protected override void OnStop() 
    {

    }

    protected override State OnUpdate() 
    {
        float dist = Vector2.Distance(context.transform.position, blackboard.moveToPosition);
        if (dist > stoppingDistance) 
        {
            Vector2 velocity = blackboard.moveToPosition - (Vector2)context.transform.position;
            context.physics.velocity = velocity.normalized * speed;
            return State.Running;
        }
        else
        {
            context.physics.velocity = Vector2.zero;
            return State.Success;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Reaction : ActionNode
{
    protected override void OnStart() 
    {
        MonoBehaviour.print("reaction !!");
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        return State.Running;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TheKiwiCoder 
{
    public class Context 
    {
        public GameObject gameObject;
        public Transform transform;
        public Animator animator;
        public SpriteRenderer spriteRenderer;
        public Rigidbody2D physics;
        public CircleCollider2D sphereCollider;
        public BoxCollider2D boxCollider;
        public CapsuleCollider2D capsuleCollider;

        public static Context CreateFromGameObject(GameObject gameObject) {
            Context context = new Context
            {
                gameObject = gameObject,
                transform = gameObject.transform,
                spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>(),
                animator = gameObject.GetComponentInChildren<Animator>(),
                physics = gameObject.GetComponent<Rigidbody2D>(),
                sphereCollider = gameObject.GetComponent<CircleCollider2D>(),
                boxCollider = gameObject.GetComponent<BoxCollider2D>(),
                capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>()
            };

            return context;
        }
    }
}
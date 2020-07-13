using System;
using System.Collections.Generic;
using UnityEngine;

// Event agregator
public static class GEvent
{
    public static readonly GEvent_BulletHitEnemy BulletHitEnemy = new GEvent_BulletHitEnemy();
}


// TODO: Move to package
public class GEvent_BulletHitEnemy
    {
        private readonly List<Action<GEventData_BulletHitEnemy>> _callbacks = new List<Action<GEventData_BulletHitEnemy>>();

        public void Subscribe(Action<GEventData_BulletHitEnemy> callback)
        {
            _callbacks.Add(callback);
        }
        
        public void UnSubscribe(Action<GEventData_BulletHitEnemy> callback)
        {
            _callbacks.Remove(callback);
        }

        public void Invoke(GEventData_BulletHitEnemy data)
        {
            foreach (Action<GEventData_BulletHitEnemy> callback in _callbacks)
                callback(data);
        }
    }

// TODO: Move to package
public class GEventData_BulletHitEnemy
{
    public Vector3 HitPosition;
    public Vector3 HitDirection;
    public Rigidbody RigidBody;
    public float Power;
        
    public GEventData_BulletHitEnemy(Vector3 HitPosition, Vector3 HitDirection, Rigidbody RigidBody, float Power)
    {
        this.HitPosition = HitPosition;
        this.HitDirection = HitDirection;
        this.RigidBody = RigidBody;
        this.Power = Power;
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using BehaviourEngine;

namespace BehaviourEngine
{
    public class Transform : Component
    {
        public Transform Parent { get; protected set; }

        #region Position
        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (Parent != null)
                {
                    //recalculate offset
                    LocalPosition = this.position - Parent.position;
                }

                for (int i = 0; i < childs.Count; i++)
                {
                    childs[i].UpdateChildPosition();
                }
            }
        }

        public Vector2 LocalPosition;
        #endregion

        #region Rotation
        private float rotation;
        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;

                for (int i = 0; i < childs.Count; i++)
                {
                    childs[i].UpdateChildRotation();
                }
            }
        }

        private float previousParentRotation;
        public float EulerRotation
        {
            get
            {
                //deg
                return Rotation.RadToDeg();
            }
            set
            {
                //rad
                Rotation = value.DegToRad();
            }
        }
        #endregion

        #region Scale
        private Vector2 scale = Vector2.One;
        public Vector2 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;

                for (int i = 0; i < childs.Count; i++)
                {
                    childs[i].UpdateChildScale();
                }
            }
        }

        private Vector2 previousParentScale;
        #endregion

        internal static Transform InitInternalTransform(GameObject owner)
        {
            Transform internalTransform = new Transform()
            {
                Position = owner.Transform.Position,
                Rotation = owner.Transform.Rotation,
                Scale = owner.Transform.Scale
            };

            internalTransform.SetParent(owner.Transform);
            owner.AddComponent<Transform>(internalTransform);

            return internalTransform;
        }
        public void SetParent(Transform parent)
        {
            if (parent == Parent)
                return;

            if (Parent != null)
            {
                Parent.RemoveChild(this);
            }

            if (parent != null)
            {
                parent.AddChild(this);

                //calculate without property
                LocalPosition = this.position - parent.position;

                //save previous parent rot
                previousParentRotation = parent.Rotation;

                //save previous parent scale
                previousParentScale = parent.Scale;
            }

            this.Parent = parent;
        }

        #region Child Handling
        private List<Transform> childs = new List<Transform>();

        public Transform[] GetChilds()
        {
            Transform[] array = new Transform[childs.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = childs[i];
            }
            return array;
        }
        private void UpdateChildPosition()
        {
            Position = Parent.Position + LocalPosition;
        }
        private void UpdateChildRotation()
        {
            //delta from previous frame to current frame
            float deltaAngle = Parent.Rotation - previousParentRotation;

            //Change Rotation
            this.Rotation += deltaAngle;

            //Change Position
            Matrix2 newRotation = Matrix2.CreateRotation(-deltaAngle);
            LocalPosition = newRotation.PerVector2(LocalPosition);
            this.position = Parent.position + LocalPosition;

            //save prev parent rot
            previousParentRotation = Parent.Rotation;
        }
        private void UpdateChildScale()
        {
            //Calculate scale difference between previous and current parent scale
            Vector2 parentScaleRatio = new Vector2(Parent.Scale.X / previousParentScale.X, Parent.Scale.Y / previousParentScale.Y);

            Scale = Scale * parentScaleRatio;

            //change position
            Position = Parent.Position + LocalPosition * parentScaleRatio;

            ////save prev parent scale
            previousParentScale = Parent.Scale;
        }
        private void AddChild(Transform child)
        {
            if (!childs.Contains(child))
            {
                childs.Add(child);
            }
        }
        private void RemoveChild(Transform child)
        {
            childs.Remove(child);
        }
        #endregion
    }
}

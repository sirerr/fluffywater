using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater
{

    public class playerRecticle : GvrBasePointer
    {


        // Minimum distance of the reticle (in meters).
        public const float RETICLE_DISTANCE_MIN = 0.45f;
        // Maximum distance of the reticle (in meters).
        public const float RETICLE_DISTANCE_MAX = 10.0f;

        public float ReticleDistanceInMeters { get; private set; }

        public override void OnStart()
        {
            base.OnStart();
        }

        public void Awake()
        {

        }

        public override float MaxPointerDistance
        {
            get
            {
                return RETICLE_DISTANCE_MAX;
            }
        }

        /// This is called when the 'BaseInputModule' system should be enabled.
        public override void OnInputModuleEnabled() { }

        /// This is called when the 'BaseInputModule' system should be disabled.
        public override void OnInputModuleDisabled() { }

        public override void OnPointerEnter(GameObject targetObject, Vector3 intersectionPosition,
            Ray intersectionRay, bool isInteractive)
        {
            SetPointerTarget(intersectionPosition, isInteractive);
        }

        private bool SetPointerTarget(Vector3 target, bool interactive)
        {
            if (base.PointerTransform == null)
            {
                Debug.LogWarning("Cannot operate on a null pointer transform");
                return false;
            }
            Vector3 targetLocalPosition = base.PointerTransform.InverseTransformPoint(target);

            return true;
        }

        /// Called when a trigger event is initiated. This is practically when
        /// the user begins pressing the trigger.
        public override void OnPointerClickDown() { }

        /// Called when a trigger event is finished. This is practically when
        /// the user releases the trigger.
        public override void OnPointerClickUp() { }

        /// Called every frame the user is still pointing at a valid GameObject. This
        /// can be a 3D or UI element.
        ///
        /// The targetObject is the object the user is pointing at.
        /// The intersectionPosition is where the ray intersected with the targetObject.
        /// The intersectionRay is the ray that was cast to determine the intersection.
        public override void OnPointerHover(GameObject targetObject, Vector3 intersectionPosition,
            Ray intersectionRay, bool isInteractive)
        {
            SetPointerTarget(intersectionPosition, isInteractive);
        }

        public override void OnPointerExit(GameObject targetObject)
        {
            ReticleDistanceInMeters = RETICLE_DISTANCE_MAX;

        }

        public override void GetPointerRadius(out float enterRadius, out float exitRadius)
        {
            enterRadius = 2.0f;
            exitRadius = 2.0f;
        }


    }
}
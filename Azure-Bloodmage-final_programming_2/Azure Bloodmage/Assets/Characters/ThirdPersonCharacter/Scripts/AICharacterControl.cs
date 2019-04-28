using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
		public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; } // the character we are controlling
		public Transform target;                                    // target to aim for
		private bool isDetected;
		private bool prev_detectState;
		public Transform[] points;
		private int destPoint = 0;
		public int detectionDistance;
		
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
			
	        agent.updateRotation = false;
	        agent.updatePosition = true;
			isDetected = false;
        }


        private void Update()
        {
			GotoNextPoint();

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

			prev_detectState = isDetected;
        }
		
		public static string GetGameObjectPath(GameObject obj)
		{
			string path = "/" + obj.name;
			while (obj.transform.parent != null)
			{
				obj = obj.transform.parent.gameObject;
				path = "/" + obj.name + path;
			}
			return path;
		}
		
		public IEnumerator DetectionCountdown(){
			agent.SetDestination(target.position);
			yield return new WaitForSeconds(5f);
			isDetected = false;
		}
		
		void GotoNextPoint() {
			if (points.Length == 0)
				return;

			agent.destination = points[destPoint].position;
			destPoint = (destPoint + 1) % points.Length;
		}

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
		
		
        public void SetPoints(Transform[] points)
        {
            this.points = points;
        }
    }
}

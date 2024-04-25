using UnityEngine;
using System.Collections.Generic;


namespace BioIK {

	[AddComponentMenu("")]
	public class PerpRotation : BioObjective {

        [SerializeField] public Transform Target;
        [SerializeField] private double UPX, UPY, UPZ, TPX, TPY, TPZ;
        [SerializeField] private double MaximumError = 0.001;

		public override ObjectiveType GetObjectiveType() {
			return ObjectiveType.PerpRotation;
		}

		public override void UpdateData() {
            if(Target != null){
                Vector3 up = Target.up;
                //Debug.Log(up);
                UPX = up.x;
                UPY = up.y;
                UPZ = up.z;
            }
		}

		public override double ComputeLoss(double WPX, double WPY, double WPZ, double WRX, double WRY, double WRZ, double WRW, Model.Node node, double[] configuration) {
            double crossx = UPY*WRZ - UPZ*WRY;
            double crossy = UPZ*WRX - UPX*WRZ;
            double crossz = UPX*WRY - UPY*WRX;
            double sum = crossx+crossy+crossz;
            if(sum < 0)
            {
                sum = -1*sum;
            }
            //Debug.Log(sum*sum);
            return sum;
		}

		public override bool CheckConvergence(double WPX, double WPY, double WPZ, double WRX, double WRY, double WRZ, double WRW, Model.Node node, double[] configuration) {
            double crossx = UPY*WRZ - UPZ*WRY;
            double crossy = UPZ*WRX - UPX*WRZ;
            double crossz = UPX*WRY - UPY*WRX;
            double sum = crossx+crossy+crossz;
            if(sum < 0)
            {
                sum = -1*sum;
            }

            return sum <= MaximumError;
		}

		public override double ComputeValue(double WPX, double WPY, double WPZ, double WRX, double WRY, double WRZ, double WRW, Model.Node node, double[] configuration) {
            double crossx = UPY*WRZ - UPZ*WRY;
            double crossy = UPZ*WRX - UPX*WRZ;
            double crossz = UPX*WRY - UPY*WRX;
            double sum = crossx+crossy+crossz;
            if(sum < 0)
            {
                sum = -1*sum;
            }

            return sum;
		}
		
		public void SetMaximumError(double units) {
			MaximumError = units;
		}

		public double GetMaximumError() {
			return MaximumError;
		}
        
        public void SetTargetTransform(Transform target) {
			Target = target;
			if(Target != null) {
				SetTargetPosition(Target.position);
			}
		}

        public Transform GetTargetTransform(){
            return Target;
        }

        public void SetTargetPosition(Vector3 position) {
			TPX = position.x;
			TPY = position.y;
			TPZ = position.z;
		}

        public Vector3 GetTargetPosition() {
			return new Vector3((float)TPX, (float)TPY, (float)TPZ);
		}

        // provides a quaterion, diff, such that a * diff = b
        private Quaternion QuatDiff(Quaternion a, Quaternion b)
        {
            return Quaternion.Inverse(a) * b;
        }

	}
	
}
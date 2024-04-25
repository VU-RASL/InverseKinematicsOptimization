using UnityEngine;
using System.Collections.Generic;


namespace BioIK {

	[AddComponentMenu("")]
	public class Pose : BioObjective {

        [SerializeField] private Transform Root;
        [SerializeField] private Transform Target;
        [SerializeField] private Transform TargetRoot;
        [SerializeField] private double RPX, RPY, RPZ, TPX, TPY, TPZ, RTPX, RTPY, RTPZ; //position variables
        [SerializeField] private double TRX, TRY, TRZ, TRW;                             //rotation variables
        [SerializeField] private Quaternion diff;
        [SerializeField] private double MaximumError = 0.001;

		public override ObjectiveType GetObjectiveType() {
			return ObjectiveType.Pose;
		}

		public override void UpdateData() {
            if(Root != null){
                Vector3 position = Root.position;
                RPX = position.x;
                RPY = position.y;
                RPZ = position.z;
            }
            if(Target != null){
                Vector3 position = Target.position;
                TPX = position.x;
                TPY = position.y;
                TPZ = position.z;
            }
            if(TargetRoot != null){
                Vector3 position = TargetRoot.position;
                RTPX = position.x;
                RTPY = position.y;
                RTPZ = position.z;
            }
            if(TargetRoot != null && Target != null)
            {
                Quaternion tdiff = Root.rotation * QuatDiff(TargetRoot.rotation,Target.rotation);
                TRX = tdiff.x;
                TRY = tdiff.y;
                TRZ = tdiff.z;
                TRW = tdiff.w;
            }
		}

		public override double ComputeLoss(double WPX, double WPY, double WPZ, double WRX, double WRY, double WRZ, double WRW, Model.Node node, double[] configuration) {
          	double d = WRX*TRX + WRY*TRY + WRZ*TRZ + WRW*TRW;
			if(d < 0.0) {
				d = -d;
				if(d > 1.0) {
					d = 1.0;
				}
			} else if(d > 1.0) {
				d = 1.0;
			}
			double rloss = 2.0 * System.Math.Acos(d);
            return Weight * (
                ((TPX-RTPX)-(WPX-RPX))*((TPX-RTPX)-(WPX-RPX))
                + ((TPY-RTPY)-(WPY-RPY))*((TPY-RTPY)-(WPY-RPY))
                + ((TPZ-RTPZ)-(WPZ-RPZ))*((TPZ-RTPZ)-(WPZ-RPZ))
                + rloss * rloss * 0.25
                );
		}

		public override bool CheckConvergence(double WPX, double WPY, double WPZ, double WRX, double WRY, double WRZ, double WRW, Model.Node node, double[] configuration) {
            double d = WRX*TRX + WRY*TRY + WRZ*TRZ + WRW*TRW;
			if(d < 0.0) {
				d = -d;
				if(d > 1.0) {
					d = 1.0;
				}
			} else if(d > 1.0) {
				d = 1.0;
			}
			double rloss = 2.0 * System.Math.Acos(d);
            return System.Math.Sqrt((
                ((TPX-RTPX)-(WPX-RPX))*((TPX-RTPX)-(WPX-RPX))
                + ((TPY-RTPY)-(WPY-RPY))*((TPY-RTPY)-(WPY-RPY))
                + ((TPZ-RTPZ)-(WPZ-RPZ))*((TPZ-RTPZ)-(WPZ-RPZ))
                + rloss * rloss * 0.25
                )) <= MaximumError;
		}

		public override double ComputeValue(double WPX, double WPY, double WPZ, double WRX, double WRY, double WRZ, double WRW, Model.Node node, double[] configuration) {
            double d = WRX*TRX + WRY*TRY + WRZ*TRZ + WRW*TRW;
			if(d < 0.0) {
				d = -d;
				if(d > 1.0) {
					d = 1.0;
				}
			} else if(d > 1.0) {
				d = 1.0;
			}
			double rloss = 2.0 * System.Math.Acos(d);
            return System.Math.Sqrt((
                ((TPX-RTPX)-(WPX-RPX))*((TPX-RTPX)-(WPX-RPX))
                + ((TPY-RTPY)-(WPY-RPY))*((TPY-RTPY)-(WPY-RPY))
                + ((TPZ-RTPZ)-(WPZ-RPZ))*((TPZ-RTPZ)-(WPZ-RPZ))
                + rloss * rloss * 0.25
                ));
		}

        public void SetRootTransform(Transform target) {
			Root = target;
			if(Root != null) {
				SetRootPosition(Root.position);
			}
		}

        public void SetTargetTransform(Transform target) {
			Target = target;
			if(Target != null) {
				SetTargetPosition(Target.position);
			}
		}

        public void SetTargetRootTransform(Transform target) {
			TargetRoot = target;
			if(TargetRoot != null) {
				SetTargetRootPosition(TargetRoot.position);
			}
		}

        public Transform GetRootTransform(){
            return Root;
        }

        public Transform GetTargetTransform(){
            return Target;
        }

        public Transform GetTargetRootTransform(){
            return TargetRoot;
        }

        public void SetRootPosition(Vector3 position) {
			RPX = position.x;
			RPY = position.y;
			RPZ = position.z;
		}

        public void SetTargetPosition(Vector3 position) {
			TPX = position.x;
			TPY = position.y;
			TPZ = position.z;
		}

        public void SetTargetRootPosition(Vector3 position) {
			RTPX = position.x;
			RTPY = position.y;
			RTPZ = position.z;
		}

		public Vector3 GetRootPosition() {
			return new Vector3((float)RPX, (float)RPY, (float)RPZ);
		}

        public Vector3 GetTargetPosition() {
			return new Vector3((float)TPX, (float)TPY, (float)TPZ);
		}

        public Vector3 GetTargetRootPosition() {
			return new Vector3((float)RTPX, (float)RTPY, (float)RTPZ);
		}
		
		public void SetMaximumError(double units) {
			MaximumError = units;
		}

		public double GetMaximumError() {
			return MaximumError;
		}

        // provides a quaterion, diff, such that a * diff = b
        private Quaternion QuatDiff(Quaternion a, Quaternion b)
        {
            return Quaternion.Inverse(a) * b;
        }

	}
	
}
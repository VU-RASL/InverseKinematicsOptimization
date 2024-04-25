using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using System;
public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // double[] test = {1,2,3};
        // var gradientVector = Vector<double>.Build.DenseOfArray(test);
    }

    // Update is called once per frame
    void Update()
    {
        // var jacobian = ComputeJacobian(0,0,0,0,0,0,0);
        // var inverse = ComputeInverse(jacobian);
        // Debug.Log("Running!");
    }

    private double convertRadians(double theta) {
        return theta * Math.PI / 180;
    }

    private DenseMatrix ComputeJacobian(double theta1, double theta2, double theta3, double theta4, double theta5, double theta6, double theta7)
    {   
        // Debug.Log("When you're done testing, uncomment me!!");

        // theta1 = convertRadians(theta1);
        // theta2 = convertRadians(theta2);
        // theta3 = convertRadians(theta3);
        // theta4 = convertRadians(theta4);
        // theta5 = convertRadians(theta5);
        // theta6 = convertRadians(theta6);
        // theta7 = convertRadians(theta7);

        Debug.Log("When you're done testing, uncomment me!!");

        // theta1 = convertRadians(theta1);
        // theta2 = convertRadians(theta2);
        // theta3 = convertRadians(theta3);
        // theta4 = convertRadians(theta4);
        // theta5 = convertRadians(theta5);
        // theta6 = convertRadians(theta6);
        // theta7 = convertRadians(theta7);

        var jacobian = DenseMatrix.OfArray(new double[,] {{0,0,0,0,0,0,0}, {0,0,0,0,0,0,0}, {0,0,0,0,0,0,0}, {0,0,0,0,0,0,0}, {0,0,0,0,0,0,0}, {0,0,0,0,0,0,0}});
        
        var sinTheta1 = Math.Sin(theta1);
        var sinTheta3 = Math.Sin(theta3);
        var sinTheta5 = Math.Sin(theta5);
        var sinTheta1Theta2 = Math.Sin(theta1 + theta2);
        var sinTheta3Theta4 = Math.Sin(theta3 + theta4);
        var sinTheta6Theta7 = Math.Sin(theta6 + theta7);

        var cosTheta3 = Math.Cos(theta3);
        var cosTheta5 = Math.Cos(theta5);
        var cosTheta1Theta2 = Math.Cos(theta1 + theta2);
        var cosTheta3Theta4 = Math.Cos(theta3 + theta4);
        var cosTheta6Theta7 = Math.Cos(theta6 + theta7);
    
        jacobian[0, 0] = -0.28504 * sinTheta1 + 0.28868 * sinTheta5 * cosTheta1Theta2 * cosTheta6Theta7 + 0.22499 * sinTheta5 * cosTheta1Theta2 + 0.28868 * sinTheta1Theta2 * sinTheta3Theta4 * sinTheta6Theta7 - 0.1067 * sinTheta1Theta2 * cosTheta3 - 0.28868 * sinTheta1Theta2 * cosTheta5 * cosTheta3Theta4 * cosTheta6Theta7 - 0.22499 * sinTheta1Theta2 * cosTheta5 * cosTheta3Theta4 - 0.1067 * sinTheta1Theta2;
        jacobian[1, 0] = 0.28868 * sinTheta5 * sinTheta1Theta2 * cosTheta6Theta7 + 0.22499 * sinTheta5 * sinTheta1Theta2 - 0.28868 * sinTheta3Theta4 * sinTheta6Theta7 * cosTheta1Theta2 + 0.28504 * Math.Cos(theta1) + 0.1067 * cosTheta3 * cosTheta1Theta2 + 0.28868 * cosTheta5 * cosTheta1Theta2 * cosTheta3Theta4 * cosTheta6Theta7 + 0.22499 * cosTheta5 * cosTheta1Theta2 * cosTheta3Theta4 + 0.1067 * cosTheta1Theta2;
        jacobian[2, 0] = 0;
        jacobian[3, 0] = 0;
        jacobian[4, 0] = 0;
        jacobian[5, 0] = 1;

        jacobian[0, 1] = 0.28868 * sinTheta5 * cosTheta1Theta2 * cosTheta6Theta7 + 0.22499 * sinTheta5 * sinTheta1Theta2 + 0.28868 * sinTheta1Theta2 * sinTheta3Theta4 * sinTheta6Theta7 - 0.1067 * sinTheta1Theta2 * cosTheta3 - 0.28868 * sinTheta1Theta2 * cosTheta5 * cosTheta3Theta4 * cosTheta6Theta7 - 0.22499 * sinTheta1Theta2 * cosTheta5 * cosTheta3Theta4 - 0.1067 * sinTheta1Theta2;
        jacobian[1, 1] = 0.28868 * sinTheta5 * sinTheta1Theta2 * cosTheta6Theta7 + 0.22499 * sinTheta5 * sinTheta1Theta2 - 0.28868 * sinTheta3Theta4 * sinTheta6Theta7 * cosTheta1Theta2 + 0.1067 * cosTheta1Theta2 * cosTheta3 + 0.28868 * cosTheta5 * cosTheta1Theta2  * cosTheta3Theta4 * cosTheta6Theta7 + 0.22499 * cosTheta1Theta2 * cosTheta5 * cosTheta3Theta4 + 0.1067 * cosTheta1Theta2;
        jacobian[2, 1] = 0;
        jacobian[3, 1] = 0;
        jacobian[4, 1] = 0;
        jacobian[5, 1] = 1;

        jacobian[0, 2] = -1 * (0.1067 * sinTheta3 + 0.28868 * sinTheta3Theta4 * cosTheta5 * cosTheta6Theta7 + 0.22499 * sinTheta3Theta4 * cosTheta5 + 0.28868 * sinTheta6Theta7 * cosTheta3Theta4) * cosTheta1Theta2;
        jacobian[1, 2] = -1 * (0.1067 * sinTheta3 + 0.28868 * sinTheta3Theta4 * cosTheta5 * cosTheta6Theta7 + 0.22499 * sinTheta3Theta4 * cosTheta5 + 0.28868 * sinTheta6Theta7 * cosTheta3Theta4) * sinTheta1Theta2;
        jacobian[2, 2] = -0.28868 * sinTheta3Theta4 * sinTheta6Theta7 + 0.1067 * cosTheta3 + 0.28868 * cosTheta5 * cosTheta3Theta4 * cosTheta6Theta7 + 0.22499 * cosTheta5 * cosTheta3Theta4;
        jacobian[3, 2] = sinTheta1Theta2;
        jacobian[4, 2] = -1 * cosTheta1Theta2;
        jacobian[5, 2] = 0;

        jacobian[0, 3] = -1 * (0.28868 * sinTheta3Theta4 * cosTheta5 * cosTheta6Theta7 + 0.22499 * sinTheta3Theta4 * cosTheta5 + 0.28868 * sinTheta6Theta7 * cosTheta3Theta4) * cosTheta1Theta2;
        jacobian[1, 3] = -1 * (0.28868 * sinTheta3Theta4 * cosTheta5 * cosTheta6Theta7 + 0.22499 * sinTheta3Theta4 * cosTheta5 + 0.28868 * sinTheta6Theta7 * cosTheta3Theta4) * sinTheta1Theta2;
        jacobian[2, 3] = -0.28868 * sinTheta3Theta4 * sinTheta6Theta7 + 0.28868 * cosTheta5 * cosTheta3Theta4 * cosTheta6Theta7 + 0.22499 * cosTheta5 * cosTheta3Theta4;
        jacobian[3, 3] = sinTheta1Theta2;
        jacobian[4, 3] = -1 * cosTheta1Theta2;
        jacobian[5, 3] = 0;

        jacobian[0, 4] = -0.28868 * sinTheta5 * cosTheta1Theta2 * cosTheta3Theta4 * cosTheta6Theta7 - 0.22499 * sinTheta5 * cosTheta1Theta2 * cosTheta3Theta4 + 0.28868 * sinTheta1Theta2 * cosTheta5 * cosTheta6Theta7 + 0.22499 * sinTheta1Theta2 * cosTheta5;
        jacobian[1, 4] = -0.28868 * sinTheta5 * sinTheta1Theta2 * cosTheta3Theta4 * cosTheta6Theta7 - 0.22499 * sinTheta5 * sinTheta1Theta2 * cosTheta3Theta4 - 0.28868 * cosTheta1Theta2 * cosTheta5 * cosTheta6Theta7 - 0.22499 * cosTheta1Theta2 * cosTheta5;
        jacobian[2, 4] = -1 * (0.28868 * cosTheta6Theta7 + 0.22499) * sinTheta5 * sinTheta3Theta4;
        jacobian[3, 4] = sinTheta3Theta4 * cosTheta1Theta2;
        jacobian[4, 4] = sinTheta1Theta2 * sinTheta3Theta4;
        jacobian[5, 4] = -1 * cosTheta3Theta4;

        jacobian[0, 5] = -0.28868 * sinTheta5 * sinTheta1Theta2 * sinTheta6Theta7 - 0.28868 * sinTheta3Theta4 * cosTheta1Theta2 * cosTheta6Theta7 - 0.28868 * sinTheta6Theta7 * cosTheta5 * cosTheta1Theta2 * cosTheta3Theta4;
        jacobian[1, 5] = 0.28868 * sinTheta5 * sinTheta6Theta7 * cosTheta1Theta2 - 0.28868 * sinTheta1Theta2 * sinTheta3Theta4 * cosTheta6Theta7 - 0.28868 * sinTheta1Theta2 * sinTheta6Theta7 * cosTheta5 * cosTheta3Theta4;
        jacobian[2, 5] = -0.28868 * sinTheta3Theta4 * sinTheta6Theta7 * cosTheta5 + 0.28868 * cosTheta3Theta4 * cosTheta6Theta7;
        jacobian[3, 5] = -1 * sinTheta5 * cosTheta1Theta2 * cosTheta3Theta4 + sinTheta1Theta2 * cosTheta5;
        jacobian[4, 5] = -1 * sinTheta5 * sinTheta1Theta2 * cosTheta3Theta4 - cosTheta5 * cosTheta1Theta2;
        jacobian[5, 5] = -1 * sinTheta5 * sinTheta3Theta4;

        jacobian[0, 6] = -0.28868 * sinTheta5 * sinTheta1Theta2 * sinTheta6Theta7 - 0.28868 * sinTheta3Theta4 * cosTheta1Theta2 * cosTheta6Theta7 - 0.28868 * sinTheta6Theta7 * cosTheta5 * cosTheta1Theta2 * cosTheta3Theta4;
        jacobian[1, 6] = 0.28868 * sinTheta5 * sinTheta6Theta7 * cosTheta1Theta2 - 0.28868 * sinTheta1Theta2 * sinTheta3Theta4 * cosTheta6Theta7 - 0.28868 * sinTheta1Theta2 * sinTheta6Theta7 * cosTheta5  * cosTheta3Theta4;
        jacobian[2, 6] = -0.28868 * sinTheta3Theta4 * sinTheta6Theta7 * cosTheta5 + 0.28868 * cosTheta3Theta4 * cosTheta6Theta7;
        jacobian[3, 6] = -1 * sinTheta5 * cosTheta1Theta2 * cosTheta3Theta4 + sinTheta1Theta2 * cosTheta5;
        jacobian[4, 6] = -1 * sinTheta5 * sinTheta1Theta2 * cosTheta3Theta4 - cosTheta5 * cosTheta1Theta2 ;
        jacobian[5, 6] = -1 * sinTheta5 * sinTheta3Theta4;

        // Debug.Log(jacobian);

        // var inverse = jacobian.PseudoInverse();

        // Debug.Log(inverse);

        // Debug.Log(jacobian.Multiply(inverse));
        return jacobian;
    }

    private Matrix<double> ComputeInverse(DenseMatrix j) {
        return j.PseudoInverse();
    }
}

# CS 8395 Final Project

_Isaiah Osborne_

## But first... I have to apologize for some things

I messed up my previous repository -- what's the word? -- royally. (Some very weird issues with Git LFS and authentication?) It's still available here: <https://github.com/VU-RASL/InverseKinematics>. Check it out if you want to see some older history...

## Project Description

_Improving Augmented Reality Pose Redirection Using Potential Functions and Gradient Descent_

## Research Question

_Can we improve the pose mimicry of our inverse kinematics setup by using nullspace optimization?_

## Project Goals

For my project, I want to explore other ways to optimize the pose redirection. For example, we can use other ideas from inverse kinematics to optimize both of our variables simulataneously. We can define two different objective functions: one function for the location for the hand, and one function for the difference in joint angles between the two poses, as used in [^4]. From [^1] and [^2], we can write the derivative of the two functions together like this (rewritten for clarity):

$$
d\theta = J_1^* \dot q_1 + (I_n - J_1^*J_1)(-\gamma \frac{dp}{d\theta})^T
$$

- Where:
    - $J_1^*$ is the Jacobian psuedo-inverse
    - $\dot q_1$ is a particular solution

In an engineering setting, this is used to calculate the velocity of the end of the link (usually a manipulator, but in this case a hand). However, this could also be used as part of our gradient descrnt, allowing the algorithm to explore on the gradient for both the main objective ($J_1^* \dot q_1$) and the secondary objective ($(I_n - J_1^*J_1)(-\gamma \frac{dp}{d\theta})^T$). The two objectives will be the ones in [^5]. As far as I can tell, this approach has not been used in avatar inverse kinematics.

## Technical Details

I used Unity and the Microsoft Mixed Reality Toolkit to create my project, with a modified version of the BioIK package used for the optimization process. 

- <https://unity.com/>
- <https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-overview/>
- <https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-input/packages/input/input-simulation>
- <https://github.com/sebastianstarke/BioIK>

## Pictures

![image](https://github.com/VU-RASL/InverseKinematicsOptimization/assets/107141169/c99946bb-824e-4f59-9b51-f19d768c8f49)

_Project Setup_

![image](https://github.com/VU-RASL/InverseKinematicsOptimization/assets/107141169/aa7d2952-006d-4825-a0e8-79e4203bb3dd)

_Project Running in the simulator_

![image](https://github.com/VU-RASL/InverseKinematicsOptimization/assets/107141169/8d6dbbfb-16fd-42a0-852b-8399dcac2839)

_My project running on a Hololens_

## Deploying

You should be able to deploy it directly using Holographic Remoting with the Hololens. See <https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-overview/test-and-deploy/streaming> (It works but requires a hefty internet connection). If you want to actually install it on the Hololens, you'll need to install Visual Studio and build the project... (see these for steps: <https://learn.microsoft.com/en-us/windows/mixed-reality/develop/unity/build-and-deploy-to-hololens> and <https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/using-visual-studio>). All of the build settings _should_ be ok, but I've only tested it on Windows, so good luck on other OSes!

If you clone the project and open up the project, you might get an empty scene at the beginning. Open up the `Demo` scene and you should be good to go!

## Analysis

My nullspace exploration does actually work - it does not destroy the overall orientation of the pose, which I was worried about. However, it does not make much of a visual impact on the poses - for most of my example poses, you cannot tell a noticeable difference between the nullspace and traditional optimized poses. 

Besides the problems with visual differences, it dramatically decreases performance on the Hololens, with noticeable lag in the UI. Of course, there's plenty of potential room for nullspace optimization of my code, but as of right now, it is barely usable.

## Limitations

1. Currently, my Jacobian calculations are hardcoded for the specific `Robot Kyle` avatar; I would have to add another function to calculate the analytic Jacobian for any arbitrary avatar.
2. There's fairly substantial performance issues when deployed to the Hololens.

## Thank you!

Thank you to Alexandra Watkins in the RASL lab for all of her help with making this project a reality!

Also thank you to <https://akintokinematics.com/from-dh-parameters-to-inverse-kinematics/> for help with the Jacobian matrix calculations.

## Citations

[^1]: "Automatic Supervisory Control of the Configuration and Behavior of Multibody Mechanisms," in _IEEE Transactions on Systems, Man, and Cybernetics_, vol. 7, no. 12, pp. 868-871, Dec. 1977, doi: 10.1109/TSMC.1977.4309644.

[^2]: Yoshihiko Nakamura. _Advanced Robotics Redundancy and Optimization_, Addison-Wesley, 1991.

[^3]: S. Starke, N. Hendrich and J. Zhang, "Memetic Evolution for Generic Full-Body Inverse Kinematics in Robotics and Animation," in _IEEE Transactions on Evolutionary Computation_, vol. 23, no. 3, pp. 406-420, June 2019, doi: 10.1109/TEVC.2018.2867601.

[^4]: Ullal A, Watkins C, Sarkar N. "A Dynamically Weighted Multi-Objective Optimization Approach to Positional Interactions in Remote-Local Augmented/Mixed Reality," in _The Institute of Electrical and Electronics Engineers, Inc. (IEEE) Conference Proceedings._ The Institute of Electrical and Electronics Engineers, Inc. (IEEE); 2021. doi:10.1109/AIVR52153.2021.00014

[^5]: Akshith Ullal, Alexandra Watkins, and Nilanjan Sarkar. 2022. A Multi-Objective Optimization Framework for Redirecting Pointing Gestures in Remote-Local Mixed/Augmented Reality. In Proceedings of the 2022 ACM Symposium on Spatial User Interaction (SUI '22). Association for Computing Machinery, New York, NY, USA, Article 9, 1–11. https://doi-org.proxy.library.vanderbilt.edu/10.1145/3565970.3567681

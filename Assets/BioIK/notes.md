# BioIK Project

## So... how do I set this up?

- Add BioIk to the project under the `Assets` tab
  - Now it's time to add a mannequin
- If we have Robot Kyle set in the scene, add the main BioIK script component to `Robot Kyle > Geometry > KyleRobot > ROOT`
  - You'll get the pretty BioIK layout, then you can add joints
  - You **need** to give them a wider range of joint motion
    - Enable whichever motion you'll need X, Y, or Z
  - If you want to add an objective, then drag in whatever object you want it to point to...
- This shouldn't be too bad?

## But what all does it do?

### `Helpers/Enums.cs`

- So, this is a very long and expansive file...

```cs

namespace BioIK {
	public enum ObjectiveType {Position, Orientation, LookAt, Distance, Displacement, JointValue, Projection, Pose, PerpRotation, PosePositionOnly};
	public enum JointType {Rotational, Translational};
	public enum MotionType {Instantaneous, Realistic};
}

```

- Ok, maybe not 🙄

### `Helpers/Evolution.cs`

- `Line 51`: we've got the evolution function!
- There's a bunch of code used to initilize everything...
- Then there's the `Optimise` function, which runs the main loop of the problem
  - That runs the `Evolve` function several times...
  - It hits all of the main functions - `Reproduce`, `Offspring`, etc.

```cs
public double WPX, WPY, WPZ;				//World position
public double WRX, WRY, WRZ, WRW;			//World rotation
public double WSX, WSY, WSZ;				//World scale
public double LPX, LPY, LPZ;				//Local position
public double LRX, LRY, LRZ, LRW;			//Local rotation
//public double RootX, RootY, RootZ;		//World position of root joint
```

- So, what will I need for my inverse kinematics work from these coordinates?

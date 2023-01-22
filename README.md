# Unity3D_patterned_walls

This project is a box environment with 4 walls patterned as: 
- Checkerboard script for checkered pattern
- Checkerboard H for horizontal stripes
- Checkerboard V for vertical stripes
- Checkertilted Stripes for angled stripes

The environment entails an object currently of uniform colour.
The code saves POV of the agent when moving around a stipulated trajectory as png images. These images can further be used to train Deep Learning models.

The trajectory files are named as:
- traj_obj(sh1)_20k.csv : This means there is object in the first quadrant of the environment. Similarly for sh2, sh3, sh4 and wo (without object) can be used to create datasets.
- To design a novel trajectory with a custom object position, use the Trajectory.py code available in Object_representation_model repository.


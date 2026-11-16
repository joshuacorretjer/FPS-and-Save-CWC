# FPS and Save System

## Overview

A Unity 3D first-person shooter (FPS) prototype developed during a **Create with Code Live – Spring 2020** community-requested live session. The project explores fundamental FPS mechanics, including first-person movement, mouse-controlled camera rotation, jumping, and shooting physics-based objects using raycasting.

In addition to the FPS mechanics, the project introduces game persistence through a save and load system, allowing game progress and object information to be stored and restored.

## Features

- **First-Person Movement:** Implemented physics-based player movement relative to the direction the player is facing.
- **Mouse Look:** Created first-person camera controls with vertical rotation limits to prevent excessive camera movement.
- **Jump Mechanic:** Added a player jumping mechanic to expand the original FPS implementation.
- **Shooting System:** Implemented raycasting to detect and interact with objects, applying forces to objects with Rigidbody components.
- **Cursor Management:** Locked and hid the cursor to provide a standard FPS experience.
- **Save System:** Created a system to save and load game progress using dedicated save file and save manager scripts.
- **Physics-Based Interactions:** Used Rigidbody components and physics methods to handle player movement and object interactions.

## What I Learned & Implemented

### First-Person Controls and Camera
- Used `Transform.eulerAngles` to work with object rotation through Euler angles measured in degrees.
- Implemented `Mathf.Clamp()` to restrict vertical camera rotation and prevent the player from looking beyond specified angles.
- Used `Quaternion.Euler()` to convert Euler angles into a Quaternion for camera rotation through `localRotation`.
- Configured `Cursor.lockState` to lock the mouse cursor to the center of the screen and hide it during gameplay.
- Used `[RequireComponent]` to ensure that GameObjects containing the player controller script also have the required Rigidbody component.

### Player Movement and Physics
- Used `Rigidbody.MovePosition()` for physics-aware player movement.
- Applied `TransformDirection()` to translate player input into movement relative to the direction the player is facing.
- Implemented an additional jumping mechanic using Rigidbody physics.

### Shooting and Raycasting
- Learned to use Rays and `Physics.Raycast()` to detect objects in the direction the player is aiming.
- Implemented a basic FPS shooting mechanic that interacts with objects containing Rigidbody components.
- Used raycast detection to identify target objects and apply physics-based interactions.

### Save and Load System
- Created a dedicated save file class to define and organize the information stored during gameplay.
- Implemented a Save Manager responsible for managing the saving and loading processes.
- Learned how to separate saved game data from the logic responsible for handling persistence.
- Explored serialization concepts for storing and restoring game information, including object positions and player state.

## Technologies & Tools

- **Game Engine:** Unity
- **Programming Language:** C#
- **IDE:** Visual Studio
- **Concepts:** First-Person Controls, Mouse Look, Euler Angles, Quaternions, Mathf.Clamp, Rigidbody Physics, MovePosition, TransformDirection, Raycasting, Physics.Raycast, Save/Load Systems, Serialization, Game Persistence

## Course

**Create with Code Live – Spring 2020**

A remote Unity course taught by professionals working at Unity. This project was developed during a community-requested live session based on one of the most upvoted topics in the Create with Code Live Connect group.

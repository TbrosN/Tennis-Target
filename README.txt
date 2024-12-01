Trey Brosnan, Intro To Unity F24 A1

Tennis Target

In this game, you hit a tennis ball against a wall and try to hit the target.

Controls

- Move your mouse to make the racket move
- Click the mouse to swing the racket
- Press R to reset the game
- The aiming is based on timing: late swings go right, early swings go left

Acknowledgements

- In case it's not obvious, I made the racket myself.

One surprising success was getting the swing animation to work properly. I struggled a lot with it, so when it finally worked, I was pretty shocked. What I ended up doing was making an empty game object that the racket rotates around, and making that a child of the empty game object that allows the racket to follow the mouse. At first, I made the rotation game object a child of the mouse-following one, and that didn’t work.

One unexpected frustration was getting the target to respawn in the right general area. I had a lot of problems with the target respawning out of the camera’s view. What I ended up doing was finding the (world) intersection point between the camera’s perspective and the wall, and then used that to calculate the extreme left and right points of the wall.

The main purpose of this game was obviously to learn Unity, but I also had another motive. I want to build an AR game that involves swinging a racket, and so I figured this project would help prep me for that. Also, this game is loosely based on the Wii Sports tennis training game, if you know what that is.

Knock-knock.
Who’s there?
Boo.
Boo who?
Don’t cry, it’s only a joke!

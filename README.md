# 2048 Extended

![--](https://1drv.ms/u/s!AiEmVlB_LsNXgdgcZLpADn_Nl-EWCQ?e=H6MlE8)

## Summary

The 2048 is a game consisting of a 4x4-box board on which pieces with numbers are located. The
numbers are always a power of two greater than or equal to two. In each turn the user must decide a
move all the pieces on the board (up, down, right, or left). If in the direction in which
moving the pieces there are two pieces of equal value in a row, these combine to form a single piece
with value equal to the sum of the two blends.
At first the game starts with only two pieces in random positions and they can be worth 2 or 4. After
each valid move appears in a random box a 2 or a 4. A movement is valid if you can
move (or mix) some piece. If there are no possible moves on a board the game ends. On every move
accumulates in a player's score the value of the pieces that were mixed (for example, if mixed
two 4s would accumulate by 8). If a box with a 2048 value is reached it is said that the player won (although he can
continue to accumulate points).
The player has a set of possibilities to undo the last play (both the movement and the appearance of
the new piece). In the original game you can only perform this operation twice during the game.

## Extensions

1. The size of the board can be specified before starting the game and can be from 4x4 to 16x16 (always square). The number of initial values ​​can also be variable from 1 to 3.
2. The number of times the move can be undone has no limits (note that each time
a move is undone, in addition to restoring the board, the points won in the undone move are removed).
3. The player can save a game to continue it later.

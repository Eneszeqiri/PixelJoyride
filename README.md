# PixelJoyride

The Game is a 2d arcade game in which we have a player, that tries to get a highscore, and get coins to buy new backgrounds for the game.
The Coins, the Rockets, and the Map itself is generated automatically and as for the coins and rockets they are generated randomly.
Me Enes Zeqiri(191518) and my Collegue Altin Axhami (191501) used Unity because we wanted to try and test ourselves with sprites and used sprites which we made ourselves,
And all the art and sprites and everything in it is original ours besides the idea that we took from jetpack joyride.

At first we start the game in main menu with 3 buttons: "Play", which leads us directly to the game, "Store" which leads us to the store, and the "Quit" which will close the game in a click.
![MainMenu](https://user-images.githubusercontent.com/29408754/121800905-b27f8780-cc34-11eb-82f8-ecbb6105d7b6.png)

The game is played that the ingame player has got gravity, and rockets coming at him and some coins that he can take to buy Backgrounds for the game.
The ingame player has got a jetpack that the one playing the game can control with the "Space" button which the ingame player can ONLY fly up and the gravity will bring him down, and has to calculate the gravity if the ingame player will be fast enough to avoid the rockets coming. Also the player has can use "A" and "D" to move left and right.
![GamePlay](https://user-images.githubusercontent.com/29408754/121800800-266d6000-cc34-11eb-9d05-ede27180b65c.jpg)
After We can get 20 Coins, we can access the Store in the main menu, and choose the background that we want, and after the background is bought we lose 20coins;
![StoreImage](https://user-images.githubusercontent.com/29408754/121800873-86fc9d00-cc34-11eb-9572-8da0488bd3ee.png)
Then when we Play the game again we see the background change. 
In-game if we want to pause the game we can press "Esc", and then we can choose if we want to resume or go back to main menu.
![PauseMenu](https://user-images.githubusercontent.com/29408754/121800841-62a0c080-cc34-11eb-8195-ac0aeda08540.png)

Under this is the code for generating the map and instructions of how the code works.

if (Player.transform.position.x > Floor.transform.position.x)         //if the position of the player passes the middle of the "floor"
        {
            var tempCeiling = PrevCeiling;                            // we put the previous ceiling in a temporary variable
            var tempFloor = PrevFloor;                                // same as the temporary floor,
            PrevCeiling = Ceiling;                                    // because we will put the "Ceiling" in the previous ceiling,
            PrevFloor = Floor;                                        // And the floor in the previous floor
            PrevCeiling.transform.position += new Vector3(40, 0, 0);  //and we will move the ceiling and
            PrevFloor.transform.position += new Vector3(40, 0, 0);    // the floor +40 in the x-axis to generate the new field for walking;
            Ceiling = tempCeiling;                                    //then we put the original previous-ceiling in the first-ceiling
            Floor = tempFloor;                                        // and the same with the floors
        }




# capstone-2022

My senior project at YSU for fall 2022, I recieved an A and graduated with my BS in computer science and minor in math.
I designed a small game demo with combat mechanics derived from a mix of Final Fantasy VII Remake and Pokemon.

Some things of note about this project:
 - This was my first time using Unity in 3D!
 - The focus was on the design and structure of the game, rather than graphics (which is why the models are all blocks)
 - Specifically, I wanted to highlight my finite state machine designs for the AI
 - There are missing features which didn't make it into the final product mostly due to time, maybe I'll revisit this someday and add them!
 
Download instructions:
Windows
 - Navigate to Builds -> Windows -> Installer -> Boxeymon Setup.exe and click download
 - If Windows prevents the application from running, select more info and run anyway (I swear its not a virus)
 - Follow the steps in the installer and run the Boxeymon.exe file
Mac
 - Navigate to Builds -> Mac -> x86 -> Boxeymon.zip and click download
 - Inside the zipped folder should be a .app that can be run on your system
 - Open the zipped folder
 - Open the app that appears after opening the zipped folder
 
 *If you cannot open the app on your Mac system:*
  Open up Terminal and navigate to your app folder:
  
  ```cd <PATH_TO_YOUR_APP>/Boxeymon.app/Contents/MacOS/```

  This folder contains the actual executable file which Windows apparently didn’t make executable. Once inside the MacOS folder, add the next line:

  ```chmod +x <APP_NAME>```
  
 The app should now be able to open. 


Controls:
 - WASD moves the player
 - Look around with the mouse
 - Press F to open the on-screen menu and use the listed keys to navigate (Q, E, C)

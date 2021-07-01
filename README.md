# Entity March Dream Remastered
Backup repo for EMDR

# What is it?
Entity March Dream Remastered was a game I made to, you know, remaster the original Entity March Dream.
You can find the link to both the original and the remaster <a href = "https://that-one-nerd.itch.io/entitymarchdream">here</a>

# How do I open this?
You can fork the project and open this folder in Unity. I used version 2021.1.9f1 for this game, but you can do what you want.

# What can I change?
Whatever you want! All you can't do is sell this or claim you made the original. Feel free to do what you like!

# Some other notes:
- Some code and techniques in here are highly unoptimized. I promise I don't usually code like this, but since it was such a small and fairly unimportant game, I decided to not put too much effort into making the code look and run good.
- I didn't comment any code, because I didn't plan on releasing this to the public when making version 1.0. However, the code for this game is substantially less complex and there is less of it, again, because this game is small.
- In this Unity version used to make the game (Unity 2021.1.9f1), there is a weird glitch where it will give you a cloud error every time you start the editor, enter playmode, or make a change to the code. I have no idea why, but it doesn't affect the game at all, so you can just ignore it. The exact details of the error are below:

```
NullReferenceException: Object reference not set to an instance of an object
Unity.Cloud.Collaborate.UserInterface.CollaborateWindow.OnDisable () (at Library/PackageCache/com.unity.collab-proxy@1.5.7/Editor/Collaborate/UserInterface/CollaborateWindow.cs:86)
```

`OnDisable ()` may be replaced with another method, such as `OnEnable ()`.
Basically, any error from `Unity.Cloud.Collaborate` can be ignored

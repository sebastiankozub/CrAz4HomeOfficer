# CrAz4 HOME Officer

Hobbist or POC project. Magic `windows service` to play with some restricted OS functionalities and have a lot of fun. Read warning :)

### !!! WARNING !!! Running the code on your own developer's responsibility only!!! Setting shortcut binding to system or security win32 or similar methods what can bo done easily with the code can lead to secure information leakage. As CrAz4 POC is trying to prove it is not so hard to work on someone's desktop w/o user and password. Quickest explanation is service leveraged to LocalSystem priviliges and possibility to start invisible WinForms app on system start. 

Magic CrAz4 `windows service` project to play with some restricted functionalities and have a lot of fun. Some kind of wrapper for small useful services running as invisible and with special rights on all desktop/rdp accounts. Generally, using power of `LocalSystem` and service `Automatic start` when you are your PC owner.

Technologies: pure C#, Console/Windows application, Windows Service, Win32 API - old style system events to get some system methods

## Core functionalities

1. `Windows Service` interacting with logged-in user & user's desktop
2. Communication with No-GUI application:
    - keyboard-driven menu and actions
    - directory observer, textfile message communication
    - IPC: pipeline, MessageQueue
    - actions finished with some results in log
    - optionally some pop-up window and/or terminal as extension/tool
3. Framework/Pattern for bigger (Interactive) Windows Service solutions
4. Easy-to-extend functionality/tools system
5. Detecing active application in system
6. Keyboard shortcuts mapping (for example Ctrl+G+H means 'higher' in few audio applications, changing active window dynamically switching shortcut-to-action binding if same)
7. Keyboard shortcuts routing to services, to commands, to run application, to running EXEs, virtual 
8. Inter-desktops' communication
9. Quick Keyboard/Char-To-Voice for disabled
13. Check your postman when you're outside your house ;)
16. 
### !!! WARNING !!!
17. How to avoid other shit-service like the one sending communicates to the CrAz4? 
	- hide/keep menu securely but every shortcut to 3-stroke can be looped quickly
	- 123
	- abc
	

## What Is Done

1. Keyboard/Shortcut-Driven abstract-menu/UI, simple but clean and there are bigger problems ;)
2. Easy to extend with new tools/extensions/functionalities/whatever during development. (Dynamic TODO)
3. key hooker, mouse hooker: Switchable, independent of UI one -> we cannot out of the only communication channel, to independent file only (capture and screen, better mouse hooking: window, pos(x,y) ToDO)
4. POC screen recorder - Screen > PNG files > GIF file ;-) but it works, let's say... tested with on/off-ing of key and mouse hookers (y) bigger amounts of PNGs causing OutOfMemeory exception, so if happy with format needs to implement threading and GIF's chunking.

## Easy-to-extend functionality system

Service as a base for growing list of small helpers - easy to install and extend. 
For example screen recording with some fixed codec to specific dir is one functionality
that can work without others or codec choosing by shortcut branching: Ctrl+G+1/Ctrl+G+2/Ctrl+G+3

### Funny functionalities, adding to service "quite" dynamically 

1. Accesing user's desktop -> ScreenRecorder: ToFile, ToEndpoint, etc. 
2. Accesing user's keyboard -> KeyHooker: ToFile, ToScreen, etc. 
3. Mixing functionalities:
	KeyHooker(ToScreen) + ScreenRecorder + SkypeAudio + MicIn -> Record Skype meeting without informing Skype ;)
4. Running quickly with keyboard shortcut

### Installing new functionality 

During task resolving and implementing new functionalities all the time focusing on some reusable pattern or framework for Windows Service applications brought me here: New extensions to functionalitites list implementing `IProcessTool` can be added with 3 lines of code still keeping View/User Interface layer separate from application and business logic. 

```C#
var toolsManager = new ProcessToolManager<IProcessTool>();
toolsManager.Install("desktopKeyHook", new KeyboardHooker());
```
```C#
var keyCombinationToActionMap = new Dictionary<Combination, Action>
{
	{ Combination.FromString("Control+K+L"), () => { tools.GetByName("desktopKeyHook").Start(); } },
	{ Combination.FromString("Control+K+J"), () => { tools.GetByName("desktopKeyHook").Stop(); } }
};
```

## Framework/Pattern for Interactive Windows Service

Simply creating and shaping some universal frame and shared functions and modules for similar solutions that with time could become standalone project. Shortcuts-Driven-UI, Keyboard-To-Action binding, etc... 

## Invitation to Contribution 

Feel free to propose ideas or fork/clone. After forking this repository, you can make some changes to the project, and submit a Pull Request as practice. Starting with clone also does not take you the possibility.  

# TODO - List of tasks & ideas 

Excuse me, for mess below, it is kind of: backlog, sticky notes, idea's log and everything else in one file ;) 

## General improvments 

1. NoVMC - NoView-Model-Controller, SNoVC: service - no-view - contoller - create kind of windows service framework or pattern
2. Something like 1. also could be used in vioce-driven application
3. Additionally there is some idea to have view/terminal but basic plan is interactive process not visible 
4. Leading to have Interactive Windows Service Pattern/Framework

## Service Tools/functionalities/ TODO

10. Installing new Tools on-The-Fly with bindings to menu: command-line-like command + new DLL with some interfaces implemented
11. 
12. 
Capture:
13. Camera 
14. Sound from microphone
15. Sound from system
16. Sound from Stereo Mix IN
17. Sound from Stereo Mix OUT (same as 15.?)
18. Sound from fixed application (Skype, YT, etc)

11. Better screen recording:
   - compression
   - efficiency
   - memory consumption
   - partial saving
   - multithreading
   - parallel processing
   - it is POC and generally PrintScreen > PNG FileStream > GIF FileStream is not the best idea
19. KeyHooker, MouseHooker: Switchable, independent of UI one -> we cannot out possibility to loose only communication channel, to independent file only (to capture and screen TODO)

## Interactive Windows Service Pattern/Framework

50. PopUp-Interface - not so hidden windows service
51. Notification ^
    - Internal Notification System
    - PopUp-Interface Integrated Notification System
52. Terminal
53. CLI
54. Terminal PopUp-Interface
55. Easy-to-extend functionalities - configureastion options, terminal options... 
56. Asynchronous user interface - if we can call the interface like this ;) 
57. IProcessTool to implement Subscriber-Observer or INotifyProperty to integrate and use Notification System

## Issues - To resolve on Win32 layer

101. Achieving token when running in Interactive Enviroemnet
102. Enumarating logged-in users - Also RDP connected users
103. Choosing one or few of the active desktops to interact
104. Sending info to logged-in users
105. Sending questions to logged-in users
106. WinAPI Message Loop approaches to check:
    - WinForms,
    - WPF,
    - custom WinAPI loop
107. Garbage Collecting - GIF from FileStream crashes when capture 60 seconds and more
108. More MultiThreading everywhere, MT screen saving and movie encoders. 
109. Async menu, Async WinApi Message Loop message dispaching.

## Getting Things Done

201. Proper application log pattern & implementation on whole codebase
202. Clean Code. General cleaning
203. Find nice Unit Testing pattern to the solution - specific and breaking Windows security rules application functionalities

## Quick refactorings

211. TXT and MD files - make order with information inside and with the files generally
212. 

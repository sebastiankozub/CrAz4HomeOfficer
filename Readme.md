# CrAz4 HOME Officer

Hobbist-POC magic windows service project to play with some restricted functionalities and have lot of fun.

## Core functionalities

1. Windows Service interacting with logged-in user & user's desktop 
2. Communication with No-GUI application: 
   - keyboard-driven communication 
   - directory observer 
   - pipeline 
   - IPC 
   - Message Queue 
3. Interactive Windows Service Framework 
4. Easy-to-extend functionalities system 

## Easy-to-extend functionalities system 

### Funny functionalities, adding to service "quite" dynamically 

1. Accesing user's desktop -> ScreenRecorder 
2. Accesing user's keyboard -> KeyHooker 
3. Mixing functionalities -> KeyHooker + ScreenRecorder 

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

## Invitation to Contribution 

Feel free to propose ideas, fork or clone. After forking this repository, you can make some changes to the project, and submit a Pull Request as practice. 

# TODO - List of tasks & ideas 

Excusme me for the mess below - kind of backlog, sticky notes and idea's log in one file ;) 

## General improvments 

1. NoV-MVC: NoView MVC, SNoVC: service - no-view - contoller - create kind of windows service framework or pattern 

## Service tools/functionalities

11. Better recording:
   - compression 
   - efficiency
   - memory consumption 
   - partial saving 
   - multithreading
   - parallel processing
   - it is POC and generally PrintScreen > PNG FileStream > GIF FileStream is not the best idea
13. Camera capture
14. Sound from microphone
15. Sound from system
16. Sound from Stereo Mix IN
17. Sound from Stereo Mix OUT = 15?
18. Sound from fixed application

## Interactive Windows Service Framework

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




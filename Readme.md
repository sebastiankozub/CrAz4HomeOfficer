# CrAz4 HOME Officer

POC/Hobbist project. CrAz4 is `windows service` project started to have some games with restriction of security in Windows above Vista OS and have some fun beating them and get some knowledge and expierience. Wrapper for small functionality packs (like simple ScreenRecorder) started and used without former desktop GUI but with pssibilities of interactive Windows logged user/desktop. Running as invisible app/service with special rights on all desktop/rdp accounts logged-in interactively to make your own machine safer but **WARNING!!! Read carefully every WARNING Below!!!**

### !!! WARNING !!! Running the code on your own developer's responsibility only! Only on your test machine/PC/server! Setting shortcut binding to system or security from win32 or similar methods what can bo done easily with the code given can lead to system security breaks or lead to information leakage. As CrAz4 POC is trying to prove it is not so hard to work on someone's desktop w/o user and password data. Quickest explanation is service leveraged to LocalSystem priviliges and possibility to start invisible WinForms app on system start using the service. 

Magic CrAz4 `windows service` project created to play with restrictions, functionalities of lower level Win32 API and have some good timee spent. Wrapper for small useful services (here called Tolols) running as invisible process and with special rights leveraged to LocalSystem on all desktop/rdp accounts. Generally, using power of service `Automatic start` and leveraged priviliages when you are owner/Administrator of your PC.

Technologies: C#, Console/Desktop app, Windows Service, custom message pump - Win32 API to get to lower level system methods

## Core functionalities

1. `Windows Service` interacting with logged-in user & user's desktop
2. Communication with No-GUI application:
    - keyboard-driven menu and actions
    - directory observer, textfile message communication
    - IPC: pipeline, MessageQueue
    - actions finished with action's success and results in log files, log target
    - optionally some pop-up window and/or terminal as extension/tool
3. Framework/Pattern for bigger (Interactive) Windows Service projects
4. Easy-to-extend functionality/tools system
5. Detecing active application in user/desktop
6. Keyboard shortcuts mapping (for example Ctrl+G+H means 'higher' in few audio applications, changing active window dynamically switching shortcut-to-action binding if same)
7. Keyboard shortcuts routing to services, to commands, to run application, to running EXEs, virtual 
8. Inter-Desktop communication with service as broker
9. Quick Keyboard/Shrtcut/Char-To-Voice for disabled and other with the need people
11. Speech Recognition to call action... 
13. Check your PostMan's play when you're outside your house ;-)
16. ...

`Service` is a casual Windows service application giving possibility to start casual Windows EXE Console/Window application executable as user process in given desktop environment. 
`Process` is the process run by `Service`. Is uses WinForms's Application.Run() message pump to get events from operating system and no-window ApplicationContexct to get desired [no window but interactive] functionality. 

## Easy-to-extend functionalities system 
17. **WARNING!** How to avoid and/or defend from other shitty service like the CrAz4 ;-) and sending communicates to the CrAz4 and then call some dangerous Win32 proc or CrAz4 Tools? (ideas brainstorm)
	- hide/keep menu bindings securely (but every key combinatione can be looped quickly like CrAz4 can)
	- additional password/only Adminstrator user can access some tools/terminal commands, only from local
	- touchpad symbolic password, easy to keep - still can be stolen - laptop to RDP still can read and just put similar symbols
  Above only some advices or obstacles quite easy to beat
	- special protection to un-/re-/installing services - only one admin, only local changed in Windows?
	- deeper analysis of keystroke sources - only local devices?
	- additional protection gates in CrAz4 actions/tools called out of localOS' station's device: RDP keybards, etc.
	- domain systems... ?

## What Has Been Done?

1. Keyboard/Shortcut-Driven abstract/NoG-UI, simple wo many possible fuctionalities but clean and there are bigger problems to resolve ;)
2. Easy to extend with new tools/extensions/functionalities/whatever during development - tool's installer, tools manager (Dynamic TODO)
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
	- KeyHooker(ToScreenRecorder) + ScreenRecorder + SkypeAudio(ToScreenRecorder) + MicIn(ToScreenRecorder) -> Recording Skype meeting without informing Skype app with one key combination or sequence
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
55. Easy-to-extend functionalities - configureastion options, terminal options 
56. Asynchronous user interface - if we can call the interface like this ;) 
57. IProcessTool to implement Subscriber-Observer or INotifyProperty to integrate and use Notification System

## Issues - To resolve on Win32 layer

101. Achieving token when running in Interactive Enviroemnet - no LocalSsytem account / simply run Main()  ;)  but still there are problem with enumarating and getting session's tokens
102. Enumarating logged-in users - Also RDP connected users
103. Choosing one or few of the active desktops to interact
104. Sending info to logged-in users
105. Sending questions to logged-in users
106. Forcing user's to agree on some new internal rules 
106. Few Message Pump approaches to check possibilities to run application without window form:
    - WinForms
    - WPF
    - custom WinAPI loop

	Example custom WinAPI loop here specific to start a thread that only liten to the mouse events:

```C#
DWORD WINAPI mouseLLHookThreadProc(LPVOID lParam)
{
    MSG msg;

    _hMouseLLHook = SetWindowsHookEx( WH_MOUSE_LL, .....);

    while(GetMessage(&msg, NULL, 0, 0) != FALSE)
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return 0;
}
```

107. Garbage Collecting - GIF from FileStream crashes when capture 60 seconds and more
108. More MultiThreading everywhere, MT screen saving and movie encoders
109. Async menu, Async WinApi Message Loop message dispaching

## Getting Things Done

201. Proper application log pattern & implementation on whole codebase
202. Clean Code. General cleaning
203. Find nice Unit Testing pattern to the solution - specific and breaking Windows security rules application functionalities

#TODO (quick memory save)
async menu, 
multithreading in capturing process, 
temporary partial save of output, 
efficieny, 
keylogger outputs conf, 



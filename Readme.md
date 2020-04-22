# CrAz4 HOME Officer

Hobbist POC project  to check some functionalities and have some fun

## Core functionalities

1. Windows Service interacting with logged-in user & user's desktop 
2. Communication with a No-GUI application - keyboard-driven communication, directory observer
3. Interactive Windows Service Framework 
4. Easy-to-extend functionalities system

## Easy-to-extend functionalities system

### Funny functionalities, adding to service "quite" dynamically

1. Accesing user's desktop -> ScreenRecorder
2. Accesing user's keyboard -> KeyHooker
3. Mixing functionalities -> KeyHooker + ScreenRecorder

### Installing new functionality

Extension implementing `IProcessTool` can be added by adding 3 lines of code: 

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

# TODO:

## General

1. NoV-MVC: NoView MVC, SNoVC: service - no-view - contoller - kind of windows service framework

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

101. Achieving token when running in Enviroemnet.Interactive.
102. Enumarating logged-in users - Also RDP connected users.
103. Choosing one or few of the active desktops to interact.
104. Sending info to logged-in users.
105. Sending questions to logged-in users.
106. WinAPI Message Loop approaches to check: 
     - WinForms, 
	 - WPF, 
	 - custom loop...
107. Garbage Collecting - GIF from FileStream crashes when capture 60 seconds and more
108. 
109. More MultiThreading everywhere
110. 

## Getting Things Done

201. Proper logger pattern
202. Clean Code general cleaning
203. 







# 1 MarkDown test area 
## 2
### 3
# 1 MarkDown test area 
------------------------------------------------
## 2
------------------------
### 3
-------
## Synchronize a file

Once your file is linked to a synchronized location, StackEdit will periodically synchronize it by downloading/uploading any modification. A merge will be performed if necessary and conflicts will be resolved.

If you just have modified your file and you want to force syncing, click the **Synchronize now** button in the navigation bar.

> **Note:** The **Synchronize now** button is disabled if you have no file to synchronize.

## Manage file synchronization

Since one file can be synced with multiple locations, you can list and manage synchronized locations by clicking **File synchronization** in the **Synchronize** sub-menu. This allows you to list and remove synchronized locations that are linked to your file.

# Publication

Publishing in StackEdit makes it simple for you to publish online your files. Once you're happy with a file, you can publish it to different hosting platforms like **Blogger**, **Dropbox**, **Gist**, **GitHub**, **Google Drive**, **WordPress** and **Zendesk**. With [Handlebars templates](http://handlebarsjs.com/), you have full control over what you export.

> Before starting to publish, you must link an account in the **Publish** sub-menu.

## Publish a File

You can publish your file by opening the **Publish** sub-menu and by clicking **Publish to**. For some locations, you can choose between the following formats:

- Markdown: publish the Markdown text on a website that can interpret it (**GitHub** for instance),
- HTML: publish the file converted to HTML via a Handlebars template (on a blog for example).

## Update a publication

After publishing, StackEdit keeps your file linked to that publication which makes it easy for you to re-publish it. Once you have modified your file and you want to update your publication, click on the **Publish now** button in the navigation bar.

> **Note:** The **Publish now** button is disabled if your file has not been published yet.

## Manage file publication

Since one file can be published to multiple locations, you can list and manage publish locations by clicking **File publication** in the **Publish** sub-menu. This allows you to list and remove publication locations that are linked to your file.

# Markdown extensions

StackEdit extends the standard Markdown syntax by adding extra **Markdown extensions**, providing you with some nice features.

> **ProTip:** You can disable any **Markdown extension** in the **File properties** dialog.

# Quotations

In the words of Abraham Lincoln:

> Pardon my French

## SmartyPants

SmartyPants converts ASCII punctuation characters into "smart" typographic punctuation HTML entities. For example:

|                |ASCII                          |HTML                         |
|----------------|-------------------------------|-----------------------------|
|Single backticks|`'Isn't this fun?'`            |'Isn't this fun?'            |
|Quotes          |`"Isn't this fun?"`            |"Isn't this fun?"            |
|Dashes          |`-- is en-dash, --- is em-dash`|-- is en-dash, --- is em-dash|

## ShawMeeYRKode

Some basic Git commands are:

```
git status
git add
git commit
```

Use `git status` to list all new or modified files that haven't yet been committed.

## LynkinG

This site was built using [GitHub Pages](https://pages.github.com/).


## KaTeX

You can render LaTeX mathematical expressions using [KaTeX](https://khan.github.io/KaTeX/):

The *Gamma function* satisfying $\Gamma(n) = (n-1)!\quad\forall n\in\mathbb N$ is via the Euler integral

$$
\Gamma(z) = \int_0^\infty t^{z-1}e^{-t}dt\,.
$$

> You can find more information about **LaTeX** mathematical expressions [here](http://meta.math.stackexchange.com/questions/5020/mathjax-basic-tutorial-and-quick-reference).

## UML diagrams

You can render UML diagrams using [Mermaid](https://mermaidjs.github.io/). For example, this will produce a sequence diagram:

```mermaid
sequenceDiagram
Alice ->> Bob: Hello Bob, how are you?
Bob-->>John: How about you John?
Bob--x Alice: I am good thanks!
Bob-x John: I am good thanks!
Note right of John: Bob thinks a long<br/>long time, so long<br/>that the text does<br/>not fit on a row.

Bob-->Alice: Checking with John...
Alice->John: Yes... John, how are you?
```

And this will produce a flow chart:

```mermaid
graph LR
A[Square Rect] -- Link text --> B((Circle))
A --> C(Round Rect)
B --> D{Rhombus}
C --> D
```



# LWTFramework
2024暑期soc
暑期搓了一个半成品framework，虽然没有大佬写的那么好，也不够完善，不过还是能起到一定的辅助开发作用（大概）、
***
***
### 初始化
初始化由脚本ProjectSetUp进行管理，具体分为包初始化和文件夹初始化，~~与资产初始化，但是由于我目前没怎么用资产所以就放过它了~~
***
## 插件初始化（包初始化）
由于有一些部分是在插件的基础上进行开发的，所以首先介绍一下插件管理部分，
具体使用方法就是直接点击上方工具栏Tool/SetUp/Install Essential Packages就可以完成一键初始化了，目前只添加了新输入系统和一个计时器，可以根据需要在InstallPackages()方法中进行添加
***
## 文件夹初始化
具体使用方法就是直接点击上方工具栏Tool/SetUp/Install Essential  Folders
在Createfolders()方法中可以进行修改需要初始化的文件夹
***
***
### 有限状态机
有限状态机部分主要分为StateMachine状态机基类脚本和状态脚本，在玩家状态机里具体实现为PlayerStateMachine与PlayerState，使用方法可以参考玩家状态机的例子（Player States文件夹），在此不具体阐述（个人更加建议使用ScriptableObject去更加方便的管理状态），

***
***
### 玩家输入
因为使用了新输入系统插件，所以并没有去特意做输入，只是使用PlayerInput脚本去进行集中管理，这样的好处是可以在多套输入中进行切换与禁用


***
***
### 对话系统
对话系统的脚本在Assets/Script/Dialog文件夹，使用方法为：
1、在Assets/Data/Dialog中创建对话（create->dialog)
2、在需要触发对话的物体上添加DialogueSystem脚本然后依次添加：对话资产（Dialogue），对话框（Dialogue BoX），显示对话所需的Text组件（dialog），显示名称话所需的Text组件（characterName），控制玩家输入的组件input

可以实现的功能为在对话区按一下e键开始进行对话，期间角色控制脚本将被锁住，直到播放完对话
注：这是一个非常粗陋的对话系统，只实现了基本的功能，优点仅仅为代码量较少，容易理解，也方便去继续进行更新

***
***
### 音频管理
音频管理的脚本位于Assets/Script/Audio文件夹内，主要实现音效管理功能，具体使用方法为创建AudioData文件然后在需要的地方调用audioManager.PlaySFX();或者audioManager.PlayDelaySFX()，填入相应参数即可，

***
***
### 单例模式
使用PersistentSingieton脚本实现，有需求可直接继承

***
***
### 事件频道
脚本位于Assets/Script/EventSystem，其中包含无参数事件频道与单参数事件频道~~和事件管理器的尸体~~
使用方法为：
1、创建所需事件频道资产（creat->Data/EventChannals/)
2、按需求订阅AddListener(Open)
3、在需要的时候发布BroadCast()
具体例子在Assets/Script/Door







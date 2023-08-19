一. 创建项目结构
1. 创建wpf 项目
2. 安装 prism.dryioc mvvm 以及 ioc 框架
	2.1 继承 PrismApplication
3. 安装 ui 框架 MaterialDesignThemes
	3.1 打开 MaterialDesign 的  github wiki 查看 如何操作 https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit/wiki/Getting-Started
	3.2 按照说明设计即可
4. 创建 web.api 项目
	4.1 关闭 配置Https 

二.设计首页导航条
1.参考 MaterialDesign 的demo，直接复制ColorZone 过来进行使用修改即可

三.绑定菜单
1. 左侧菜单栏 数据绑定

四.菜单导航
1. 几个菜单跳转页面的菜单导航
	1.1 添加 index, memo, todo, settings, 的 view 和 viewmodel
	1.2 完善左侧菜单点击后的 左侧导航 ListBox

五.界面设计
1. 首页界面设计
2. ToDo 界面
1. Memo 界面
1. 设置界面


六.API 设计
1. ADTFramwork  用数据库访问
2. EFCore  创建基于不同类型的数据库

主要步骤
3. Sql: 暂时选用 sqlite3 用于学习  来演示(不依赖外部环境配置 保证应用运行)
	3.1 安装 Microsoft.EntityFrameworkCore.Sqlite  nuget

4. 安装 Microsoft.EntityFrameworkCore.Tools (.net5 还需要安装Design) 来创建迁移(Migration)
	包括以下操作: 
	1. Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.
		Enables these commonly used commands:
		Add-Migration
		Bundle-Migration
		Drop-Database
		Get-DbContext
		Get-Migration
		Optimize-DbContext
		Remove-Migration
		Scaffold-DbContext
		Script-Migration
		Update-Database

 
5.构建 DbCotext	上下文
	5.1 创建 MyToDoContext 继承自 DbContext
	5.2 数据实体
	5.3 program 或者 startup 中配置
	5.4 打开 vs工具中的 nuget程序包 管理控制台
		通过之前安装的 EFCore.Tools 添加迁移
		5.4.1 Add-Migration MyToDo  （默认项目 要选择当前的API项目 ）
		``` 
			PM> Add-Migration MyToDo
			Build started...
			Build succeeded.
			To undo this action, use Remove-Migration.
		```
		对应项目下会多出 Migrations 文件夹 包含 数据表特征的迁移文件 和 迁移快照
		5.4.2 Update-Database 
			会生成对应的 to.db 数据库文件 用 Navicat 查看 

6. 创建工作单元	
	6.1 仓储(Repository) 
		为了解决操作同步问题引入 https://github.com/Arch/UnitOfWork 的部分代码 (封装了大量的仓储模型接口和基础实现)
		    需要安装 Microsoft.EntityFrameworkCore.AutoHistory 用于 UnitOfWork.SaveChanges
	6.2 注意这里需要看懂 Unitofwork 具体是做什么，暂时对这个感念还有一些模糊

7. 待办事项接口
	7.1 创建ToDoController 的控制器  继承 ControllerBase

	7.2 创建 Services 的服务代码 来让 具体的仓储实现 与 控制器进行解耦 IBaseService (具备CRUD 的基本操作)
		创建 通用的 请求返回类型 ApiResponse

8. autoMapper 自动映射 实体对象 和 数据库对象 的类库			
	通过nuget 安装

9. 查询会涉及到很多参数的情况，在share 中创建一个 Parameters

10. 登录注册接口实现
	1. 

11. 客户端 接口对接
	1. 客户端中有许多种方式来对接Api， 取决于Api 的发布方式(web http, web services, wcf, OpenApi, grpc等)
		直接搜索"管理链接服务" 如果右键依赖项没找到入口的话
		1. 大部分应用都是通过 http 来访问，
	2. 安装 Postm 软件，进行接口调试，并且按照里面可以直接获取到对应 code 的 http 访问代码， 其中 C# 又提供了 RestSharp (https://restsharp.dev/) 最流行的 .NET REST API
	3. 回到软件项目 ，添加 restsharp 的 nuget 库
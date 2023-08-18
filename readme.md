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
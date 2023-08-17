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
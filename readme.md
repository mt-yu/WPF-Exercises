һ. ������Ŀ�ṹ
1. ����wpf ��Ŀ
2. ��װ prism.dryioc mvvm �Լ� ioc ���
	2.1 �̳� PrismApplication
3. ��װ ui ��� MaterialDesignThemes
	3.1 �� MaterialDesign ��  github wiki �鿴 ��β��� https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit/wiki/Getting-Started
	3.2 ����˵����Ƽ���
4. ���� web.api ��Ŀ
	4.1 �ر� ����Https 

��.�����ҳ������
1.�ο� MaterialDesign ��demo��ֱ�Ӹ���ColorZone ��������ʹ���޸ļ���

��.�󶨲˵�
1. ���˵��� ���ݰ�

��.�˵�����
1. �����˵���תҳ��Ĳ˵�����
	1.1 ��� index, memo, todo, settings, �� view �� viewmodel
	1.2 �������˵������� ��ർ�� ListBox

��.�������
1. ��ҳ�������
2. ToDo ����
1. Memo ����
1. ���ý���


��.API ���
1. ADTFramwork  �����ݿ����
2. EFCore  �������ڲ�ͬ���͵����ݿ�

��Ҫ����
3. Sql: ��ʱѡ�� sqlite3 ����ѧϰ  ����ʾ(�������ⲿ�������� ��֤Ӧ������)
	3.1 ��װ Microsoft.EntityFrameworkCore.Sqlite  nuget

4. ��װ Microsoft.EntityFrameworkCore.Tools (.net5 ����Ҫ��װDesign) ������Ǩ��(Migration)
	�������²���: 
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

 
5.���� DbCotext	������
	5.1 ���� MyToDoContext �̳��� DbContext
	5.2 ����ʵ��
	5.3 program ���� startup ������
	5.4 �� vs�����е� nuget����� �������̨
		ͨ��֮ǰ��װ�� EFCore.Tools ���Ǩ��
		5.4.1 Add-Migration MyToDo  ��Ĭ����Ŀ Ҫѡ��ǰ��API��Ŀ ��
		``` 
			PM> Add-Migration MyToDo
			Build started...
			Build succeeded.
			To undo this action, use Remove-Migration.
		```
		��Ӧ��Ŀ�»��� Migrations �ļ��� ���� ���ݱ�������Ǩ���ļ� �� Ǩ�ƿ���
		5.4.2 Update-Database
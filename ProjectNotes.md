��Ŀ��ASP.NET Core8+EF Core+MySql(NuGet\Install-Package Pomelo.EntityFrameworkCore.MySql -Version 8.0.0-beta.2)��ʵ��
�½���Ŀѡ��Web API����WebӦ��
����Program.cs��һЩĬ������
.http ���ڽӿڵ���
Properties\launchSettings.json ���������ļ�
ǰ��˷������Ŀ����Ҫ���ÿ������
ʹ��EF Core����ʵ�壬ӳ�䵽��
�����½���⣬���븴��
���ݿ�ӳ�䶨��
EF Core ORM���
ӳ�����÷��������ݿ⣺
	����Լ��
	����ע�⣺ͨ�����Է�ʽ����
	Fluent API:����ķ�ʽ����Ʋ��桢��ϵ��ӳ���Ƕ����ģ��Ƽ���
Ĭ����������е�ӳ�䶼�������Ľ���
ÿһ��ʵ���Ӧһ����ϵӳ�����
�����½���⣬���������ĺ���������
appsettings.json����Mysql�����ַ���
������չ��������MySql��ش���

�ִ�ģʽ
���ڹ������ĳ־û���
���ݷ��ʲ��������ҵ���߼���
�ִ����� �ṩCRUD����

�ִ��ӿڡ�һ�鷽�����洢����ѯ...
�ִ�ʵ�֡�ʵ����Щ��������������ݷ��ʼ����й�
�ִ���װ��
����������ѯ�����Ϣ

��װ���������ִ�������󣩡�ע�ᵽ������������

===========================
�ܽ�
��������
	ServiceExtensions��չ������ConfigureCors����
EF Core MySQL����
	ServiceExtensions��չ������ConfigureMySqlContext����
		��������EF Core��Ŀ
			Entites
				���ʵ����Character��Player�����ֶ�����
			EntityFramework
				���Mappings���ݿ�ӳ�����ú�����������WebApplicationDbContext��̳���DbContext
�ִ�����
	�ִ��ӿ�
		ͨ���ִ�����IBaseRepository���Զ���ִ��û��ࣨ������չ��
		������װ��IRepositoryWapperʹ�òִ��������ʹ�ã�ʹ�ð�װ�����������ִ�������ʹ��ͬһ��������
	�ִ�ʵ��
		��Repositories�н���һЩ�����ʵ��
	ServiceExtensions��չ������ConfigureRepositoryWrapper
	Add-Migration initalCreate
==============================

��������CRUD�����REST API�� ʹ�ð�װ�� ����ѯAPI �� ��������ҳ��ɸѡ������
����������������Ĵ���ģ�͵���֤�����ص���Ӧ
 Get ����
 ���ݴ������DTO-->Data Transfer Object�������ݴӷ���˴��䵽�ͻ���
 ʵ��-->�������ݿ��
 ���ֲ�-->DTO-->Ӧ��
 ʵ��-->���ݷ��ʲ�-->Ӧ��==��������==���ݿ�  

 ==============================
 DTO����ʵ�ַ��ض����ɸѡ
	Entites�����DTO�� ���÷����ֶ�
	��װAutoMapper
	��MappingProfile�ഴ������ʵ��ӳ��
	��Program.cs��ע��
	�ڿ�������������ʱʹ��ӳ�����
==============================

 Լ��·�ɺ�����·��


ǰ��BlazorȫջWeb
Docker����





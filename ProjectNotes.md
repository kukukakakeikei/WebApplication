项目是ASP.NET Core8+EF Core+MySql(NuGet\Install-Package Pomelo.EntityFrameworkCore.MySql -Version 8.0.0-beta.2)的实践
新建项目选择Web API或者Web应用
生成Program.cs有一些默认配置
.http 用于接口调试
Properties\launchSettings.json 启动配置文件
前后端分离的项目，需要配置跨域策略
使用EF Core创建实体，映射到表
单独新建类库，代码复用
数据库映射定义
EF Core ORM框架
映射配置方法→数据库：
	按照约定
	数据注解：通过特性方式声明
	Fluent API:编码的方式，设计层面、关系的映射是独立的（推荐）
默认情况下所有的映射都在上下文进行
每一个实体对应一个关系映射的类
单独新建类库，配置上下文和种子数据
appsettings.json配置Mysql连接字符串
服务扩展类中配置MySql相关代码

仓储模式
用于管理对象的持久化，
数据访问层→抽象层→业务逻辑层
仓储服务 提供CRUD方法

仓储接口→一组方法→存储，查询...
仓储实现→实现这些方法→具体的数据访问技术有关
仓储包装器
控制器→查询多个信息

包装器（各个仓储服务对象）→注册到依赖→控制器

===========================
总结
跨域配置
	ServiceExtensions扩展类增加ConfigureCors方法
EF Core MySQL配置
	ServiceExtensions扩展类增加ConfigureMySqlContext方法
		单独增加EF Core项目
			Entites
				添加实体类Character、Player进行字段配置
			EntityFramework
				添加Mappings数据库映射配置和上下文配置WebApplicationDbContext类继承于DbContext
仓储配置
	仓储接口
		通过仓储基类IBaseRepository和自定义仓储用户类（便于扩展）
		创建包装器IRepositoryWapper使得仓储可以灵活使用，使用包装器操作各个仓储，并且使用同一个上下文
	仓储实现
		在Repositories中进行一些基类的实现
	ServiceExtensions扩展类增加ConfigureRepositoryWrapper
	Add-Migration initalCreate
==============================

控制器→CRUD→设计REST API→ 使用包装器 →查询API → 搜索、分页、筛选、排序
控制器：负责请求的处理、模型的验证、返回的响应
 Get 请求
 数据传输对象（DTO-->Data Transfer Object）将数据从服务端传输到客户端
 实体-->代表数据库表
 表现层-->DTO-->应用
 实体-->数据访问层-->应用==传输载体==数据库  

 ==============================
 DTO用于实现返回对象的筛选
	Entites中添加DTO类 设置返回字段
	安装AutoMapper
	在MappingProfile类创建方法实现映射
	在Program.cs中注册
	在控制器方法返回时使用映射操作
==============================

 约定路由和特性路由


前端Blazor全栈Web
Docker部署





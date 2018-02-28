电子口岸业务卡在线办理系统
=====
### 更新日志
[TODO.md](TODO.md)
### 解决方案
* 主程序
  * 客户端 src/CardCerter
  * 管理端 src/CardCenter.Management
  * 接口服务 src/CardCenter.API
  * 数据整理 src/CardCenter.AutoTask
* 依赖项目
  * 商事数据连接（Oracle） dependent/CardCenter.CommercialAffairsOracleDataAccess
  * 数据连接 dependent/CardCenter.DataAccess
  * 数据实体 dependent/CardCenter.Entity
  * 页面基类 dependent/CardCenter.PageBase
---
## 安装调试
1. 安装 FrameWork3.5 [https://dotnet.github.io/](https://dotnet.github.io/)
2. 下载源码 git clone https://github.com/watson1029/EportCardCenter.git
3. 恢复依赖包 dotnet restore 
4. 运行 dotnet run
---
## 部署
### IIS
### Docker
---

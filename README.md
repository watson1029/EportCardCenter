电子口岸业务卡在线办理系统
=====
### 客户端
src/CardCerter
### 管理端
src/CardCenterManagement
### 数据整理
src/AutoTask
### 数据连接层
dependent/CardCenter.CommercialAffairsOracleDataAccess

dependent/CardCenter.DataAccess
### 实体层
dependent/CardCenter.Entity
### 页面基类
dependent/CardCenter.PageBase
### 系统服务
dependent/CardCenter.Service

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

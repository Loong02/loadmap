1. .net core, asp.net core, asp.net core mvc, ef core
2. DDD OO IOC AOP
3. mysql redis
redis:
腾讯云 centos 7 下载redis镜像后并运行
问题一：firewall 没有运行好像也是会限制出入站
解决：添加6379的入站规则到firewall，然后启动firewall
问题二：redis默认只能运行内网访问
解决方案1：配置protected-mode 为 no（关闭保护模式）
解决方案2：配置bind *-* （允许所有ip访问），且配置 redis 密码 requirepass [你的密码]
问题三：docker restart 失败，提示DOCKER chain找不到
解决：主要是firewall重启后，清除了DOCKER的chain，重启docker既可以恢复

redis 副本集：
副本配置 replicatof [host] [port]
- master 同步数据给 slaver 默认是异步的，可通过WAIT命令，同步等待数据的复制完成
- master 与 slaver 连接中断，重连后会尝试部分重新同步，如果无法进行重新同步，则进行完整同步


1. ocelot, id4, es, mongodb, rebbitmq
2. vue, linux
3. docker, k8s

4. sql server
    一些监控指标：
   set showplan_xml on
   set statistics xml on
   set statistics time on 记录执行耗时
   set statistics io on 记录执行过程io数据
   清除缓存：
   DBCC FREEPROCCACHE    清除存储过程缓存
   DBCC FREESESSIONCACHE  清除会话缓存
   DBCC FREESYSTEMCACHE('All')  清除系统缓存
   DBCC DROPCLEANBUFFERS 清除所有缓存
# Ocelot(网关)

# identity4
OAuth 授权协议 与 其扩展OpenID Connect 认证协议 (多了jtoken的认证令牌)


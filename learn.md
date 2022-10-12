# 需要了解的知识
1. .net core, asp.net core, asp.net core mvc, ef core
2. DDD OO IOC AOP
3. mysql redis
4. ocelot, id4, es, mongodb, rebbitmq
5. vue, linux
6. docker, k8s

# redis
## 基本的5大数据类型

1. string
2. hash
3. set
4. sortset
5. list

## 持久化

1. RDB (redis database, 快照) 

2. AOF (append only file, 命令追加)

3. 7.0 更新

## 容器部署redis并访问:

> 腾讯云 centos 7 下载redis镜像后并运行    
  问题一：firewall 没有运行好像也是会限制出入站  
  解决：添加6379的入站规则到firewall，然后启动firewall  
  问题二：redis默认只能运行内网访问  
  解决方案1：配置protected-mode 为 no（关闭保护模式）  
  解决方案2：配置bind *-* （允许所有ip访问），且配置 redis 密码 requirepass [你的密码]  
  问题三：docker restart 失败，提示DOCKER chain找不到  
  解决：主要是firewall重启后，清除了DOCKER的chain，重启docker既可以恢复

## 副本集

1. 目的：读写分离，多个实例提供访问，降低单节点负载
> 副本配置 replicatof [host] [port]  
  master 同步数据给 slaver 默认是异步的，可通过WAIT命令，同步等待数据的复制完成，slaver 会异步确认从master接受的数据量  
  master 与 slaver 连接中断，重连后会尝试部分重新同步，如果无法进行重新同步，则进行完整同步（创建一个快照，发生到slaver，同时缓存快照之后的数据，待slaver初始完成后同步缓存的数据）

## 哨兵

1. 特点，主要是为了故障转移，一般需要3台哨兵进行监听选举

## 集群

## 缓存穿透

当用户访问的数据不在缓存中，也不在数据库中，请求直接打到数据库上，导致数据库压力增加。不处理则一直都会有该问题。

### 解决办法
1. 缓存空值，既然数据库查不到则存一个空的值到缓存
2. 布隆过滤器，布隆过滤器的特点是能准确的知道不存在的事物

## 缓存击穿

单独缓存过期时，有大量请求进入，导致数据库压力

### 解决办法

1. 查询数据库

## 缓存雪崩

大量缓存key在同一时间过期，导致大量请求直接打到数据库上

### 解决办法

1. 设置不同的过期时间，或者不设置超时时间
2. 做请求限流

# sql server

## 监控指标开启
```
    开启指标：
   set showplan_xml on
   set statistics xml on
   set statistics time on 记录执行耗时
   set statistics io on 记录执行过程io数据
   清除缓存：
   DBCC FREEPROCCACHE    清除存储过程缓存
   DBCC FREESESSIONCACHE  清除会话缓存
   DBCC FREESYSTEMCACHE('All')  清除系统缓存
   DBCC DROPCLEANBUFFERS 清除所有缓存
```
# Ocelot(网关)

# identity4
OAuth 授权协议 与 其扩展OpenID Connect 认证协议 (多了jtoken的认证令牌)


# centos 防火墙使用相关
```
1. 查看防火墙某个端口是否开放
firewall-cmd --query-port=3306/tcp
2. 开放防火墙端口3306（注意：开放端口后要重启防火墙生效）
firewall-cmd --zone=public --add-port=3306/tcp --permanent
3. 重启防火墙
systemctl restart firewalld
4. 关闭防火墙端口
firewall-cmd --remove-port=3306/tcp --permanent
5. 查看防火墙状态
systemctl status firewalld
6. 关闭防火墙
systemctl stop firewalld
7. 打开防火墙
systemctl start firewalld
8. 开放一段端口
firewall-cmd --zone=public --add-port=40000-45000/tcp --permanent
9. 查看开放的端口列表
firewall-cmd --zone=public --list-ports
10. 查看被监听(Listen)的端口
netstat -lntp
11. 检查端口被哪个进程占用
netstat -lnp|grep 3306
```

